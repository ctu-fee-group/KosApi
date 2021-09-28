//
//   ThesisState.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.NetworkInformation;
using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents state of <see cref="Thesis"/>.
    /// </summary>
    public enum ThesisState
    {
        /// <summary>
        /// The thesis is available.
        /// </summary>
        [XmlEnum("AVAILABLE")]
        Available,

        /// <summary>
        /// The thesis is reserved for someone.
        /// </summary>
        [XmlEnum("RESERVED")]
        Reserved,

        /// <summary>
        /// The thesis was already assigned.
        /// </summary>
        [XmlEnum("ASSIGNED")]
        Assigned,

        /// <summary>
        /// The thesis was already submitted.
        /// </summary>
        [XmlEnum("SUBMITTED")]
        Submitted,

        /// <summary>
        /// The thesis was accepted.
        /// </summary>
        [XmlEnum("ACCEPTED")]
        Accepted,

        /// <summary>
        /// The thesis was defended.
        /// </summary>
        [XmlEnum("DEFENDED")]
        Defended,

        /// <summary>
        /// Undefined thesis state.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}