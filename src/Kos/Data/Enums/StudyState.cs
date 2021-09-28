//
//   StudyState.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos study state.
    /// </summary>
    public enum StudyState
    {
        /// <summary>
        /// Student is studying.
        /// </summary>
        [XmlEnum("ACTIVE")]
        Active,

        /// <summary>
        /// Student interrupted his studies.
        /// </summary>
        [XmlEnum("INTERRUPTED")]
        Interrupted,

        /// <summary>
        /// Student study was closed.
        /// </summary>
        [XmlEnum("CLOSED")]
        Closed,

        /// <summary>
        /// Undefined student study.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}