//
//   TokenProvider.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Kos.Abstractions;

namespace Kos
{
    /// <summary>
    /// Provider of token for <see cref="IKosAtomApi"/>.
    /// </summary>
    public class TokenProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenProvider"/> class.
        /// </summary>
        /// <param name="accessToken">The access token to provide.</param>
        public TokenProvider(string accessToken)
        {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }
    }
}