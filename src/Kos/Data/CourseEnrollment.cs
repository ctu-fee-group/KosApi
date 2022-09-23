//
//   CourseEnrollment.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos course enrollment entity.
    /// </summary>
    /// <param name="Assessment">Whether the student has completed the course successfully.</param>
    /// <param name="Completed">Whether the student has completed the course. (successfully or unsuccessfully)</param>
    /// <param name="Extern">Unknown.</param>
    /// <param name="Semester">The semester the course was enrolled in.</param>
    /// <param name="Course">The enrolled course.</param>
    [XmlType("internalCourseEnrollment", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record CourseEnrollment
    (
        [property: XmlElement("assessment")] bool Assessment,
        [property: XmlElement("completed")] bool Completed,
        [property: XmlElement("extern")] bool Extern,
        [property: XmlElement("semester")] AtomLoadableEntity<Semester> Semester,
        [property: XmlElement("course")] AtomLoadableEntity<Course> Course
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseEnrollment"/> class.
        /// </summary>
        public CourseEnrollment()
            : this(default!, default!, default!, default!, default!)
        {
        }
    }
}