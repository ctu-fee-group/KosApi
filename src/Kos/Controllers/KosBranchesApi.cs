//
//   KosBranchesApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Atom;
using Kos.Data;
using Kos.Extensions;

namespace Kos.Controllers
{
    /// <inheritdoc />
    public class KosBranchesApi : IKosBranchesApi
    {
        private IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosBranchesApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosBranchesApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Branch>> GetBranches
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Branch>("branches", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Branch?> GetBranch(string id, string? lang = null, CancellationToken token = default)
            => GetBranch(new AtomLoadableEntity<Branch> { Href = $"branches/{id}" }, lang, token);

        /// <inheritdoc />
        public Task<Branch?> GetBranch
            (AtomLoadableEntity<Branch> branchLoadableEntity, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync(branchLoadableEntity, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<StudyPlan>> GetBranchStudyPlans
        (
            AtomLoadableEntity<Branch> branchLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<StudyPlan>
                ($"{branchLoadableEntity.Href}/studyPlans", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<StudyPlan>> GetBranchStudyPlans
        (
            string branchId,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            =>
                _atomApi.LoadFeedContentAsync<StudyPlan>
                    ($"branches/{branchId}/studyPlans", query, orderBy, limit, offset, lang, token: token);
    }
}