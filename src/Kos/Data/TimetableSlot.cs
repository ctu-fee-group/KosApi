//
//  TimetableSlot.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos time table slot for <see cref="Parallel"/>.
    /// </summary>
    /// <param name="Day">The day in the week (1 - 7, start with monday)</param>
    /// <param name="Duration">The number of the lessons this time slot takes.</param>
    /// <param name="FirstHour">The number of the lesson that this time table starts at.</param>
    /// <param name="Parity">What weeks is this parallel .</param>
    /// <param name="Room">The room this slot is in.</param>
    /// <param name="StartTime">The time of day this slot starts at.</param>
    /// <param name="EndTime">The time of the day this slot ends at.</param>
    /// <param name="Weeks">What weeks is this slot in.</param>
    [XmlType("timetableSlot", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record TimetableSlot
    (
        [property: XmlElement("day")] ushort? Day,
        [property: XmlElement("duration")] ushort? Duration,
        [property: XmlElement("firstHour")] ushort? FirstHour,
        [property: XmlElement("parity")] Parity? Parity,
        [property: XmlElement("room")] AtomLoadableEntity<Room>? Room,
        [property: XmlElement("startTime")] TimeSpan? StartTime,
        [property: XmlElement("endTime")] TimeSpan? EndTime,
        [property: XmlElement("weeks")] string? Weeks
    ) : KosContent;
}