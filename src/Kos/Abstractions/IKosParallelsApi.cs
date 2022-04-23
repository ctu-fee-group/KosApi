//
//   IKosParallelsApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Data;
using Parallel = Kos.Data.Parallel;

namespace Kos.Abstractions
{
    /// <summary>
    /// Represents mapping to parallels kos api.
    /// </summary>
    public interface IKosParallelsApi
    {
        /// <summary>
        /// Gets paged parallels filtered using RSQL query.
        /// </summary>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="includeInvalidSlots">Whether to include invalid slots.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded parallels.</returns>
        public Task<IReadOnlyList<Parallel>> GetParallels
        (
            string? query = null,
            bool includeInvalidSlots = false,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets parallel by its id.
        /// </summary>
        /// <param name="id">The id of the parallel.</param>
        /// <param name="includeInvalidSlots">Whether to include invalid slots.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded parallel.</returns>
        public Task<Parallel?> GetParallel
        (
            string id,
            bool includeInvalidSlots = false,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets related parallels for parallel by its id.
        /// </summary>
        /// <param name="parallelId">The id of the parallel to get related parallels for.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="includeInvalidSlots">Whether to include invalid slots.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded related parallels.</returns>
        public Task<IReadOnlyList<Parallel>> GetRelatedParallels
        (
            string parallelId,
            string? query = null,
            bool includeInvalidSlots = false,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets paged parallels filtered using RSQL query.
        /// </summary>
        /// <param name="parallelId">The id of the parallel to get related parallels for.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded parallels.</returns>
        public Task<IReadOnlyList<Student>> GetParallelStudents
        (
            string parallelId,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );
    }
}