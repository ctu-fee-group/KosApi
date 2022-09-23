//
//   KosStudentsApi.cs
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
using Parallel = Kos.Data.Parallel;

namespace Kos.Controllers
{
    /// <inheritdoc />
    public class KosStudentsApi : IKosStudentsApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosStudentsApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosStudentsApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Student>> GetStudents
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Student>
            (
                "students",
                query,
                orderBy,
                limit,
                offset,
                lang,
                token: token
            );

        /// <inheritdoc />
        public Task<Student?> GetStudent
            (string studyCodeOrId, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Student>($"students/{studyCodeOrId}", lang, token: token);

        /// <inheritdoc />
        public Task<Student?> GetStudent
            (AtomLoadableEntity<Student> studentLoadableEntity, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync(studentLoadableEntity, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<CourseEnrollment>> GetStudentEnrolledCourses
        (
            string studyCodeOrId,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CourseEnrollment>
            (
                $"students/{studyCodeOrId}/enrolledCourses",
                query,
                orderBy,
                limit,
                offset,
                lang,
                b =>
                {
                    if (semester is not null)
                    {
                        b.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<CourseEnrollment>> GetStudentEnrolledCourses
        (
            AtomLoadableEntity<Student> studentLoadableEntity,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CourseEnrollment>
            (
                $"{studentLoadableEntity.Href}enrolledCourses",
                query,
                orderBy,
                limit,
                offset,
                lang,
                b =>
                {
                    if (semester is not null)
                    {
                        b.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Parallel>> GetStudentParallels
        (
            string studyCodeOrId,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Parallel>
            (
                $"students/{studyCodeOrId}/parallels",
                query,
                orderBy,
                limit,
                offset,
                lang,
                b =>
                {
                    if (semester is not null)
                    {
                        b.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Parallel>> GetStudentParallels
        (
            AtomLoadableEntity<Student> studentLoadableEntity,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Parallel>
            (
                $"{studentLoadableEntity.Href}parallels",
                query,
                orderBy,
                limit,
                offset,
                lang,
                b =>
                {
                    if (semester is not null)
                    {
                        b.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<ExamRegistration>> GetStudentRegisteredExams
        (
            string studyCodeOrId,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<ExamRegistration>
            (
                $"students/{studyCodeOrId}/registeredExams",
                query,
                orderBy,
                limit,
                offset,
                lang,
                b =>
                {
                    if (semester is not null)
                    {
                        b.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<ExamRegistration>> GetStudentRegisteredExams
        (
            AtomLoadableEntity<Student> studentLoadableEntity,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<ExamRegistration>
            (
                $"{studentLoadableEntity}/registeredExams",
                query,
                orderBy,
                limit,
                offset,
                lang,
                b =>
                {
                    if (semester is not null)
                    {
                        b.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Exam>> GetStudentExams
        (
            string studyCodeOrId,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Exam>
            (
                $"students/{studyCodeOrId}/exams",
                query,
                orderBy,
                limit,
                offset,
                lang,
                b =>
                {
                    if (semester is not null)
                    {
                        b.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Exam>> GetStudentExams
        (
            AtomLoadableEntity<Student> studentLoadableEntity,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Exam>
            (
                $"{studentLoadableEntity}/exams",
                query,
                orderBy,
                limit,
                offset,
                lang,
                b =>
                {
                    if (semester is not null)
                    {
                        b.AddParameter("sem", semester);
                    }
                },
                token
            );
    }
}