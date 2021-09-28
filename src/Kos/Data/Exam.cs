//
//  Exam.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos exam entity.
    /// </summary>
    /// <param name="CancelDeadline"></param>
    /// <param name="Capacity"></param>
    /// <param name="Course"></param>
    /// <param name="Department"></param>
    /// <param name="EndDate"></param>
    /// <param name="Examiners"></param>
    /// <param name="Note"></param>
    /// <param name="Occupied"></param>
    /// <param name="Resit"></param>
    /// <param name="Room"></param>
    /// <param name="Semester"></param>
    /// <param name="SignInDeadline"></param>
    /// <param name="StartDate"></param>
    /// <param name="Substitutes"></param>
    /// <param name="Superior"></param>
    /// <param name="TermType"></param>
    [XmlType("exam", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Exam
    (
        [property: XmlElement("cancelDeadline")] DateTime? CancelDeadline,
        [property: XmlElement("capacity")] uint Capacity,
        [property: XmlElement("course")] AtomLoadableEntity<Course>? Course,
        [property: XmlElement("department")] AtomLoadableEntity<Division>? Department,
        [property: XmlElement("endDate")] DateTime? EndDate,
        [property: XmlArray("examiners")] List<TeacherAtomLoadableEntity> Examiners,
        [property: XmlElement("note")] string? Note,
        [property: XmlElement("occupied")] uint Occupied,
        [property: XmlElement("resit")] bool? Resit,
        [property: XmlElement("room")] AtomLoadableEntity<Room>? Room,
        [property: XmlElement("semester")] AtomLoadableEntity<Semester>? Semester,
        [property: XmlElement("signinDeadline")] DateTime? SignInDeadline,
        [property: XmlElement("startDate")] DateTime? StartDate,
        [property: XmlElement("substitutes")] Permission? Substitutes,
        [property: XmlElement("superior")] AtomLoadableEntity<Exam>? Superior,
        [property: XmlElement("termType")] TermType? TermType
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Exam"/> class.
        /// </summary>
        public Exam()
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