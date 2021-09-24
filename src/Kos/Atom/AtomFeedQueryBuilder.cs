//
//   AtomFeedQueryBuilder.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Net.Http;

namespace Kos.Atom
{
    /// <summary>
    /// Builder of <see cref="HttpRequestMessage"/> specific for Atom feed options.
    /// </summary>
    public class AtomFeedQueryBuilder : RequestQueryBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AtomFeedQueryBuilder"/> class.
        /// </summary>
        /// <param name="endpoint">The rest endpoint.</param>
        /// <param name="method">The method of the request.</param>
        public AtomFeedQueryBuilder(string endpoint, HttpMethod method)
            : base(endpoint, method)
        {
        }

        /// <summary>
        /// Sets the language parameter. Supported values: "cs", "en".
        /// </summary>
        /// <param name="language">The language to set, either cs or en.</param>
        /// <returns>The builder.</returns>
        public AtomFeedQueryBuilder WithLanguage(string language)
        {
            AddParameter("lang", language);
            return this;
        }

        /// <summary>
        /// Sets the offset parameter. Supports values from 0 to 2 147 483 647.
        /// </summary>
        /// <remarks>
        /// Use orderBy if you want to use this parameter.
        /// The api does not enforce order by default.
        /// </remarks>
        /// <param name="offset">The offset of the first element.</param>
        /// <returns>The builder.</returns>
        public AtomFeedQueryBuilder WithOffset(int offset)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            AddParameter("offset", offset.ToString());
            return this;
        }

        /// <summary>
        /// Sets the limit parameter. Supports values from 1 to 1 000.
        /// </summary>
        /// <remarks>
        /// Use orderBy if you want to use this parameter.
        /// The api does not enforce order by default.
        /// </remarks>
        /// <param name="limit">The limit of the elements to retrieve.</param>
        /// <returns>The builder.</returns>
        public AtomFeedQueryBuilder WithLimit(ushort limit)
        {
            if (limit is < 1 or > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            AddParameter("limit", limit.ToString());
            return this;
        }

        /// <summary>
        /// Sets the orderBy parameter.
        /// </summary>
        /// <remarks>
        /// Supports parameters separated by comma.
        /// Prefix the fields with "-" for descending order.
        /// </remarks>
        /// <param name="orderBy">The order by to set.</param>
        /// <returns>The builder.</returns>
        public AtomFeedQueryBuilder WithOrderBy(string orderBy)
        {
            AddParameter("orderBy", orderBy);
            return this;
        }

        /// <summary>
        /// Sets the query parameter.
        /// </summary>
        /// <remarks>
        /// Uses RSQL.
        /// </remarks>
        /// <param name="query">The query to filter with.</param>
        /// <returns>The builder.</returns>
        public AtomFeedQueryBuilder WithQuery(string query)
        {
            AddParameter("query", query);
            return this;
        }
    }
}