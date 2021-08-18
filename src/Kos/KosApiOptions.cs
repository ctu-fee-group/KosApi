using Microsoft.Extensions.Caching.Memory;

namespace Kos
{
    /// <summary>
    /// Options for kos api
    /// </summary>
    public class KosApiOptions
    {
        public MemoryCacheOptions? CacheOptions { get; set; }
        
        /// <summary>
        /// Url of the API
        /// </summary>
        public string? BaseUrl { get; set; }
    }
}