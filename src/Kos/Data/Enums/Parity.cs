//
//   Parity.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos parity.
    /// </summary>
    public enum Parity
    {
        /// <summary>
        /// Odd week.
        /// </summary>
        [XmlEnum("ODD")]
        Odd,

        /// <summary>
        /// Even week.
        /// </summary>
        [XmlEnum("EVEN")]
        Even,

        /// <summary>
        /// Even and odd weeks (all of the weeks).
        /// </summary>
        [XmlEnum("BOTH")]
        Both,

        /// <summary>
        /// Undefined parity.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}