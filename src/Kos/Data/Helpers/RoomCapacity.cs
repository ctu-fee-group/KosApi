//
//   RoomCapacity.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents room capacity.
    /// </summary>
    /// <param name="For">The attribute that specifies the type of the capacity.</param>
    /// <param name="Capacity">The capacity itself.</param>
    public record RoomCapacity([property: XmlAttribute("for")] string For, [property: XmlText] uint Capacity)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomCapacity"/> class.
        /// </summary>
        public RoomCapacity()
            : this(default!, default!)
        {
        }
    }
}