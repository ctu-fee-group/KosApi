//
//  KosApiFactory.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Kos.RestSharp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serialization.Xml;

namespace Kos
{
    /// <inheritdoc />
    public class KosApiFactory : IKosAtomApiFactory
    {
        private readonly KosApiOptions _options;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosApiFactory"/> class.
        /// </summary>
        /// <param name="options">The options of the factory.</param>
        /// <param name="logger">The logger.</param>
        public KosApiFactory(IOptionsSnapshot<KosApiOptions> options, ILogger<RestClientKosAtomApi> logger)
        {
            _logger = logger;
            _options = options.Value;
        }

        /// <inheritdoc />
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