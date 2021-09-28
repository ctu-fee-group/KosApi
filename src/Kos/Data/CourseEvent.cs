//
//   CourseEvent.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos course event entity.
    /// </summary>
    /// <param name="Branch"></param>
    /// <param name="Capacity"></param>
    /// <param name="Course"></param>
    /// <param name="Teacher"></param>
    /// <param name="EndDate"></param>
    /// <param name="Name"></param>
    /// <param name="Note"></param>
    /// <param name="Occupied"></param>
    /// <param name="Room"></param>
    /// <param name="Semester"></param>
    /// <param name="SigninDeadline"></param>
    /// <param name="StartDate"></param>
    public record CourseEvent
    (
        [property: XmlElement("branch")] AtomLoadableEntity<Branch>? Branch,
        [property: XmlElement("capacity")] uint? Capacity,
        [property: XmlElement("course")] AtomLoadableEntity<Course>? Course,
        [property: XmlElement("teacher")] AtomLoadableEntity<Teacher>? Teacher,
        [property: XmlElement("endDate")] DateTime? EndDate,
        [property: XmlElement("name")] string Name,
        [property: XmlElement("note")] string? Note,
        [property: XmlElement("occupied")] uint? Occupied,
        [property: XmlElement("room")] AtomLoadableEntity<Room>? Room,
        [property: XmlElement("semester")] AtomLoadableEntity<Semester>? Semester,
        [property: XmlElement("signinDeadline")]
        DateTime SigninDeadline,
        [property: XmlElement("startDate")] DateTime StartDate
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseEvent"/> class.
        /// </summary>
        public CourseEvent()
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