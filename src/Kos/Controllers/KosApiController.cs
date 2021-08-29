using Microsoft.Extensions.Logging;

namespace Kos.Controllers
{
    public abstract class KosApiController
    {
        protected readonly ILogger _logger;
        protected readonly IKosAtomApi _atomApi;

        internal KosApiController(IKosAtomApi atomApi, ILogger logger)
        {
            _logger = logger;
            _atomApi = atomApi;
        }
    }
}