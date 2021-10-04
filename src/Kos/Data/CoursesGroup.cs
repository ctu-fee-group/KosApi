//
//   CoursesGroup.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos courses group entity.
    /// </summary>
    /// <param name="Approved">Whether the group is approved.</param>
    /// <param name="Code">The code of the group.</param>
    /// <param name="CoursesMaxLimit">The maximal courses that the student can have.</param>
    /// <param name="CoursesMinLimit">The minimal count of courses the students needs to finish in order to claim the group.</param>
    /// <param name="CreditsMaxLimit">The maximal count of credits the student can have.</param>
    /// <param name="CreditsMinLimit">The minimal count of credits the student needs to finish in order to claim the group.</param>
    /// <param name="Name">The name of the course group.</param>
    /// <param name="Note">The note of the course group.</param>
    /// <param name="Role">The role in the study plan.</param>
    /// <param name="Courses">The courses that are part of this</param>
    [XmlType("coursesGroup", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record CoursesGroup
    (
        [property: XmlElement("approved")] bool? Approved,
        [property: XmlElement("code")] string? Code,
        [property: XmlElement("coursesMaxLimit")]
        ushort? CoursesMaxLimit,
        [property: XmlElement("coursesMinLimit")]
        ushort? CoursesMinLimit,
        [property: XmlElement("creditsMaxLimit")]
        ushort? CreditsMaxLimit,
        [property: XmlElement("creditsMinLimit")]
        ushort? CreditsMinLimit,
        [property: XmlElement("name")] string? Name,
        [property: XmlElement("note")] string? Note,
        [property: XmlElement("role")] string? Role,
        [property: XmlArray("courses")] List<CourseAtomLoadableEntity> Courses
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoursesGroup"/> class.
        /// </summary>
        public CoursesGroup()
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