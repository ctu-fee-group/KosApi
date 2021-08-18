using System;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.Data;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Kos
{
    public class KosApiStudents : KosApiController
    {
        internal KosApiStudents(IXmlAtomApi atomApi, ILogger logger)
            : base(atomApi, logger)
        {
        }

        /// <summary>
        /// Call /students/{studyCodeOrId} and return its response
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cachePolicy"></param>
        /// <param name="studyCodeOrId"></param>
        /// <returns>Null in case of an error</returns>
        public Task<KosStudent?> GetStudentAsync(string studyCodeOrId, CachePolicy cachePolicy = CachePolicy.DownloadIfNotAvailable,
            CancellationToken token = default)
        {
            return _atomApi.LoadEntityAsync<KosStudent>(new AtomLoadableEntity<KosStudent>()
            {
                Href = $"students/{studyCodeOrId}",
                Title = null
            }, cachePolicy, token);
        }
    }
}