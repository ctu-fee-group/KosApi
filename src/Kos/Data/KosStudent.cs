//
//  KosStudent.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    [XmlType("student", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record KosStudent
    (

        // [property: XmlElement("branch")] KosLoadableEntity<KosBranch>? Division,
        // [property: XmlElement("department")] KosLoadableEntity<KosDepartment>? Department,
        [property: XmlElement("email")] string? Email,
        [property: XmlElement("startDate")] DateTime StartDate,

        // [property: XmlElement("faculty")] KosLoadableEntity<KosDivision?> Faculty,
        [property: XmlElement("firstName")] string FirstName,
        [property: XmlElement("grade")] byte Grade,
        [property: XmlElement("interruptedUntil")]
        DateTime? InterruptedUntil,
        [property: XmlElement("lastName")] string LastName,
        [property: XmlElement("personalNumber")]
        string PersonalNumber,
        [property: XmlElement("programme")] AtomLoadableEntity<KosProgramme>? Programme,
        [property: XmlElement("endDate")] DateTime? EndDate,

        // [property: XmlElement("studyForm")] KosStudyForm StudyForm,
        [property: XmlElement("studyGroup")] ushort? StudyGroup,

        // [property: XmlElement("studyPlan")] KosLoadableEntity<KosStudyPlan> StudyPlan,
        // [property: XmlElement("studyState")] KosStudyState StudyState,
        [property: XmlElement("supervisor")] AtomLoadableEntity<KosTeacher>? Supervisor,
        [property: XmlElement("supervisorSpecialist")]
        AtomLoadableEntity<KosTeacher>? SupervisorSpecialist,

        // [property: XmlElement("studyTerminationReason")] KosStudyTermination? StudyTerminationReason,
        [property: XmlElement("titlesPost")] string? TitlesPost,
        [property: XmlElement("titlesPre")] string? TitlesPre,
        [property: XmlElement("username")] string Username
    )
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KosStudent"/> class.
        /// </summary>
        public KosStudent()
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
                default!
            )
        {
        }
    }
}