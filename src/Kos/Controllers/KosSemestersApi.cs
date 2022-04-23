//
//   KosSemestersApi.cs
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
    public class KosSemestersApi : IKosSemestersApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosSemestersApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosSemestersApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Semester>> GetSemesters
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Semester>("semesters", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Semester?> GetSemester(string code, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Semester>($"semesters/{code}", lang, token: token);

        /// <inheritdoc />
        public Task<Semester?> GetSemester
        (
            AtomLoadableEntity<Semester> semesterLoadableEntity,
            string? lang = null,
            CancellationToken token = default
        ) => _atomApi.LoadEntityContentAsync<Semester>(semesterLoadableEntity, lang, token: token);

        /// <inheritdoc />
        public Task<Semester?> GetCurrentSemester
            (string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Semester>("semesters/current", lang, token: token);

        /// <inheritdoc />
        public Task<Semester?> GetNextSemester
            (string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Semester>("semesters/next", lang, token: token);

        /// <inheritdoc />
        public Task<Semester?> GetPreviousSemester
            (string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Semester>("semesters/prev", lang, token: token);

        /// <inheritdoc />
        public Task<Semester?> GetSchedulingSemester
            (string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Semester>("semesters/scheduling", lang, token: token);
    }
}