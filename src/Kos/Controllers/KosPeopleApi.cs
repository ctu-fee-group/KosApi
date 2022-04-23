//
//  KosPeopleApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Atom;
using Kos.Data;
using Kos.Extensions;
using Microsoft.Extensions.Logging;

namespace Kos.Controllers
{
    /// <inheritdoc />
    public class KosPeopleApi : IKosPeopleApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosPeopleApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api used for loading entities.</param>
        public KosPeopleApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Person>> GetPeopleAsync
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Person>("people", query, orderBy, limit, offset, null, token: token);

        /// <inheritdoc />
        public async Task<Person?> GetPersonAsync
            (string username, CancellationToken token = default)
            => (await _atomApi.LoadEntryAsync<Person>
            (
                $"people/{username}",
                token: token
            ))?.Content;

        /// <inheritdoc />
        public async Task<Person?> GetPersonAsync
            (AtomLoadableEntity<Person> loadableEntity, CancellationToken token = default)
            => (await _atomApi.LoadEntryAsync
            (
                loadableEntity,
                token: token
            ))?.Content;
    }
}