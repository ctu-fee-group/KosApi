using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.Data;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Kos
{
    public class KosApiTeachers : KosApiController
    {
        public KosApiTeachers(IXmlAtomApi atomApi, ILogger logger)
            : base(atomApi, logger)
        {
        }

        /// <summary>
        /// Call /students/{usernameOrId} and return its response
        /// </summary>
        /// <param name="token"></param>
        /// <param name="usernameOrId"></param>
        /// <param name="cachePolicy"></param>
        /// <returns>Null in case of an error</returns>
        public Task<KosTeacher?> GetTeacherAsync(string usernameOrId, CachePolicy cachePolicy = CachePolicy.DownloadIfNotAvailable,
            CancellationToken token = default)
        {
            return _atomApi.LoadEntityAsync<KosTeacher>(new AtomLoadableEntity<KosTeacher>()
            {
                Href = $"teachers/{usernameOrId}",
                Title = null
            }, cachePolicy, token);
        }
    }
}