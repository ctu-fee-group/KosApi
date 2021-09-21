//
//  RestClientKosAtomApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Kos.RestSharp
{
    /// <summary>
    /// Represents <see cref="IKosAtomApi"/> that uses <see cref="IRestClient"/>.
    /// </summary>
    public class RestClientKosAtomApi : IKosAtomApi
    {
        private readonly IRestClient _client;
        private readonly ILogger _logger;
        private readonly KosApiOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClientKosAtomApi"/> class.
        /// </summary>
        /// <param name="client">The rest client with configured authentication.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="options">The options.</param>
        public RestClientKosAtomApi(IRestClient client, ILogger logger, KosApiOptions options)
        {
            _client = client;
            _options = options;
            _logger = logger;
        }

        /// <inheritdoc />
        public virtual async Task<T?> LoadEntityAsync<T>
        (
            AtomLoadableEntity<T>? kosLoadable,
            CancellationToken token = default
        )
            where T : class, new()
        {
            if (kosLoadable?.Href is null)
            {
                _logger.LogWarning($"Cannot obtain href from {typeof(T).FullName} loadable");
                return default;
            }

            IRestRequest request =
                new RestRequest
                (
                    kosLoadable.Href,
                    Method.GET
                );

            return await GetResponse<T>(kosLoadable.Href, request, token);
        }

        private async Task<T?> GetResponse<T>(string identifier, IRestRequest request, CancellationToken token)
            where T : class, new()
        {
            var response = await _client.ExecuteAsync<AtomEntry<T?>>(request, token);
            if (!response.IsSuccessful || response?.Data is null || response.Data.Content is null)
            {
                _logger.LogWarning
                (
                    response?.ErrorException,
                    $"Could not obtain kos api information({identifier}): {response?.StatusCode} {response?.ErrorMessage} {response?.Content}"
                );

                if (_options.ThrowOnError && response?.StatusCode != HttpStatusCode.NotFound)
                {
                    if (response?.ErrorException is not null)
                    {
                        throw response.ErrorException;
                    }

                    throw new InvalidOperationException
                    (
                        $"Could not obtain response from the server {response?.StatusCode} {response?.ErrorMessage} {response?.Content}"
                    );
                }
            }

            return response?.Data?.Content;
        }
    }
}