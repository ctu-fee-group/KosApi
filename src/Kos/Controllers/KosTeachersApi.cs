//
//   KosTeachersApi.cs
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
    public class KosTeachersApi : IKosTeachersApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosTeachersApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosTeachersApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Teacher>> GetTeachers
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Teacher>("teachers", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Teacher?> GetTeacher
            (string usernameOrId, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Teacher>($"teachers/{usernameOrId}", lang, token: token);

        /// <inheritdoc />
        public Task<Teacher?> GetTeacher
            (AtomLoadableEntity<Teacher> teacherLoadableEntity, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Teacher>(teacherLoadableEntity, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Course>> GetTeacherCourses
        (
            string usernameOrId,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Course>
                ($"teachers/{usernameOrId}/courses", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Course>> GetTeacherCourses
        (
            AtomLoadableEntity<Teacher> teacherLoadableEntity,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Course>
                ($"{teacherLoadableEntity.Href}/courses", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Exam>> GetTeacherExams
        (
            string usernameOrId,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Exam>
                ($"teachers/{usernameOrId}/exams", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Exam>> GetTeacherExams
        (
            AtomLoadableEntity<Teacher> teacherLoadableEntity,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Exam>
                ($"{teacherLoadableEntity.Href}/exams", query, orderBy, limit, offset, lang, token: token);
    }
}