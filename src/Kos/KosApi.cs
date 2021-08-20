using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kos
{
    /// <summary>
    /// Entity used to obtain authorized api with specified access token
    /// </summary>
    public class KosApi : IDisposable
    {
        private readonly KosApiOptions _options;
        private readonly ILogger _logger;
        private readonly Dictionary<string, AuthorizedKosApi> _authorizedApis;

        public KosApi(IOptionsSnapshot<KosApiOptions> options, ILogger<KosApi> logger)
        {
            _authorizedApis = new Dictionary<string, AuthorizedKosApi>();
            _options = options.Value;
            _logger = logger;
        }

        public AuthorizedKosApi GetAuthorizedApi(string accessToken)
        {
            if (_authorizedApis.ContainsKey(accessToken))
            {
                return _authorizedApis[accessToken];
            }
            
            AuthorizedKosApi api = new AuthorizedKosApi(accessToken, _options, _logger);
            _authorizedApis.Add(accessToken, api);

            return api;
        }

        public void Dispose()
        {
            foreach (AuthorizedKosApi api in _authorizedApis.Values)
            {
                api.Dispose();
            }
            _authorizedApis.Clear();
        }
    }
}