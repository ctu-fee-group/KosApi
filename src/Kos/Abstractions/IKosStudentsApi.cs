//
//   IKosStudentsApi.cs
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
    /// Represents mapping to students kos api.
    /// </summary>
    public interface IKosStudentsApi
    {
        /// <summary>
        /// Gets paged students filtered using RSQL query.
        /// </summary>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded students.</returns>
        public Task<IReadOnlyList<Student>> GetStudents
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets student by its study code or id.
        /// </summary>
        /// <param name="studyCodeOrId">The study code or id of the student.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded student.</returns>
        public Task<Student?> GetStudent
        (
            string studyCodeOrId,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets student by loadable entity.
        /// </summary>
        /// <param name="studentLoadableEntity">The student loadable entity.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded student.</returns>
        public Task<Student?> GetStudent
        (
            AtomLoadableEntity<Student> studentLoadableEntity,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets enrolled courses by student's study code or id.
        /// </summary>
        /// <param name="studyCodeOrId">The study code or id of the student.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded enrolled courses.</returns>
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
        );

        /// <summary>
        /// Gets enrolled courses by student loadable entity.
        /// </summary>
        /// <param name="studentLoadableEntity">The student loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded enrolled courses.</returns>
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
        );

        /// <summary>
        /// Gets parallels by student's study code or id.
        /// </summary>
        /// <param name="studyCodeOrId">The study code or id of the student.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded parallels.</returns>
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
        );

        /// <summary>
        /// Gets parallels by student loadable entity.
        /// </summary>
        /// <param name="studentLoadableEntity">The student loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded parallels.</returns>
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
        );

        /// <summary>
        /// Gets registered exams by student's study code or id.
        /// </summary>
        /// <param name="studyCodeOrId">The study code or id of the student.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded registered exams.</returns>
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
        );

        /// <summary>
        /// Gets registered exams by student loadable entity.
        /// </summary>
        /// <param name="studentLoadableEntity">The student loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded registered exams.</returns>
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
        );

        /// <summary>
        /// Gets exams by student's study code or id.
        /// </summary>
        /// <param name="studyCodeOrId">The study code or id of the student.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded exams.</returns>
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
        );

        /// <summary>
        /// Gets exams by student loadable entity.
        /// </summary>
        /// <param name="studentLoadableEntity">The student loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded exams.</returns>
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
        );
    }
}