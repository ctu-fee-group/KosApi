//
//  Course.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Kos.Atom;
using Kos.Filters;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos course entity.
    /// </summary>
    /// <param name="AllowedEnrollmentCount">How many times can a student enroll the course.</param>
    /// <param name="ApprovalDate">The date of approval of the course.</param>
    /// <param name="ClassesLang">The language of the classes.</param>
    /// <param name="ClassesType">The type of the classes.</param>
    /// <param name="Code">The code of the course.</param>
    /// <param name="Completion">The type of the completion of the course.</param>
    /// <param name="Credits">The count of credits that the student gets.</param>
    /// <param name="Department">The department the course is under.</param>
    /// <param name="Description">The description of the course. Specified if detail is requested.</param>
    /// <param name="Homepage">The homepage url of the course.</param>
    /// <param name="Keywords">The keywords of the course.</param>
    /// <param name="LecturesContents">The contents of the lectures. Specified if detail is requested.</param>
    /// <param name="Literature">The literature for the course. Specified if detail is requested.</param>
    /// <param name="Name">The name of the course.</param>
    /// <param name="Note">The note of the course.</param>
    /// <param name="Objectives">The objectives that the course should give.</param>
    /// <param name="ProgrammeType">The type of programme the course is for.</param>
    /// <param name="Range">The count of the hours of lectures/tutorials etc.</param>
    /// <param name="Requirements">The requirements for the course. Specified if detail is requested.</param>
    /// <param name="Season">The season the course is for.</param>
    /// <param name="CourseState">The state of the course.</param>
    /// <param name="StudyForm">The form of the study.</param>
    /// <param name="SuperiorCourse">The superior course of the course.</param>
    /// <param name="Subcourses">The sub courses of the course.</param>
    /// <param name="TutorialsContents">The contents of the tutorials. Specified if detail is requested.</param>
    /// <param name="Instance">The instance of the course specified if semester was given.</param>
    [XmlType("course", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Course
    (
        [property: XmlElement("allowedEnrollmentCount")] ushort? AllowedEnrollmentCount,
        [property: XmlElement("approvalDate")] DateTime? ApprovalDate,
        [property: XmlElement("classesLang")] ClassesLang? ClassesLang,
        [property: XmlElement("classesType")] ClassesType? ClassesType,
        [property: XmlElement("code")] string Code,
        [property: XmlElement("completion")] Completion Completion,
        [property: XmlElement("credits")] ushort? Credits,
        [property: XmlElement("department")] AtomLoadableEntity<Division> Department,
        [property: XmlElement("description")] string? Description,
        [property: XmlElement("homepage")] string? Homepage,
        [property: XmlElement("keywords")] string? Keywords,
        [property: XmlElement("lecturesContents")] string? LecturesContents,
        [property: XmlElement("literature")] string? Literature,
        [property: XmlElement("name")] string Name,
        [property: XmlElement("note")] string? Note,
        [property: XmlElement("objectives")] string? Objectives,
        [property: XmlElement("programmeType")] ProgrammeType? ProgrammeType,
        [property: XmlElement("range")] string? Range,
        [property: XmlElement("requirements")] string? Requirements,
        [property: XmlElement("season")] Season? Season,
        [property: XmlElement("courseState")] CourseState CourseState,
        [property: XmlElement("studyForm")] StudyForm? StudyForm,
        [property: XmlElement("superiorCourse")] AtomLoadableEntity<Course>? SuperiorCourse,
        [property: XmlArray("subcourses")] List<CourseAtomLoadableEntity> Subcourses,
        [property: XmlElement("tutorialsContents")] string? TutorialsContents,
        [property: XmlElement("instance")] CourseInstance? Instance
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        public Course()
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