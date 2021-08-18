using System.Collections.Generic;
using Kos.Data;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Kos
{
    public abstract class KosApiController
    {
        protected readonly ILogger _logger;
        protected readonly IXmlAtomApi _atomApi;

        internal KosApiController(IXmlAtomApi atomApi, ILogger logger)
        {
            _logger = logger;
            _atomApi = atomApi;
        }
    }
}