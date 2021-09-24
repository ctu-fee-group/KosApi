//
//   AtomEntryQueryBuilder.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.Http;

namespace Kos.Atom
{
    /// <summary>
    /// Builder of <see cref="HttpRequestMessage"/> specific for Atom entry options.
    /// </summary>
    public class AtomEntryQueryBuilder : RequestQueryBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AtomEntryQueryBuilder"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint of the request.</param>
        /// <param name="method">The method for the request.</param>
        public AtomEntryQueryBuilder(string endpoint, HttpMethod method)
            : base(endpoint, method)
        {
        }

        /// <summary>
        /// Sets the language parameter. Supported values: "cs", "en".
        /// </summary>
        /// <param name="language">The language to set, either cs or en.</param>
        /// <returns>The builder.</returns>
        public AtomEntryQueryBuilder WithLanguage(string language)
        {
            AddParameter("lang", language);
            return this;
        }
    }
}