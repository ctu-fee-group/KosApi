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
        public async Task<IReadOnlyList<Person>> GetPeopleAsync
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            CancellationToken token = default
        )
            => (IReadOnlyList<Person>?)(await _atomApi.LoadFeedAsync<Person>
               (
                   "people",
                   builder =>
                   {
                       builder.WithLimit(limit);
                       builder.WithOffset(offset);
                       builder.WithOrderBy(orderBy);

                       if (query is not null)
                       {
                           builder.WithQuery(query);
                       }
                   },
                   token
               ))?.Entries.Select(x => x.Content).ToList() ??
               Array.Empty<Person>();

        /// <inheritdoc />
        public Task<Person?> GetPersonAsync
            (string username, CancellationToken token = default)
            => GetPersonAsync
            (
                new AtomLoadableEntity<Person>
                {
                    Href = $"people/{username}",
                    Title = null,
                },
                token
            );

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