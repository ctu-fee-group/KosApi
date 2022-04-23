//
//   IKosTeachersApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.Data;
using Kos.Filters;

namespace Kos.Abstractions
{
    /// <summary>
    /// Represents mapping to teachers kos api.
    /// </summary>
    public interface IKosTeachersApi
    {
        /// <summary>
        /// Gets paged teachers filtered using RSQL query.
        /// </summary>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded teachers.</returns>
        public Task<IReadOnlyList<Teacher>> GetTeachers
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets teacher by its study code or id.
        /// </summary>
        /// <param name="usernameOrId">The username or id of the teacher.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded teacher.</returns>
        public Task<Teacher?> GetTeacher
        (
            string usernameOrId,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets teacher by loadable entity.
        /// </summary>
        /// <param name="teacherLoadableEntity">The teacher loadable entity.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded teacher.</returns>
        public Task<Teacher?> GetTeacher
        (
            AtomLoadableEntity<Teacher> teacherLoadableEntity,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets teacher's courses by teacher's username or id.
        /// </summary>
        /// <remarks>
        /// Returns courses that the teacher examines, guarantees, lectures or instructs.
        /// </remarks>
        /// <param name="usernameOrId">The username or id of the teacher.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded teacher.</returns>
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
        );

        /// <summary>
        /// Gets teacher's courses by teacher loadable entity.
        /// </summary>
        /// <remarks>
        /// Returns courses that the teacher examines, guarantees, lectures or instructs.
        /// </remarks>
        /// <param name="teacherLoadableEntity">The teacher loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded teacher.</returns>
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
        );

        /// <summary>
        /// Gets teacher's exams by teacher's username or id.
        /// </summary>
        /// <param name="usernameOrId">The username or id of the teacher.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded teacher.</returns>
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
        );

        /// <summary>
        /// Gets teacher's exams by teacher loadable entity.
        /// </summary>
        /// <param name="teacherLoadableEntity">The teacher loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded teacher.</returns>
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
        );

        // TODO figure out return type of GET /teachers/{usernameOrId}. Seems like it is not used on FEE.
        /*
        /// <summary>
        /// Gets teacher's timetables by teacher's username or id.
        /// </summary>
        /// <param name="usernameOrId">The username or id of the teacher.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded teacher.</returns>
        public Task<IReadOnlyList<TimetableSlot>> GetTeacherTimetables
        (
            string usernameOrId,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets teacher's timetables by teacher loadable entity.
        /// </summary>
        /// <param name="teacherLoadableEntity">The teacher loadable entity.</param>
        /// <param name="semester">Filter for a specific semester(s). <see cref="SemesterFilter"/> or check the documentation of kos api.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded teacher.</returns>
        public Task<IReadOnlyList<TimetableSlot>> GetTeacherTimetables
        (
            AtomLoadableEntity<Teacher> teacherLoadableEntity,
            string? semester = null,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );*/
    }
}