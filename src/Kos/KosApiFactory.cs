using System;
using System.Collections.Generic;
using Kos.RestSharp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serialization.Xml;

namespace Kos
{
    public class KosApiFactory : IKosAtomApiFactory
    {
        private readonly KosApiOptions _options;
        private readonly ILogger _logger;

        public KosApiFactory(IOptionsSnapshot<KosApiOptions> options, ILogger<RestClientKosAtomApi> logger)
        {
            _logger = logger;
            _options = options.Value;
        }

        public IKosAtomApi CreateApi(string accessToken)
        {
            var client = new RestClient(_options.BaseUrl ??
                                        throw new InvalidOperationException("Could not obtain base url from options"));

            client.Authenticator = new KosApiAuthenticator(accessToken);
            client.UseDotNetXmlSerializer();

            return new RestClientKosAtomApi(client, _logger, _options);
        }
    }
}