//
//  Room.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos room entity.
    /// </summary>
    /// <param name="Capacity">The capacities of the room.</param>
    /// <param name="Code">The code of the room.</param>
    /// <param name="Locality">The code of the locality.</param>
    /// <param name="Name">The name of the room.</param>
    /// <param name="Type">The type of the room. (What the room is used for)</param>
    [XmlType("room", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Room
    (
        [property: XmlElement("capacity")] List<RoomCapacity> Capacity,
        [property: XmlElement("code")] string? Code,
        [property: XmlElement("locality")] string? Locality,
        [property: XmlElement("name")] string? Name,
        [property: XmlElement("type")] RoomType? Type
    ) : KosContent
    {
        /// <summary>
        /// Gets the examining capacity.
        /// </summary>
        public uint? CapacityForExamining => Capacity.FirstOrDefault(x => x.For == "examining")?.Capacity;

        /// <summary>
        /// Gets the teaching capacity.
        /// </summary>
        public uint? CapacityForTeaching => Capacity.FirstOrDefault(x => x.For == "teaching")?.Capacity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        public Room()
            : this
            (
                default!,
                default!,
                default!,
                default!,
                default!
            )
        {
        }
    }
}