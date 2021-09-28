//
//  Branch.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos branch entity.
    /// </summary>
    /// <param name="Abbreviation">The abbreviation of the branch.</param>
    /// <param name="Capacity">The branch capacity.</param>
    /// <param name="Code">The code of the branch, does not have to be unique.</param>
    /// <param name="Description">The description of the branch.</param>
    /// <param name="DiplomaName">The name that will be printed on the diploma.</param>
    /// <param name="Division">The division that created the branch.</param>
    /// <param name="Guarantor">The guarantor of the branch.</param>
    /// <param name="Name">The name of the branch.</param>
    /// <param name="OpenForAdmission">Whether the branch is open for admissions.</param>
    [XmlType("branch", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Branch
    (
        [property: XmlElement("abbrev")] string? Abbreviation,
        [property: XmlElement("capacity")] uint? Capacity,
        [property: XmlElement("code")] string? Code,
        [property: XmlElement("description")] string? Description,
        [property: XmlElement("diplomaName")] string? DiplomaName,
        [property: XmlElement("division")] AtomLoadableEntity<Division>? Division,
        [property: XmlElement("guarantor")] AtomLoadableEntity<Person>? Guarantor,
        [property: XmlElement("name")] string? Name,
        [property: XmlElement("openForAdmission")]
        bool? OpenForAdmission
    )
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Branch"/> class.
        /// </summary>
        public Branch()
            : this(default!, default!, default!, default!, default!, default!, default!, default!, default!)
        {
        }
    }
}