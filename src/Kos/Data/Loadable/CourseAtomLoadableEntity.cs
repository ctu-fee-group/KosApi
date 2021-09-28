//
//   CourseAtomLoadableEntity.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// The atom loadable of <see cref="Course"/>.
    /// </summary>
    [XmlType("course", Namespace = "smth")]
    public record CourseAtomLoadableEntity : AtomLoadableEntity<Course>;
}