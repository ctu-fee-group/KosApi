//
//   Completion.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos course completion.
    /// </summary>
    public enum Completion
    {
        /// <summary>
        /// The course is completed with graded assessment.
        /// </summary>
        [XmlEnum("CLFD_CREDIT")]
        GradedAssessment,

        /// <summary>
        /// The course is completed with an assessment.
        /// </summary>
        [XmlEnum("CREDIT")]
        Assessment,

        /// <summary>
        /// The course is completed with assessment and exam.
        /// </summary>
        [XmlEnum("CREDIT_EXAM")]
        AssessmentExam,

        /// <summary>
        /// The course is completed with a defence. (Typically of the student's work).
        /// </summary>
        [XmlEnum("DEFENCE")]
        Defence,

        /// <summary>
        /// The course is completed with an exam.
        /// </summary>
        [XmlEnum("EXAM")]
        Exam,

        /// <summary>
        /// There is nothing needed for completing the course.
        /// </summary>
        [XmlEnum("NOTHING")]
        Nothing,

        /// <summary>
        /// Undefined completion type.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}