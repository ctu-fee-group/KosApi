//
//   KosDivisionsApi.cs
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
    public class KosDivisionsApi : IKosDivisionsApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosDivisionsApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosDivisionsApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Division>> GetDivisions
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Division>("divisions", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Division?> GetDivision
            (string code, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Division>($"divisions/{code}", lang, token: token);

        /// <inheritdoc />
        public Task<Division?> GetDivision
            (AtomLoadableEntity<Division> courseLoadableEntity, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync(courseLoadableEntity, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Division>> GetDivisionCourses
        (
            string code,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Division>
                ($"divisions/{code}/courses", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Division>> GetDivisionCourses
        (
            AtomLoadableEntity<Division> courseLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Division>
                ($"{courseLoadableEntity.Href}/courses", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Division>> GetDivisionSubdivisions
        (
            string code,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Division>
                ($"divisions/{code}/subdivisions", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Division>> GetDivisionSubdivisions
        (
            AtomLoadableEntity<Division> subdivisionLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Division>
                ($"{subdivisionLoadableEntity.Href}/subdivisions", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Division>> GetDivisionTeachers
        (
            string code,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Division>
                ($"divisions/{code}/teachers", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Division>> GetDivisionTeachers
        (
            AtomLoadableEntity<Division> teacherLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Division>
                ($"{teacherLoadableEntity.Href}/teachers", query, orderBy, limit, offset, lang, token: token);
    }
}