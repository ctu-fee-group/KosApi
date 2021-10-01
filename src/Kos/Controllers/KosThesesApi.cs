//
//   KosThesesApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Atom;
using Kos.Data;
using Kos.Extensions;

namespace Kos.Controllers
{
    /// <inheritdoc />
    public class KosThesesApi : IKosThesesApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosThesesApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosThesesApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Thesis>> GetTheses
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Thesis>("theses", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Thesis?> GetThesis
            (string id, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Thesis>($"theses/{id}", lang, token: token);

        /// <inheritdoc />
        public Task<Thesis?> GetThesis
            (AtomLoadableEntity<Thesis> thesisLoadableEntity, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Thesis>(thesisLoadableEntity.Href, lang, token: token);
    }
}