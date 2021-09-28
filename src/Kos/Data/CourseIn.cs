//
//   CourseIn.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    public record CourseIn
        ([property: XmlElement("course")] AtomLoadableEntity<Course> Course) : CourseInstance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseIn"/> class.
        /// </summary>
        public CourseIn()
            : this((AtomLoadableEntity<Course>)default!)
        {
        }
    }
}