//
//   KosCoursesGroupsApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Data;
using Kos.Extensions;

namespace Kos.Controllers
{
    /// <inheritdoc />
    public class KosCoursesGroupsApi : IKosCoursesGroupsApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosCoursesGroupsApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosCoursesGroupsApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<CoursesGroup>> GetCoursesGroups
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<CoursesGroup>
                ("coursesGroups", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<CoursesGroup?> GetCoursesGroup
            (string code, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<CoursesGroup>($"coursesGroups/{code}", lang, token: token);
    }
}