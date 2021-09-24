//
//  KosApiOptions.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Kos.Abstractions;
using Microsoft.Extensions.Options;

namespace Kos
{
    /// <summary>
    /// Options for <see cref="IKosAtomApi"/>.
    /// </summary>
    public class KosApiOptions : IOptionsSnapshot<KosApiOptions>
    {
        /// <summary>
        /// Gets or sets the url of the Api.
        /// </summary>
        public string? BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the indicator whether to throw on server errors.
        /// </summary>
        /// <remarks>
        /// If false, the faulty value will be logger.
        /// </remarks>
        public bool ThrowOnError { get; set; } = true;

        /// <inheritdoc />
        public KosApiOptions Value => this;

        /// <inheritdoc />
        public KosApiOptions Get(string name)
        {
            return Value;
        }
    }
}