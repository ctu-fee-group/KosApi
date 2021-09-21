//
//  IKosPeopleApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading;
using System.Threading.Tasks;
using Kos.Data;

namespace Kos.Abstractions
{
    /// <summary>
    /// Represents mapping to kos api for obtaining people entities.
    /// </summary>
    public interface IKosPeopleApi
    {
        /// <summary>
        /// Gets the person by the username.
        /// </summary>
        /// <param name="username">The username of the user to get.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded person. Null if the person was not found.</returns>
        public Task<KosPerson?> GetPersonAsync(string username, CancellationToken token = default);
    }
}