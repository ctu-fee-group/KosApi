//
//  KosCacheService.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Kos.Caching
{
    /// <summary>
    /// Caching service that handles caching of the entries.
    /// </summary>
    public class KosCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly KosCacheOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosCacheService"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache to store the data in.</param>
        /// <param name="options">The options.</param>
        public KosCacheService(IMemoryCache memoryCache, IOptions<KosCacheOptions> options)
        {
            _memoryCache = memoryCache;
            _options = options.Value;
        }

        /// <summary>
        /// Cache the given item.
        /// </summary>
        /// <param name="key">The key to cache with.</param>
        /// <param name="value">The value to cache.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>The passed value.</returns>
        public T? Cache<T>(string key, T? value) =>
            _memoryCache.Set
                (CreateKey(key), value, _options.CreateCacheEntryOptions<T>());

        /// <summary>
        /// Tries to get the specified value by the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value if if was found.</param>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <returns>Whether the item exists in the cache.</returns>
        public bool TryGetValue<T>(string key, out T? value)
        {
            if (_memoryCache.TryGetValue(CreateKey(key), out var val))
            {
                value = (T?)val;
                return true;
            }

            value = default;
            return false;
        }

        private string CreateKey(string key) => "Kos" + key;
    }
}