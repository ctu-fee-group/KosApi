//
//   StateExam.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos state exam.
    /// </summary>
    /// <param name="Branch">The branch this exam comes under.</param>
    /// <param name="EndDate">The end date of the exam.</param>
    /// <param name="Note">The not for the exam.</param>
    /// <param name="ProgrammeType">The type of the programme this state exam is for.</param>
    /// <param name="SigninDeadline">The deadline for sign ins.</param>
    /// <param name="StartDate">The start date of the exam.</param>
    [XmlType("stateexam", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record StateExam
    (
        [property: XmlElement("branch")] AtomLoadableEntity<Branch>? Branch,
        [property: XmlElement("endDate")] DateTime? EndDate,
        [property: XmlElement("note")] string? Note,
        [property: XmlElement("programmeType")]
        AtomLoadableEntity<ProgrammeType>? ProgrammeType,
        [property: XmlElement("signinDeadline")]
        DateTime? SigninDeadline,
        [property: XmlElement("startDate")] DateTime? StartDate
    )
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateExam"/> class.
        /// </summary>
        public StateExam()
            : this
            (
                default!,
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