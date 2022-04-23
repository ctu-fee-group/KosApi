//
//   ExamRegistration.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos exam registration entity.
    /// </summary>
    /// <param name="Exam">The registered exam term.</param>
    [XmlType("examRegistration", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record ExamRegistration
    (
        [property: XmlElement("exam")] AtomLoadableEntity<Exam> Exam
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExamRegistration"/> class.
        /// </summary>
        public ExamRegistration()
            : this((AtomLoadableEntity<Exam>)default!)
        {
        }
    }
}