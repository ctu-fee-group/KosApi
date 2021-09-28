//
//   ParallelType.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents type of parallel.
    /// </summary>
    public enum ParallelType
    {
        /// <summary>
        /// Laboratory parallel.
        /// </summary>
        [XmlEnum("LABORATORY")]
        Laboratory,

        /// <summary>
        /// Lecture parallel.
        /// </summary>
        [XmlEnum("LECTURE")]
        Lecture,

        /// <summary>
        /// Tutorial parallel.
        /// </summary>
        [XmlEnum("TUTORIAL")]
        Tutorial,

        /// <summary>
        /// Undefined parallel.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}