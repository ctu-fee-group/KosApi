//
//   KosParallelsApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Data;
using Kos.Extensions;
using Parallel = Kos.Data.Parallel;

namespace Kos.Controllers
{
    /// <inheritdoc />
    public class KosParallelsApi : IKosParallelsApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosParallelsApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosParallelsApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Parallel>> GetParallels
        (
            string? query = null,
            bool includeInvalidSlots = false,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Parallel>
            (
                "parallels",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    builder.AddParameter
                    (
                        "includeInvalidSlots",
                        includeInvalidSlots ? "1" : "0"
                    );
                },
                token
            );

        /// <inheritdoc />
        public Task<Parallel?> GetParallel
        (
            string id,
            bool includeInvalidSlots = false,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadEntityContentAsync<Parallel>
            (
                $"parallels/{id}",
                lang,
                builder =>
                {
                    builder.AddParameter
                    (
                        "includeInvalidSlots",
                        includeInvalidSlots ? "1" : "0"
                    );
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Parallel>> GetRelatedParallels
        (
            string parallelId,
            string? query = null,
            bool includeInvalidSlots = false,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Parallel>
            (
                $"parallels/{parallelId}/related",
                query,
                orderBy,
                limit,
                offset,
                lang,
                builder =>
                {
                    builder.AddParameter
                    (
                        "includeInvalidSlots",
                        includeInvalidSlots ? "1" : "0"
                    );
                },
                token
            );

        /// <inheritdoc />
        public Task<IReadOnlyList<Student>> GetParallelStudents
        (
            string parallelId,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Student>
            (
                $"parallels/{parallelId}/students",
                query,
                orderBy,
                limit,
                offset,
                lang,
                token: token
            );
    }
}