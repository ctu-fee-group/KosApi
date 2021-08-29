using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Kos.Caching
{
    public class CachingKosAtomApi : RestClientKosAtomApi
    {
        private readonly KosCacheService _cacheService;
        
        public CachingKosAtomApi(KosCacheService cacheService, IRestClient client, ILogger logger,
            KosApiOptions options) : base(client, logger, options)
        {
            _cacheService = cacheService;
        }

        public override async Task<T?> LoadEntityAsync<T>(AtomLoadableEntity<T>? kosLoadable, CancellationToken token = default) where T : class
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