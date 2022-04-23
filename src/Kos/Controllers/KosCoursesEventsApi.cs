//
//   KosCoursesEventsApi.cs
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
    public class KosCoursesEventsApi : IKosCourseEventsApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosCoursesEventsApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosCoursesEventsApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<CourseEvent>> GetCourseEvents
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CourseEvent>
                ("courseEvents", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<CourseEvent?> GetCourseEvent(string id, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<CourseEvent>
                ($"courseEvents/{id}", lang, token: token);

        /// <inheritdoc />
        public Task<IReadOnlyList<CourseEvent>> GetCourseEventAttendees
        (
            string courseEventId,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CourseEvent>
                ($"courseEvents/{courseEventId}/attendees", query, orderBy, limit, offset, lang, token: token);
    }
}