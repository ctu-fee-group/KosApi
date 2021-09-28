//
//   StudyPlan.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    [XmlType("studyplan", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record StudyPlan
    (
        [property: XmlElement("approvalDate")] DateTime? ApprovalDate,
        [property: XmlElement("approved")] bool? Approved,
        [property: XmlElement("branch")] AtomLoadableEntity<Branch>? Branch,
        [property: XmlElement("code")] string? Code,
        [property: XmlElement("creditsMinLimit")]
        ushort? CreditsMinLimit,
        [property: XmlElement("division")] AtomLoadableEntity<Division>? Division,
        [property: XmlElement("individual")] bool? Individual,
        [property: XmlElement("name")] string Name,
        [property: XmlElement("note")] string? Note,
        [property: XmlElement("programme")] AtomLoadableEntity<Programme>? Programme,
        [property: XmlElement("studyForm")] StudyForm StudyForm
    )
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudyPlan"/> class.
        /// </summary>
        public StudyPlan()
            : this
            (
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!
            )
        {
        }
    }
}