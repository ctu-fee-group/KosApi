//
//   ThesisDraft.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos thesis draft entity.
    /// </summary>
    /// <param name="Branch">The branch the thesis is for. If null, it is for everyone.</param>
    /// <param name="Creator">The creator of the thesis draft.</param>
    /// <param name="Department">The department that created the thesis draft.</param>
    /// <param name="Description">The description of the thesis.</param>
    /// <param name="Name">The name of the thesis.</param>
    /// <param name="Type">The type of the programme the thesis is for.</param>
    [XmlType("thesisdraft", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record ThesisDraft
    (
        [property: XmlElement("branch")] AtomLoadableEntity<Branch>? Branch,
        [property: XmlElement("creator")] AtomLoadableEntity<Person>? Creator,
        [property: XmlElement("department")] AtomLoadableEntity<Division>? Department,
        [property: XmlElement("description")] string? Description,
        [property: XmlElement("name")] string Name,
        [property: XmlElement("type")] ProgrammeType Type
    ) : KosContent;
}