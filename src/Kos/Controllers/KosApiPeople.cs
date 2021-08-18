using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.Data;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Kos
{
    public class KosApiPeople : KosApiController
    {
        internal KosApiPeople(IXmlAtomApi atomApi, ILogger logger)
            : base(atomApi, logger)
        {
        }

        /// <summary>
        /// Call /people/{username} and return its response
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cachePolicy"></param>
        /// <param name="token"></param>
        /// <returns>Null in case of an error</returns>
        public Task<KosPerson?> GetPersonAsync(string username, CachePolicy cachePolicy = CachePolicy.DownloadIfNotAvailable,
            CancellationToken token = default)
        {
            return _atomApi.LoadEntityAsync<KosPerson>(new AtomLoadableEntity<KosPerson>()
            {
                Href = $"people/{username}",
                Title = null
            }, cachePolicy, token);
        }
    }
}
