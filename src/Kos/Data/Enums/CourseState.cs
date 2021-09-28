//
//   CourseState.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents course state.
    /// </summary>
    public enum CourseState
    {
        /// <summary>
        /// Proposed course state.
        /// </summary>
        [XmlEnum("PROPOSED")]
        Proposed,

        /// <summary>
        /// Approved course state.
        /// </summary>
        [XmlEnum("APPROVED")]
        Approved,

        /// <summary>
        /// Open course state.
        /// </summary>
        [XmlEnum("OPEN")]
        Open,

        /// <summary>
        /// Closed course state.
        /// </summary>
        [XmlEnum("CLOSED")]
        Closed,

        /// <summary>
        /// Undefined course state.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}