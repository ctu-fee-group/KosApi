//
//  IKosAtomApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;

namespace Kos
{
    /// <summary>
    /// Represents default Atom Api that supports loading <see cref="AtomEntry{TContent}"/>.
    /// </summary>
    public interface IKosAtomApi
    {
        /// <summary>
        /// Load loadable entity.
        /// </summary>
        /// <remarks>
        /// Loadable entity is usually obtained as a references from another loaded entity.
        /// </remarks>
        /// <param name="kosLoadable">The entity to be loaded.</param>,
        /// <param name="token">The cancellation token for the operation.</param>
        /// <typeparam name="T">The type of the entity that will be loaded.</typeparam>
        /// <returns>The loaded entity. If not found, null.</returns>
        public Task<T?> LoadEntityAsync<T>
        (
            AtomLoadableEntity<T>? kosLoadable,
            CancellationToken token = default
        )
            where T : class, new();
    }
}