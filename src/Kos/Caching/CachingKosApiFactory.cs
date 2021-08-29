using System;
using Kos.RestSharp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serialization.Xml;

namespace Kos.Caching
{
    public class CachingKosApiFactory : IKosAtomApiFactory
    {
        private readonly KosApiOptions _options;
        private readonly ILogger _logger;
        private readonly KosCacheService _cacheService;

        public CachingKosApiFactory(KosCacheService cacheService, IOptionsSnapshot<KosApiOptions> options,
            ILogger<RestClientKosAtomApi> logger)
        {
            _logger = logger;
            _options = options.Value;
            _cacheService = cacheService;
        }

        public IKosAtomApi CreateApi(string accessToken)
        {
            var client = new RestClient(_options.BaseUrl ??
                                        throw new InvalidOperationException("Could not obtain base url from options"))
            {
                Authenticator = new KosApiAuthenticator(accessToken)
            };

            client.UseDotNetXmlSerializer();

            return new CachingKosAtomApi(_cacheService, client, _logger, _options);
        }
    }
}