//
//  KosTeacher.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos teache entity.
    /// </summary>
    /// <param name="Division">The division the teacher is inside of.</param>
    /// <param name="Email">The email of the teacher.</param>
    /// <param name="Extern">Whether the teacher is an external collaborator.</param>
    /// <param name="FirstName">The first name of the teacher.</param>
    /// <param name="LastName">The last name of the teacher.</param>
    /// <param name="PersonalNumber">The personal number of the teacher.</param>
    /// <param name="Phone">The phone of the teacher.</param>
    /// <param name="StageName">The name of the stage the teacher is in.</param>
    /// <param name="TitlesPost">The titles in front of the name.</param>
    /// <param name="TitlesPre">The titles after the name.</param>
    [XmlType("teacher", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record KosTeacher
    (
        [property: XmlElement("division")] AtomLoadableEntity<KosDivision>? Division,
        [property: XmlElement("email")] string? Email,
        [property: XmlElement("extern")] bool Extern,
        [property: XmlElement("firstName")] string FirstName,
        [property: XmlElement("lastName")] string LastName,
        [property: XmlElement("personalNumber")]
        string PersonalNumber,
        [property: XmlElement("phone")] string? Phone,
        [property: XmlElement("stageName")] string? StageName,

        // [property: XmlElement("supervisionPhDStudents")] KosPermission SupervisionPhDStudents,
        [property: XmlElement("titlesPost")] string? TitlesPost,
        [property: XmlElement("titlesPre")] string? TitlesPre
    )
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KosTeacher"/> class.
        /// </summary>
        public KosTeacher()
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
                default!
            )
        {
        }
    }
}