//
//   RequestQueryBuilder.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Web;

namespace Kos.Atom
{
    /// <summary>
    /// Builder for <see cref="HttpRequestMessage"/>.
    /// </summary>
    public class RequestQueryBuilder
    {
        private readonly NameValueCollection _query;
        private readonly HttpMethod _method;
        private readonly string _endpoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestQueryBuilder"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint of the request.</param>
        /// <param name="method">The method for the request.</param>
        public RequestQueryBuilder(string endpoint, HttpMethod method)
        {
            _endpoint = endpoint;
            _method = method;
            _query = HttpUtility.ParseQueryString(string.Empty);
        }

        /// <summary>
        /// Adds the specified query parameter.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>The builder.</returns>
        public RequestQueryBuilder AddParameter(string key, string value)
        {
            _query[key] = value;
            return this;
        }

        /// <summary>
        /// Builds the request message itself.
        /// </summary>
        /// <returns>The built message.</returns>
        public HttpRequestMessage Build() => new HttpRequestMessage
        (
            _method,
            _endpoint + (_query.Count > 0 ? ("?" + _query) : string.Empty)
        );
    }
}