using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Atom;
using Kos.Data;
using Microsoft.Extensions.Logging;

namespace Kos.Controllers
{
    public class KosPeopleApi : KosApiController, IKosPeopleApi
    {
        public KosPeopleApi(IKosAtomApi atomApi, ILogger<KosPeopleApi> logger)
            : base(atomApi, logger)
        {
        }

        /// <summary>
        /// Call /people/{username} and return its response
        /// </summary>
        /// <param name="username"></param>
        /// <param name="token"></param>
        /// <returns>Null in case of an error</returns>
        public Task<KosPerson?> GetPersonAsync(string username, CancellationToken token = default)
        {
            return _atomApi.LoadEntityAsync<KosPerson>(new AtomLoadableEntity<KosPerson>()
            {
                Href = $"people/{username}",
                Title = null
            }, token);
        }
    }
}
