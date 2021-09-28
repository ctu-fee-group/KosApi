//
//   Season.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos season.
    /// </summary>
    public enum Season
    {
        /// <summary>
        /// Winter season.
        /// </summary>
        [XmlEnum("WINTER")]
        Winter,

        /// <summary>
        /// Summer season.
        /// </summary>
        [XmlEnum("SUMMER")]
        Summer,

        /// <summary>
        /// Summer and winter seasons.
        /// </summary>
        [XmlEnum("BOTH")]
        Both,

        /// <summary>
        /// Undefined season.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}