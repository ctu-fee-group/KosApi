//
//   KosAtomApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Kos.Abstractions;
using Kos.Atom;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kos.Controllers
{
    /// <inheritdoc />
    public class KosAtomApi : IKosAtomApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TokenProvider _tokenProvider;
        private readonly ILogger<KosAtomApi> _logger;
        private readonly XmlSerializerFactory _xmlSerializerFactory;
        private readonly KosApiOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosAtomApi"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The factory of <see cref="HttpClient"/>.</param>
        /// <param name="tokenProvider">The provider of an access token.</param>
        /// <param name="options">The options.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="xmlSerializerFactory">The xml serializer factory.</param>
        public KosAtomApi
        (
            IHttpClientFactory httpClientFactory,
            TokenProvider tokenProvider,
            IOptions<KosApiOptions> options,
            ILogger<KosAtomApi> logger,
            XmlSerializerFactory xmlSerializerFactory
        )
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
            _logger = logger;
            _xmlSerializerFactory = xmlSerializerFactory;
            _options = options.Value;
        }

        /// <inheritdoc />
        public async Task<AtomEntry<TContent>?> LoadEntryAsync<TContent>
            (string endpoint, Action<AtomEntryQueryBuilder>? configureRequest = null, CancellationToken token = default)
            where TContent : class, new()
        {
            using var request = ConfigureRequest(new AtomEntryQueryBuilder(endpoint, HttpMethod.Get), configureRequest);
            using var response = await ExecuteRequestAsync(request, token);
            if (response is null)
            {
                return null;
            }

            return await ParseResponseEntity<AtomEntry<TContent>>(response, token);
        }

        /// <inheritdoc />
        public virtual Task<AtomEntry<TContent>?> LoadEntryAsync<TContent>
        (
            AtomLoadableEntity<TContent>? kosLoadable,
            Action<AtomEntryQueryBuilder>? configureRequest = null,
            CancellationToken token = default
        )
            where TContent : class, new()
        {
            if (kosLoadable?.Href is null)
            {
                return Task.FromResult<AtomEntry<TContent>?>(default);
            }

            return LoadEntryAsync<TContent>(kosLoadable.Href, configureRequest, token);
        }

        /// <inheritdoc />
        public virtual async Task<AtomFeed<T>?> LoadFeedAsync<T>
            (string endpoint, Action<AtomFeedQueryBuilder>? configureRequest = null, CancellationToken token = default)
            where T : class, new()
        {
            using var request = ConfigureRequest(new AtomFeedQueryBuilder(endpoint, HttpMethod.Get), configureRequest);
            using var response = await ExecuteRequestAsync(request, token);
            if (response is null)
            {
                return default;
            }

            return await ParseResponseEntity<AtomFeed<T>>(response, token);
        }

        private async Task<HttpResponseMessage?> ExecuteRequestAsync
            (HttpRequestMessage request, CancellationToken token)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Kos");
                return await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
            }
            catch (Exception e)
            {
                if (_options.ThrowOnError)
                {
                    throw;
                }

                _logger.LogError(e, "There was an error while calling the api");
                return default;
            }
        }

        private HttpRequestMessage ConfigureRequest<T>
            (T builder, Action<T>? configureAction)
            where T : RequestQueryBuilder
        {
            configureAction?.Invoke(builder);
            var requestMessage = builder.Build();
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenProvider.AccessToken);

            return requestMessage;
        }

        private async Task HandleErrorResponse(HttpResponseMessage response, CancellationToken token)
        {
            try
            {
                await using var content = await response.Content.ReadAsStreamAsync(token);
                var reader = new StreamReader(content);
                var contentString = await reader.ReadToEndAsync();

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return;
                }

                string errorMessage =
                    $"There was an error with calling kos api: {response.StatusCode.ToString()} {response.ReasonPhrase} {contentString}";
                if (_options.ThrowOnError)
                {
                    throw new Exception(errorMessage);
                }

                _logger.LogError(errorMessage);
            }
            catch (Exception e)
            {
                if (_options.ThrowOnError)
                {
                    throw;
                }

                _logger.LogError
                (
                    e,
                    $"There was an error while processing the http response {response.StatusCode} {response.ReasonPhrase}"
                );
            }
        }

        private async Task<TEntity?> ParseResponseEntity<TEntity>(HttpResponseMessage response, CancellationToken token)
        {
            if (response.IsSuccessStatusCode)
            {
                await using var stream = await response.Content.ReadAsStreamAsync(token);
                return (TEntity?)_xmlSerializerFactory.CreateSerializer(typeof(TEntity)).Deserialize(stream);
            }

            await HandleErrorResponse(response, token);
            return default;
        }
    }
}