//
//   Pathway.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos pathway entity.
    /// </summary>
    /// <param name="Name">The name of the pathway.</param>
    /// <param name="Note">The note for the pathway.</param>
    /// <param name="StudyPlan">The study plan that this pathway is for.</param>
    [XmlType("pathway", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Pathway
    (
        [property: XmlElement("name")] string? Name,
        [property: XmlElement("note")] string? Note,
        [property: XmlElement("studyPlan")] AtomLoadableEntity<StudyPlan>? StudyPlan
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pathway"/> class.
        /// </summary>
        public Pathway()
            : this(default, default, default)
        {
        }
    }
}