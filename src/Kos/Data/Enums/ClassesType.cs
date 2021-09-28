//
//   ClassesType.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos classes type.
    /// </summary>
    public enum ClassesType
    {
        /// <summary>
        /// Atelier class type.
        /// </summary>
        [XmlEnum("ATELIER")]
        Atelier,

        /// <summary>
        /// Block teaching class type.
        /// </summary>
        [XmlEnum("BLOCK")]
        BlockTeaching,

        /// <summary>
        /// Consultation class type.
        /// </summary>
        [XmlEnum("CONSULTATION")]
        Consultation,

        /// <summary>
        /// Laboratory class type.
        /// </summary>
        [XmlEnum("LABORATORY")]
        Laboratory,

        /// <summary>
        /// Lecture class type.
        /// </summary>
        [XmlEnum("LECTURE")]
        Lecture,

        /// <summary>
        /// Project class type.
        /// </summary>
        [XmlEnum("PROJECT")]
        Project,

        /// <summary>
        /// Individual project class type.
        /// </summary>
        [XmlEnum("PROJECT_INDV")]
        IndividualProject,

        /// <summary>
        /// Team project class type.
        /// </summary>
        [XmlEnum("PROJECT_TEAM")]
        TeamProject,

        /// <summary>
        /// Proseminar class type.
        /// </summary>
        [XmlEnum("PROSEMINAR")]
        Proseminar,

        /// <summary>
        /// Physical education course class type.
        /// </summary>
        [XmlEnum("PT_COURSE")]
        PhysicalEducationCourse,

        /// <summary>
        /// Seminar class type.
        /// </summary>
        [XmlEnum("SEMINAR")]
        Seminar,

        /// <summary>
        /// Tutorial class type.
        /// </summary>
        [XmlEnum("TUTORIAL")]
        Tutorial,

        /// <summary>
        /// Undefined class type.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}