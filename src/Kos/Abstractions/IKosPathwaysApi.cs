//
//   IKosPathwaysApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Data;

namespace Kos.Abstractions
{
    /// <summary>
    /// Represents mapping to kos pathways api.
    /// </summary>
    public interface IKosPathwaysApi
    {
        /// <summary>
        /// Gets paged pathways filtered using RSQL query.
        /// </summary>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with pathways separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded pathways.</returns>
        public Task<IReadOnlyList<Pathway>> GetPathways
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets pathway by its id.
        /// </summary>
        /// <param name="id">The id of the pathway.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded pathway. Null if it was not found.</returns>
        public Task<Pathway?> GetPathway(string id, string? lang = null, CancellationToken token = default);
    }
}