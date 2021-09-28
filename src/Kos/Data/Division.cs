//
//  Division.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos division entity.
    /// </summary>
    /// <param name="Abbreviation">The abbreviation of the division.</param>
    /// <param name="Code">The division code.</param>
    /// <param name="Name">The name of the division.</param>
    /// <param name="Parent">The parent division, if any.</param>
    /// <param name="Type">The type of the kos division.</param>
    [XmlType("division", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Division
    (
        [property: XmlElement("abbrev")] string? Abbreviation,
        [property: XmlElement("code")] string Code,
        [property: XmlElement("name")] string Name,
        [property: XmlElement("parent")] AtomLoadableEntity<Division>? Parent,
        [property: XmlElement("divisionType")] DivisionType Type
    )
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Division"/> class.
        /// </summary>
        public Division()
            : this(default!, default!, default!, default!, default!)
        {
        }
    }
}