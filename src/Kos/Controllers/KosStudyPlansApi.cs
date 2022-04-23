//
//  KosStudyPlansApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
    public class KosStudyPlansApi : IKosStudyPlansApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosStudyPlansApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosStudyPlansApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<StudyPlan>> GetStudyPlans
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<StudyPlan>
                ("studyPlans", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<StudyPlan?> GetStudyPlan
            (string code, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<StudyPlan>($"studyPlans/{code}", lang, token: token);

        /// <inheritdoc />
        public Task<StudyPlan?> GetStudyPlan
        (
            AtomLoadableEntity<StudyPlan> studyPlanLoadableEntity,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadEntityContentAsync<StudyPlan>(studyPlanLoadableEntity.Href, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<CoursesGroup>> GetStudyPlanCoursesGroups
        (
            string code,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CoursesGroup>
                ($"studyPlans/{code}/coursesGroups", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<CoursesGroup>> GetStudyPlanCoursesGroups
        (
            AtomLoadableEntity<StudyPlan> studyPlanLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CoursesGroup>
                ($"{studyPlanLoadableEntity}/coursesGroups", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Pathway>> GetStudyPlanPathways
        (
            string code,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Pathway>
                ($"studyPlans/{code}/pathways", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Pathway>> GetStudyPlanPathways
        (
            AtomLoadableEntity<StudyPlan> studyPlanLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Pathway>
                ($"{studyPlanLoadableEntity}/coursesGroups", query, orderBy, limit, offset, lang, token: token);
    }
}