//
//   KosProgrammesApi.cs
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
    public class KosProgrammesApi : IKosProgrammesApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosProgrammesApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosProgrammesApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Programme>> GetProgrammes
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Programme>
                ("programmes", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Programme?> GetProgramme
            (string code, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Programme>($"programmes/{code}", lang, token: token);

        /// <inheritdoc />
        public Task<Programme?> GetProgramme
        (
            AtomLoadableEntity<Programme> programmeLoadableEntity,
            string? lang = null,
            CancellationToken token = default
        ) => _atomApi.LoadEntityContentAsync<Programme>(programmeLoadableEntity, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Branch>> GetProgrammeBranches
        (
            string programmeCode,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Branch>
                ($"programmes/{programmeCode}/branches", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Branch>> GetProgrammeBranches
        (
            AtomLoadableEntity<Programme> programmeLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Branch>
                ($"{programmeLoadableEntity.Href}branches", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Course>> GetProgrammeCourses
        (
            string programmeCode,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Course>
                ($"programmes/{programmeCode}/courses", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Course>> GetProgrammeCourses
        (
            AtomLoadableEntity<Programme> programmeLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Course>
                ($"{programmeLoadableEntity}/courses", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<CoursesGroup>> GetProgrammeCoursesGroups
        (
            string programmeCode,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CoursesGroup>
                ($"programmes/{programmeCode}/coursesGroups", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<CoursesGroup>> GetProgrammeCoursesGroups
        (
            AtomLoadableEntity<Programme> programmeLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CoursesGroup>
                ($"{programmeLoadableEntity}/coursesGroups", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<StudyPlan>> GetProgrammeStudyPlans
        (
            string programmeCode,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<StudyPlan>
                ($"programmes/{programmeCode}/studyPlans", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<StudyPlan>> GetProgrammeStudyPlans
        (
            AtomLoadableEntity<Programme> programmeLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<StudyPlan>
                ($"{programmeLoadableEntity}/studyPlans", query, orderBy, limit, offset, lang, token: token);
    }
}