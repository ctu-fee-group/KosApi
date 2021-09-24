//
//  CachingKosAtomApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Kos.Abstractions;
using Kos.Atom;
using Kos.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kos.Caching
{
    /// <summary>
    /// Represents <see cref="IKosAtomApi"/> that caches the entities.
    /// </summary>
    public class CachingKosAtomApi : KosAtomApi
    {
        private readonly KosCacheService _cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingKosAtomApi"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The factory of <see cref="HttpClient"/>.</param>
        /// <param name="tokenProvider">The provider of an access token.</param>
        /// <param name="options">The options.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="xmlSerializerFactory">The serializer factory.</param>
        /// <param name="cacheService">The caching service.</param>
        public CachingKosAtomApi
        (
            IHttpClientFactory httpClientFactory,
            TokenProvider tokenProvider,
            IOptions<KosApiOptions> options,
            ILogger<CachingKosAtomApi> logger,
            XmlSerializerFactory xmlSerializerFactory,
            KosCacheService cacheService
        )
            : base(httpClientFactory, tokenProvider, options, logger, xmlSerializerFactory)
        {
            _cacheService = cacheService;
        }

        /// <inheritdoc />
        public override async Task<AtomEntry<T>?> LoadEntryAsync<T>
        (
            AtomLoadableEntity<T>? kosLoadable,
            Action<AtomEntryQueryBuilder>? configureRequest = null,
            CancellationToken token = default
        )
            where T : class
        {
            if (kosLoadable?.Href is null)
            {
                return null;
            }

            if (_cacheService.TryGetValue(kosLoadable.Href, out AtomEntry<T>? cachedValue))
            {
                return cachedValue;
            }

            return _cacheService.Cache
                (kosLoadable.Href, await base.LoadEntryAsync(kosLoadable, configureRequest, token));
        }

        /// <inheritdoc />
        public override async Task<AtomFeed<T>?> LoadFeedAsync<T>
            (string endpoint, Action<AtomFeedQueryBuilder>? configureRequest = null, CancellationToken token = default)
        {
            var entities = await base.LoadFeedAsync<T>(endpoint, configureRequest, token);

            return entities;
        }
    }
}