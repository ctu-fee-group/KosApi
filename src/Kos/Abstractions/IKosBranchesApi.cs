//
//   IKosBranchesApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.Data;

namespace Kos.Abstractions
{
    /// <summary>
    /// Represents mapping to kos api branches.
    /// </summary>
    public interface IKosBranchesApi
    {
        /// <summary>
        /// Gets paged branches filtered using RSQL query.
        /// </summary>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded branches.</returns>
        public Task<IReadOnlyList<Branch>> GetBranches
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets branch by its id.
        /// </summary>
        /// <param name="id">The id of the branch.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded branch. Null if it was not found.</returns>
        public Task<Branch?> GetBranch(string id, string? lang = null, CancellationToken token = default);

        /// <summary>
        /// Gets branch by its loadable entity.
        /// </summary>
        /// <param name="branchLoadableEntity">The loadable entity.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded branch. Null if it was not found.</returns>
        public Task<Branch?> GetBranch
            (AtomLoadableEntity<Branch> branchLoadableEntity, string? lang = null, CancellationToken token = default);

        /// <summary>
        /// Gets paged branch study plans by its loadable entity.
        /// </summary>
        /// <param name="branchLoadableEntity">The loadable entity.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded study plans.</returns>
        public Task<IReadOnlyList<StudyPlan>> GetBranchStudyPlans
        (
            AtomLoadableEntity<Branch> branchLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets paged branch study plans by id of a branch.
        /// </summary>
        /// <param name="branchId">The id of the branch.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded study plans.</returns>
        public Task<IReadOnlyList<StudyPlan>> GetBranchStudyPlans
        (
            string branchId,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );
    }
}