//
//   InternalCourseEnrollment.cs
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
/// <param name="Course"></param>
[Serializable]
[XmlType("internalCourseEnrollment", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
public record InternalCourseEnrollment
(
    [property: XmlElement("course")] AtomLoadableEntity<Course>? Course
) : CourseEnrollment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InternalCourseEnrollment"/> class.
    /// </summary>
    public InternalCourseEnrollment()
        : this((AtomLoadableEntity<Course>?)default!)
    {
    }
}