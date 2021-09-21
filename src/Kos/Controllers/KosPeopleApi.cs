//
//  KosPeopleApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Atom;
using Kos.Data;
using Microsoft.Extensions.Logging;

namespace Kos.Controllers
{
    /// <inheritdoc />
    public class KosPeopleApi : IKosPeopleApi
    {
        private readonly IKosAtomApi _atomApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="KosPeopleApi"/> class.
        /// </summary>
        /// <param name="atomApi">The atom api used for loading entities.</param>
        public KosPeopleApi(IKosAtomApi atomApi)
        {
            _atomApi = atomApi;
        }

        /// <inheritdoc />
        public Task<KosPerson?> GetPersonAsync
            (string username, CancellationToken token = default) => _atomApi.LoadEntityAsync<KosPerson>
        (
            new AtomLoadableEntity<KosPerson>()
            {
                Href = $"people/{username}",
                Title = null
            },
            token
        );
    }
}