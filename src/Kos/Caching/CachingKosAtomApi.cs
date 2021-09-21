//
//  CachingKosAtomApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.RestSharp;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Kos.Caching
{
    /// <summary>
    /// Represents <see cref="IKosAtomApi"/> that caches the entities.
    /// </summary>
    public class CachingKosAtomApi : RestClientKosAtomApi
    {
        private readonly KosCacheService _cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingKosAtomApi"/> class.
        /// </summary>
        /// <param name="cacheService">The caching service.</param>
        /// <param name="client">The rest client.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="options">The options.</param>
        public CachingKosAtomApi
        (
            KosCacheService cacheService,
            IRestClient client,
            ILogger logger,
            KosApiOptions options
        )
            : base(client, logger, options)
        {
            _cacheService = cacheService;
        }

        /// <inheritdoc />
        public override async Task<T?> LoadEntityAsync<T>
            (AtomLoadableEntity<T>? kosLoadable, CancellationToken token = default)
            where T : class
        {
            if (kosLoadable?.Href is null)
            {
                return null;
            }

            if (_cacheService.TryGetValue(kosLoadable.Href, out T? cachedValue))
            {
                return cachedValue;
            }

            return _cacheService.Cache(kosLoadable.Href, await base.LoadEntityAsync(kosLoadable, token));
        }
    }
}