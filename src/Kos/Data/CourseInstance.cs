//
//   CourseInstance.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents instance of a <see cref="Course"/> for specific semester.
    /// </summary>
    /// <param name="Semester">The semester instance is for.</param>
    /// <param name="Capacity">The capacity of the instance.</param>
    /// <param name="TutorialCapacity">The capacity of the tutorials.</param>
    /// <param name="CapacityOverfill">The capacity overfill permission.</param>
    /// <param name="Occupied">The number of students registered on the course.</param>
    /// <param name="Examiners">The examiners of the course.</param>
    /// <param name="Guarantors">The guarantors of the course.</param>
    /// <param name="Instructors">The instructors of the course.</param>
    /// <param name="Lecturers">The lecturers of the course.</param>
    [XmlType("instance", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record CourseInstance
    (
        [property: XmlElement("semester")] AtomLoadableEntity<Semester> Semester,
        [property: XmlElement("capacity")] uint? Capacity,
        [property: XmlElement("tutorialCapacity")] uint? TutorialCapacity,
        [property: XmlElement("capacityOverfill")]
        Permission? CapacityOverfill,
        [property: XmlElement("occupied")] uint? Occupied,
        [property: XmlArray("examiners")]
        List<TeacherAtomLoadableEntity> Examiners,
        [property: XmlArray("guarantors")]
        List<TeacherAtomLoadableEntity> Guarantors,
        [property: XmlArray("instructors")]
        List<TeacherAtomLoadableEntity> Instructors,
        [property: XmlArray("lecturers")]
        List<TeacherAtomLoadableEntity> Lecturers
    )
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseInstance"/> class.
        /// </summary>
        public CourseInstance()
        : this(
            default!,
            default!,
            default!,
            default!,
            default!,
            default!,
            default!,
            default!,
            default!)
        {
        }
    }
}