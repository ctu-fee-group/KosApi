//
//   KosParametersApi.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
    public class KosParametersApi : IKosParametersApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosParametersApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        public KosParametersApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<Parameter>> GetParameters
        (
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            CancellationToken token = default
        )
            => _atomApi.LoadFeedContentAsync<Parameter>
                ("parameters", query, orderBy, limit, offset, lang, token: token);

        /// <inheritdoc />
        public Task<Parameter?> GetParameter(string key, string? lang = null, CancellationToken token = default)
            => _atomApi.LoadEntityContentAsync<Parameter>($"parameters/{key}", lang, token: token);
    }
}