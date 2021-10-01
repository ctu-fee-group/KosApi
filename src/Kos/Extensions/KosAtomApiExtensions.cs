//
//  KosAtomApiExtensions.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Atom;

namespace Kos.Extensions
{
    /// <summary>
    /// Class containing extensions methods for <see cref="IKosAtomApi"/>.
    /// </summary>
    public static class KosAtomApiExtensions
    {
        /// <summary>
        /// Loads the feed of the given type with the given parameters.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        /// <param name="endpoint">The endpoint of the feed.</param>
        /// <param name="query">The RSQL query for filtering.</param>
        /// <param name="orderBy">The order with parameters separated by a comma. Use "-" for descending order.</param>
        /// <param name="limit">Sets the maximal number of records to return.</param>
        /// <param name="offset">Sets the offset of the first result. orderBy must be set.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="configureBuilder">The builder of query for additional query parameters.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <returns>The list of the found entities.</returns>
        public static async Task<IReadOnlyList<TContent>> LoadFeedContentAsync<TContent>
        (
            this IKosAtomApi atomApi,
            string endpoint,
            string? query = null,
            string orderBy = "id",
            ushort limit = 10,
            int offset = 0,
            string? lang = null,
            Action<AtomFeedQueryBuilder>? configureBuilder = null,
            CancellationToken token = default
        )
            where TContent : class, new()
            => (IReadOnlyList<TContent>?)(await atomApi.LoadFeedAsync<TContent>
               (
                   endpoint,
                   builder =>
                   {
                       builder.WithLimit(limit);
                       builder.WithOffset(offset);
                       builder.WithOrderBy(orderBy);

                       if (query is not null)
                       {
                           builder.WithQuery(query);
                       }

                       if (lang is not null)
                       {
                           builder.WithLanguage(lang);
                       }

                       configureBuilder?.Invoke(builder);
                   },
                   token
               ))?.Entries.Select(x => x.Content)
               .ToList() ??
               Array.Empty<TContent>();

        /// <summary>
        /// Loads the entity's content with the given language.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        /// <param name="loadableEntity">The loadable entity.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="configureBuilder">The builder of query for additional query parameters.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <returns>The loaded content. Null if not found.</returns>
        public static Task<TContent?> LoadEntityContentAsync<TContent>
        (
            this IKosAtomApi atomApi,
            AtomLoadableEntity<TContent> loadableEntity,
            string? lang = null,
            Action<AtomEntryQueryBuilder>? configureBuilder = null,
            CancellationToken token = default
        )
            where TContent : class, new()
            => LoadEntityContentAsync<TContent>(atomApi, loadableEntity.Href, lang, configureBuilder, token);

        /// <summary>
        /// Loads the entity's content with the given language.
        /// </summary>
        /// <param name="atomApi">The atom api.</param>
        /// <param name="endpoint">The endpoint to load from.</param>
        /// <param name="lang">The request language. Supports cs or en.</param>
        /// <param name="configureBuilder">The builder of query for additional query parameters.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <returns>The loaded content. Null if not found.</returns>
        public static async Task<TContent?> LoadEntityContentAsync<TContent>
        (
            this IKosAtomApi atomApi,
            string endpoint,
            string? lang = null,
            Action<AtomEntryQueryBuilder>? configureBuilder = null,
            CancellationToken token = default
        )
            where TContent : class, new()
            => (await atomApi.LoadEntryAsync<TContent>
            (
                endpoint,
                builder =>
                {
                    if (lang is not null)
                    {
                        builder.WithLanguage(lang);
                    }

                    configureBuilder?.Invoke(builder);
                },
                token
            ))?.Content;
    }
}