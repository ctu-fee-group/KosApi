//
//   KosCoursesApi.cs
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
    public class KosCoursesApi : IKosCoursesApi
    {
        private IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosCoursesApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosCoursesApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Course>> GetCourses
        (
            bool detail = false,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        ) => _atomApi.LoadFeedContentAsync<Course>
        (
            "courses",
            query,
            orderBy,
            limit,
            offset,
            lang,
            builder =>
            {
                builder.AddParameter
                (
                    "detail",
                    detail ? "1" : "0"
                );

                if (semester is not null)
                {
                    builder.AddParameter("sem", semester);
                }
            },
            token
        );

        /// <inheritdoc />
        public Task<Course?> GetCourse
        (
            string code,
            bool detail = false,
            string? semester = null,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadEntityContentAsync<Course>
            (
                $"courses/{code}",
                lang,
                builder =>
                {
                    builder.AddParameter
                    (
                        "detail",
                        detail ? "1" : "0"
                    );

                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<Course?> GetCourse
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
            bool detail = false,
            string? semester = null,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadEntityContentAsync
            (
                courseLoadableEntity,
                lang,
                builder =>
                {
                    builder.AddParameter
                    (
                        "detail",
                        detail ? "1" : "0"
                    );

                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<CourseEvent>> GetCourseEvents
        (
            string code,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CourseEvent>
            (
                $"courses/{code}/events",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<CourseEvent>> GetCourseEvents
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CourseEvent>
            (
                $"{courseLoadableEntity.Href}/events",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Exam>> GetCourseExams
        (
            string code,
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
                $"courses/{code}/exams",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Exam>> GetCourseExams
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
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
                $"{courseLoadableEntity.Href}/exams",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Parallel>> GetCourseParallels
        (
            string code,
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
                $"courses/{code}/parallels",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Parallel>> GetCourseParallels
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
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
                $"{courseLoadableEntity.Href}/parallels",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Student>> GetCourseStudents
        (
            string code,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Student>
            (
                $"courses/{code}/students",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Student>> GetCourseStudents
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Student>
            (
                $"{courseLoadableEntity.Href}/students",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    if (semester is not null)
                    {
                        builder.AddParameter("sem", semester);
                    }
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<CourseIn>> GetCourseInstances
        (
            string code,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CourseIn>
            (
                $"courses/{code}/instances",
                query,
                orderBy,
                limit,
                offset,
                lang,
                token: token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<CourseIn>> GetCourseInstances
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CourseIn>
            (
                $"{courseLoadableEntity.Href}/instances",
                query,
                orderBy,
                limit,
                offset,
                lang,
                token: token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Branch>> GetCourseBranches
        (
            string code,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Branch>
            (
                $"courses/{code}/branches",
                query,
                orderBy,
                limit,
                offset,
                lang,
                token: token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Branch>> GetCourseBranches
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Branch>
            (
                $"{courseLoadableEntity.Href}/branches",
                query,
                orderBy,
                limit,
                offset,
                lang,
                token: token
            );
    }
}