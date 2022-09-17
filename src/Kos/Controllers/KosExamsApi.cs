//
//   KosExamsApi.cs
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
    public class KosExamsApi : IKosExamsApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosExamsApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosExamsApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Exam>> GetExams
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Exam>("exams", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Exam?> GetExam
            (string id, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Exam>($"exam/{id}", lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Exam>> GetExamAttendees
        (
            string examId,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Exam>
                ($"exams/{examId}/attendees", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Exam?> GetExam
            (AtomLoadableEntity<Exam> examLoadableEntity, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Exam>(examLoadableEntity, lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<Exam>> GetExamAttendees
        (
            AtomLoadableEntity<Exam> examLoadableEntity,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Exam>
                ($"{examLoadableEntity.Href}attendees", query, orderBy, limit, offset, lang, token: token);
    }
}