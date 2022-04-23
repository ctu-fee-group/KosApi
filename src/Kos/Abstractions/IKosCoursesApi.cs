//
//   IKosCoursesApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.Data;
using Kos.Filters;
using Parallel = Kos.Data.Parallel;

namespace Kos.Abstractions
{
    /// <summary>
    /// Represents mapping to kos courses api.
    /// </summary>
    public interface IKosCoursesApi
    {
        /// <summary>
        /// Gets paged courses filtered using RSQL query.
        /// </summary>
        /// <param name="detail">Whether to show detail fields. (that means description, lectureContents, literature, requirements, tutorialContents).</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded courses.</returns>
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
        );

        /// <summary>
        /// Gets course by its code.
        /// </summary>
        /// <param name="code">The code of the course.</param>
        /// <param name="detail">Whether to show detail fields. (that means description, lectureContents, literature, requirements, tutorialContents).</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course.</returns>
        public Task<Course?> GetCourse
        (
            string code,
            bool detail = false,
            string? semester = null,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets course by loadable entity.
        /// </summary>
        /// <param name="courseLoadableEntity">The course loadable entity.</param>
        /// <param name="detail">Whether to show detail fields. (that means description, lectureContents, literature, requirements, tutorialContents).</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course.</returns>
        public Task<Course?> GetCourse
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
            bool detail = false,
            string? semester = null,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets course events by course's code.
        /// </summary>
        /// <param name="code">The code of the course.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course events.</returns>
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
        );

        /// <summary>
        /// Gets course events by course loadable entity.
        /// </summary>
        /// <param name="courseLoadableEntity">The course loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course events.</returns>
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
        );

        /// <summary>
        /// Gets course exams by course's code.
        /// </summary>
        /// <param name="code">The code of the course.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course exams.</returns>
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
        );

        /// <summary>
        /// Gets course exams by course loadable entity.
        /// </summary>
        /// <param name="courseLoadableEntity">The course loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course exams.</returns>
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
        );

        /// <summary>
        /// Gets course parallels by course's code.
        /// </summary>
        /// <param name="code">The code of the course.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course parallels.</returns>
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
        );

        /// <summary>
        /// Gets course parallels by course loadable entity.
        /// </summary>
        /// <param name="courseLoadableEntity">The course loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course parallels.</returns>
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
        );

        /// <summary>
        /// Gets course students by course's code.
        /// </summary>
        /// <param name="code">The code of the course.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course students.</returns>
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
        );

        /// <summary>
        /// Gets course students by course loadable entity.
        /// </summary>
        /// <param name="courseLoadableEntity">The course loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course students.</returns>
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
        );

        /// <summary>
        /// Gets course instances by course's code.
        /// </summary>
        /// <param name="code">The code of the course.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course instances.</returns>
        public Task<IReadOnlyList<CourseIn>> GetCourseInstances
        (
            string code,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets course instances by course loadable entity.
        /// </summary>
        /// <param name="courseLoadableEntity">The course loadable entity.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course instances.</returns>
        public Task<IReadOnlyList<CourseIn>> GetCourseInstances
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets course branches by course's code.
        /// </summary>
        /// <param name="code">The code of the course.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course branches.</returns>
        public Task<IReadOnlyList<Branch>> GetCourseBranches
        (
            string code,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets course branches by course loadable entity.
        /// </summary>
        /// <param name="courseLoadableEntity">The course loadable entity.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course branches.</returns>
        public Task<IReadOnlyList<Branch>> GetCourseBranches
        (
            AtomLoadableEntity<Course> courseLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );
    }
}