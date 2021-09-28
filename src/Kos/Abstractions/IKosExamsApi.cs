//
//   IKosExamsApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.Data;

namespace Kos.Abstractions
{
    /// <summary>
    /// Represents mapping to kos exam api.
    /// </summary>
    public interface IKosExamsApi
    {
        /// <summary>
        /// Gets paged exams filtered using RSQL query.
        /// </summary>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded exams.</returns>
        public Task<IReadOnlyList<Exam>> GetExams
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets exam by its id.
        /// </summary>
        /// <param name="id">The id of the exam.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded exam.</returns>
        public Task<Exam?> GetExam
        (
            string id,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets paged exam's attendees by exam id filtered using RSQL query.
        /// </summary>
        /// <param name="examId">The id of the course.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course events.</returns>
        public Task<IReadOnlyList<Exam>> GetExamAttendees
        (
            string examId,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets exam by loadable exam entity.
        /// </summary>
        /// <param name="examLoadableEntity">The loadable entity of an exam.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded exam.</returns>
        public Task<Exam?> GetExam
        (
            AtomLoadableEntity<Exam> examLoadableEntity,
            string? lang = null,
            CancellationToken token = default
        );

        /// <summary>
        /// Gets paged exam's attendees by loadable exam entity filtered using RSQL query.
        /// </summary>
        /// <param name="examLoadableEntity">The loadable entity of an exam.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>The loaded course events.</returns>
        public Task<IReadOnlyList<Exam>> GetExamAttendees
        (
            AtomLoadableEntity<Exam> examLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        );
    }
}