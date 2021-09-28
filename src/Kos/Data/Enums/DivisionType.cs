//
//  DivisionType.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents type of the <see cref="Division"/>.
    /// </summary>
    public enum DivisionType
    {
        /// <summary>
        /// The rectorate.
        /// </summary>
        [XmlEnum("RECTORATE")]
        Recorate,

        /// <summary>
        /// The faculty.
        /// </summary>
        [XmlEnum("FACULTY")]
        Faculty,

        /// <summary>
        /// The department.
        /// </summary>
        [XmlEnum("DEPARTMENT")]
        Department,

        /// <summary>
        /// The institute.
        /// </summary>
        [XmlEnum("INSTITUTE")]
        Institute,

        /// <summary>
        /// Undefined.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}