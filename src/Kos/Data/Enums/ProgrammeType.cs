//
//  ProgrammeType.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents type of the <see cref="Programme"/>.
    /// </summary>
    public enum ProgrammeType
    {
        /// <summary>
        /// Bachelor programme.
        /// </summary>
        [XmlEnum("BACHELOR")]
        Bachelor,

        /// <summary>
        /// Doctoral programme.
        /// </summary>
        [XmlEnum("DOCTORAL")]
        Doctoral,

        /// <summary>
        /// Internshop programme.
        /// </summary>
        [XmlEnum("INTERNSHIP")]
        Internship,

        /// <summary>
        /// Lifelong programme.
        /// </summary>
        [XmlEnum("LIFELONG")]
        Lifelong,

        /// <summary>
        /// Master programme.
        /// </summary>
        [XmlEnum("MASTER")]
        Master,

        /// <summary>
        /// Legacy master programme.
        /// </summary>
        [XmlEnum("MASTER_LEGACY")]
        MasterLegacy,

        /// <summary>
        /// Undefined, non-known programme.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined
    }
}