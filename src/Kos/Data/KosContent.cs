//
//   KosContent.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Kos.Data
{
    /// <summary>
    /// Represents any kos content with an id.
    /// </summary>
    public record KosContent
    {
        /// <summary>
        /// Gets or sets the id of the record.
        /// </summary>
        public string Id { get; set; }
    }
}