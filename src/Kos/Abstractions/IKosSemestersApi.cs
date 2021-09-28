//
//   IKosSemestersApi.cs
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
    /// Represents mapping to semesters kos api.
    /// </summary>
    public interface IKosSemestersApi
    {
        /// <summary>
        /// Gets paged semesters filtered using RSQL query.
        /// </summary>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded semesters.</returns>
        public Task<IReadOnlyList<Semester>> GetSemesters
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets semester by its code. <see cref="SemesterFilter"/> for creating codes of specific semesters.
        /// </summary>
        /// <param name="code">The code of the semester.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded semester.</returns>
        public Task<Semester?> GetSemester
        (
            string code,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets semester by loadable entity.
        /// </summary>
        /// <param name="semesterLoadableEntity">The loadable entity.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded semester.</returns>
        public Task<Semester?> GetSemester
        (
            AtomLoadableEntity<Semester> semesterLoadableEntity,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets the current semester.
        /// </summary>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded semester.</returns>
        public Task<Semester?> GetCurrentSemester
        (
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets the next semester.
        /// </summary>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded semester.</returns>
        public Task<Semester?> GetNextSemester
        (
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets the previous semester.
        /// </summary>m
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded semester.</returns>
        public Task<Semester?> GetPreviousSemester
        (
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets the scheduling semester.
        /// </summary>
        /// <remarks>
        /// The scheduling semester is the one that is currently in enrollment/registration for the current students.
        /// </remarks>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded semester.</returns>
        public Task<Semester?> GetSchedulingSemester
        (
            string? lang = null,
            CancellationToken token = default
        );
    }
}