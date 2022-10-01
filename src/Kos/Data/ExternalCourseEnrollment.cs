//
//   ExternalCourseEnrollment.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data;

/// <summary>
/// Represents kos course enrollment entity.
/// </summary>
/// <param name="Completion">How the course is completed (unknown enum values, known value CREDIT_EXAM)</param>
/// <param name="Credits">The amount of credits the student will get for the course.</param>
/// <param name="Name">The name of the course</param>
[Serializable]
[XmlType("externalCourseEnrollment", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
public record ExternalCourseEnrollment
(
    [property: XmlElement("completion")] string Completion,
    [property: XmlElement("credits")] short Credits,
    [property: XmlElement("name")] string Name
) : CourseEnrollment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExternalCourseEnrollment"/> class.
    /// </summary>
    public ExternalCourseEnrollment()
        : this(default!, default!, default!)
    {
    }
}