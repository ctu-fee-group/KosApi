//
//  Semester.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos semester entity.
    /// </summary>
    /// <param name="EndDate">The date when the semester ends. (includes examination period)</param>
    /// <param name="Name">The human readable name of the semester.</param>
    /// <param name="StartDate">The start date of the semester.</param>
    [XmlType("semester", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Semester
    (
        [property: XmlElement("endDate")] DateTime? EndDate,
        [property: XmlElement("name")] string? Name,
        [property: XmlElement("startDate")] DateTime? StartDate
    )
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Semester"/> class.
        /// </summary>
        public Semester()
            : this
            (
                default!,
                default!,
                default!
            )
        {
        }
    }
}