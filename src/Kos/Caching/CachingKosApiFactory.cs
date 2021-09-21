//
//  CachingKosApiFactory.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Kos.RestSharp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serialization.Xml;

namespace Kos.Caching
{
    /// <summary>
    /// Represents a factory for <see cref="IKosAtomApi"/> that caches the content.
    /// </summary>
    public class CachingKosApiFactory : IKosAtomApiFactory
    {
        private readonly KosApiOptions _options;
        private readonly ILogger _logger;
        private readonly KosCacheService _cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingKosApiFactory"/> class.
        /// </summary>
        /// <param name="cacheService">The caching service.</param>
        /// <param name="options">The options for kos api.</param>
        /// <param name="logger">The logger.</param>
        public CachingKosApiFactory
        (
            KosCacheService cacheService,
            IOptionsSnapshot<KosApiOptions> options,
            ILogger<RestClientKosAtomApi> logger
        )
        {
            _logger = logger;
            _options = options.Value;
            _cacheService = cacheService;
        }

        /// <inheritdoc />
        public IKosAtomApi CreateApi(string accessToken)
        {
            var client = new RestClient
            (
                _options.BaseUrl ??
                throw new InvalidOperationException("Could not obtain base url from options")
            ) { Authenticator = new KosApiAuthenticator(accessToken) };

            client.UseDotNetXmlSerializer();

            return new CachingKosAtomApi(_cacheService, client, _logger, _options);
        }
    }
}