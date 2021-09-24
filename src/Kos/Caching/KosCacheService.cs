//
//  KosCacheService.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Kos.Atom;
using Kos.Data;
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
        /// <param name="value">The value to cache.</param>
        /// <param name="id">The key of the entry to cache, if we know it.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>The passed value.</returns>
        public AtomEntry<T>? CacheEntry<T>(AtomEntry<T>? value, string? id)
            where T : new()
            => _memoryCache.Set($"Kos/{CreateKey<T>(value, id)}", value, _options.CreateCacheEntryOptions<T>());

        /// <summary>
        /// Tries to get the specified value by the key.
        /// </summary>
        /// <param name="id">The id of the entry.</param>
        /// <param name="value">The value if if was found.</param>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <returns>Whether the item exists in the cache.</returns>
        public bool TryGetEntry<T>(string id, out AtomEntry<T>? value)
            where T : new()
        {
            if (_memoryCache.TryGetValue($"Kos/{CreateKey(id)}", out var val))
            {
                value = (AtomEntry<T>?)val;
                return true;
            }

            value = default;
            return false;
        }

        private string CreateKey(string id) => id.Trim('/');

        private string CreateKey<T>(AtomEntry<T>? entry, string? id)
            where T : new()
        {
            if (id is not null)
            {
                return id;
            }

            if (entry is null)
            {
                throw new ArgumentException(nameof(entry));
            }

            return CreateKey(entry.Link.Href);
        }
    }
}