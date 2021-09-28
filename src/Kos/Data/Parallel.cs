//
//   Parallel.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos parallel entity.
    /// </summary>
    /// <param name="Capacity">The capacity of the parallel.</param>
    /// <param name="CapacityOverfill">Whether overfill is allowed.</param>
    /// <param name="Code">The code of the parallel.</param>
    /// <param name="Course">The code of the course.</param>
    /// <param name="ParallelType">The type of the parallel.</param>
    /// <param name="Enrollment">Whether enrollment is allowed.</param>
    /// <param name="Note">The note for additional information.</param>
    /// <param name="Occupied">The number of the students enrolled.</param>
    /// <param name="Semester">The semester this parallel is in.</param>
    /// <param name="Teachers">The teachers that are are teaching the parallel. (Maximum of 4 teachers is allowed)</param>
    /// <param name="TimetableSlot">The time slot for this parallel</param>
    [XmlType("parallel", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Parallel
    (
        [property: XmlElement("capacity")] ushort? Capacity,
        [property: XmlElement("capacityOverfill")]
        Permission? CapacityOverfill,
        [property: XmlElement("code")] uint? Code,
        [property: XmlElement("course")] AtomLoadableEntity<Course> Course,
        [property: XmlElement("parallelType")] ParallelType ParallelType,
        [property: XmlElement("enrollment")] Permission? Enrollment,
        [property: XmlElement("note")] string? Note,
        [property: XmlElement("occupied")] ushort Occupied,
        [property: XmlElement("semester")] AtomLoadableEntity<Semester> Semester,
        [property: XmlArray("teachers")] List<TeacherAtomLoadableEntity> Teachers,
        [property: XmlElement("timetableSlot")]
        TimetableSlot? TimetableSlot
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parallel"/> class.
        /// </summary>
        public Parallel()
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