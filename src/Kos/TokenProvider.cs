//
//   TokenProvider.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;

namespace Kos
{
    /// <summary>
    /// Provider of token for <see cref="IKosAtomApi"/>.
    /// </summary>
    public class TokenProvider
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Func<IServiceProvider, CancellationToken, Task<string>> _getToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenProvider"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service collection provider.</param>
        /// <param name="getToken">The method to obtain access token to provide.</param>
        public TokenProvider(IServiceProvider serviceProvider, Func<IServiceProvider, CancellationToken, Task<string>> getToken)
        {
            _serviceProvider = serviceProvider;
            _getToken = getToken;
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <param name="ct">The cancellation token to cancel the operation.</param>
        /// <returns>The access token.</returns>
        public async Task<string> GetAccessTokenAsync(CancellationToken ct)
            => await _getToken(_serviceProvider, ct);
    }
}