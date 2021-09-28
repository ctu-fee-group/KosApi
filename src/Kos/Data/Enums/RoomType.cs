//
//   RoomType.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos room type.
    /// </summary>
    public enum RoomType
    {
        /// <summary>
        /// Laboratory room type.
        /// </summary>
        [XmlEnum("LABORATORY")]
        Laboratory,

        /// <summary>
        /// Lecture room type.
        /// </summary>
        [XmlEnum("LECTURE")]
        Lecture,

        /// <summary>
        /// Office room type.
        /// </summary>
        [XmlEnum("OFFICE")]
        Office,

        /// <summary>
        /// Tutorial room type.
        /// </summary>
        [XmlEnum("TUTORIAL")]
        Tutorial,

        /// <summary>
        /// Undefined room type.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}