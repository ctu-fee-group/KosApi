//
//  KosApiAuthenticator.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RestSharp;
using RestSharp.Authenticators;

namespace Kos.RestSharp
{
    /// <summary>
    /// Authenticator using access_token as GET parameter.
    /// </summary>
    public class KosApiAuthenticator : AuthenticatorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KosApiAuthenticator"/> class.
        /// </summary>
        /// <param name="token">The access token to pass as a parameter.</param>
        public KosApiAuthenticator(string token)
            : base(token)
        {
        }

        /// <inheritdoc />
        protected override Parameter GetAuthenticationParameter(string accessToken) =>
            new Parameter("access_token", accessToken, ParameterType.QueryString);
    }
}