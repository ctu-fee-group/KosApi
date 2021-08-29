using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Kos.Caching
{
    public class KosCacheService
    {
        private readonly IMemoryCache _memoryCache;

        public KosCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T? Cache<T>(string key, T? value)
        {
            // TODO: move 5 minutes to options dependency
            return _memoryCache.Set(CreateKey(key), value, DateTimeOffset.Now.AddMinutes(5));
        }

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

        private string CreateKey(string key)
        {
            return "Kos" + key;
        }
    }
}