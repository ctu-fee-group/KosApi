//
//  Programme.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos programme entity.
    /// </summary>
    /// <param name="AcademicTitle">The academic title obtained from the programme.</param>
    /// <param name="Capacity">The capacity of the programme.</param>
    /// <param name="Code">The code of the programme.</param>
    /// <param name="Description">The description of the programme.</param>
    /// <param name="DiplomaName">The name of the diploma obtained from the programme.</param>
    /// <param name="Division">The division the programme is inside of.</param>
    /// <param name="Guarantor">The guarantor of the programme.</param>
    /// <param name="Name">The name of the programme.</param>
    /// <param name="OpenForAdmission">Whether the program is open for admissions.</param>
    /// <param name="StudyDuration">The standard duration of the studying.</param>
    /// <param name="ProgrammeType"></param>
    [XmlType("programme", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Programme
    (
        [property: XmlElement("academicTitle")]
        string? AcademicTitle,
        [property: XmlElement("capacity")] ushort? Capacity,
        [property: XmlElement("classesLang")] ClassesLang? ClassesLang,
        [property: XmlElement("code")] string? Code,
        [property: XmlElement("description")] string? Description,
        [property: XmlElement("diplomaName")] string? DiplomaName,
        [property: XmlElement("division")] AtomLoadableEntity<Division>? Division,
        [property: XmlElement("guarantor")] AtomLoadableEntity<Teacher>? Guarantor,
        [property: XmlElement("name")] string? Name,
        [property: XmlElement("openForAdmission")]
        bool? OpenForAdmission,
        [property: XmlElement("studyDuration")]
        double? StudyDuration,
        [property: XmlElement("type")] ProgrammeType? ProgrammeType
    )
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Programme"/> class.
        /// </summary>
        public Programme()
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
                default!,
                default!
            )
        {
        }
    }
}