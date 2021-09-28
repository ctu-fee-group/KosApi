//
//  IKosPeopleApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.Data;

namespace Kos.Abstractions
{
    /// <summary>
    /// Represents mapping to kos api for obtaining people entities.
    /// </summary>
    public interface IKosPeopleApi
    {
        /// <summary>
        /// Gets paged people filtered using RSQL query.
        /// </summary>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded people.</returns>
        public Task<IReadOnlyList<Person>> GetPeopleAsync
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets the person by the username.
        /// </summary>
        /// <param name="username">The username of the user to get.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded person. Null if the person was not found.</returns>
        public Task<Person?> GetPersonAsync(string username, CancellationToken token = default);

        /// <summary>
        /// Gets the person from the loadable entity.
        /// </summary>
        /// <param name="loadableEntity">The loadable entity specifying what user to load.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded person. Null if the person was not found.</returns>
        public Task<Person?> GetPersonAsync
            (AtomLoadableEntity<Person> loadableEntity, CancellationToken token = default);
    }
}