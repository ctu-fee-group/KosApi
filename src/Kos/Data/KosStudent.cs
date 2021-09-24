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
    /// <summary>
    /// Represents kos student entity.
    /// </summary>
    /// <param name="Email">The email of the student.</param>
    /// <param name="StartDate">The start date of the studying.</param>
    /// <param name="FirstName">The first name of the student.</param>
    /// <param name="Grade">The grade of the student. (Year of study)</param>
    /// <param name="InterruptedUntil">The date until the study is interrupted.</param>
    /// <param name="LastName">The last name of the student.</param>
    /// <param name="PersonalNumber">The personal number of the student.</param>
    /// <param name="Programme">The programme the user is studying, if any.</param>
    /// <param name="EndDate">The end date of the studying.</param>
    /// <param name="StudyGroup">The study group. (Students are separated into groups at the start of the study)</param>
    /// <param name="Supervisor">The supervisor of the student, if any.</param>
    /// <param name="SupervisorSpecialist">The specialist supervisor, if any.</param>
    /// <param name="TitlesPost">The titles behind the name.</param>
    /// <param name="TitlesPre">The titles in front of the name.</param>
    /// <param name="Username">The username of the student.</param>
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