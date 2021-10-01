//
//   KosPathwaysApi.cs
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
    public class KosPathwaysApi : IKosPathwaysApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosPathwaysApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosPathwaysApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Pathway>> GetPathways
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Pathway>("pathways", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Pathway?> GetPathway
            (string id, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Pathway>($"pathways/{id}", lang, token: token);
    }
}