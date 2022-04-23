//
//   KosThesesDraftsApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Data;
using Kos.Extensions;

namespace Kos.Controllers
{
    /// <inheritdoc />
    public class KosThesesDraftsApi : IKosThesesDraftsApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosThesesDraftsApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosThesesDraftsApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<ThesisDraft>> GetThesesDrafts
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<ThesisDraft>
                ("thesesDrafts", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<ThesisDraft?> GetThesisDraft
            (string id, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<ThesisDraft>($"thesesDrafts/{id}", lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Student>> GetThesisDraftApplicants
        (
            string id,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Student>
                ($"thesesDrafts/{id}/applicants", query, orderBy, limit, offset, lang, token: token);
    }
}