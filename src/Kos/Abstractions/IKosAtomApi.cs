//
//  IKosAtomApi.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;

namespace Kos.Abstractions
{
    /// <summary>
    /// Represents default Atom Api that supports loading <see cref="AtomEntry{TContent}"/>.
    /// </summary>
    public interface IKosAtomApi
    {
        /// <summary>
        /// Load the given loadable entry from the api.
        /// </summary>
        /// <remarks>
        /// Loadable entry is usually obtained as a reference from another loaded entry.
        /// </remarks>
        /// <param name="kosLoadable">The entity to be loaded.</param>,
        /// <param name="configureRequest">Action for configuring the request.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <typeparam name="T">The type of the entity that will be loaded.</typeparam>
        /// <returns>The loaded entity. If not found, null.</returns>
        public Task<AtomEntry<T>?> LoadEntryAsync<T>
        (
            AtomLoadableEntity<T>? kosLoadable,
            Action<AtomEntryQueryBuilder>? configureRequest = null,
            CancellationToken token = default
        )
            where T : class, new();

        /// <summary>
        /// Load the feed on the given endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint to retrieve.</param>,
        /// <param name="configureRequest">Action for configuring the request.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <typeparam name="T">The type of the entity that will be located inside of the feed.</typeparam>
        /// <returns>The loaded entity. If not found, null.</returns>
        public Task<AtomFeed<T>?> LoadFeedAsync<T>
        (
            string endpoint,
            Action<AtomFeedQueryBuilder>? configureRequest = null,
            CancellationToken token = default
        )
            where T : class, new();
    }
}