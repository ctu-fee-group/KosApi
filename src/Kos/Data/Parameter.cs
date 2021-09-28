//
//  Parameter.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos parameter entity.
    /// </summary>
    /// <param name="Description">The description of the parameter.</param>
    /// <param name="Key">The key of the parameter. Consists of code of the faculty, name of the constant, sometimes with type of the programme.</param>
    /// <param name="Value">The value of the parameter.</param>
    [XmlType("parameter", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Parameter
    (
        [property: XmlElement("description")] string? Description,
        [property: XmlElement("key")] string? Key,
        [property: XmlElement("value")] string? Value
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        public Parameter()
            : this
            (
                default!,
                default!,
                default!
            )
        {
        }
    }
}