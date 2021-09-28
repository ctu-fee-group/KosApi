//
//   Thesis.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos thesis entity.
    /// </summary>
    /// <param name="AssignmentDate">The date of assignment.</param>
    /// <param name="Branch">The branch the thesis is under.</param>
    /// <param name="Department">The department the thesis is under.</param>
    /// <param name="DefenseDate">The date of the defense of the thesis.</param>
    /// <param name="Description">The description of the thesis.</param>
    /// <param name="Keywords">The keywords of the thesis.</param>
    /// <param name="LicenseAgreed">Whether there is a need for license agreement.</param>
    /// <param name="Literature">The recommended literature.</param>
    /// <param name="Name">The name of the thesis.</param>
    /// <param name="Reviewer">The reviewer for the thesis.</param>
    /// <param name="Proponent">The proponent of the thesis.</param>
    /// <param name="State">The state of the thesis.</param>
    /// <param name="Student">The student who has the thesis reserved or accepted.</param>
    /// <param name="SubmissionDeadline">The deadline of the submission.</param>
    /// <param name="Supervisor">The supervisor for the thesis.</param>
    /// <param name="Summary">The summary of the thesis.</param>
    /// <param name="Type">The type of the programme the thesis is for.</param>
    /// <param name="DSpaceUrl">The url of the final thesis.</param>
    [XmlType("thesis", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Thesis
    (
        [property: XmlElement("assignmentDate")]
        DateTime? AssignmentDate,
        [property: XmlElement("branch")] AtomLoadableEntity<Branch>? Branch,
        [property: XmlElement("department")] AtomLoadableEntity<Division>? Department,
        [property: XmlElement("defenseDate")] DateTime? DefenseDate,
        [property: XmlElement("description")] string Description,
        [property: XmlElement("keywords")] string? Keywords,
        [property: XmlElement("licenceAgreed")]
        bool? LicenseAgreed,
        [property: XmlElement("literature")] string? Literature,
        [property: XmlElement("name")] string Name,
        [property: XmlElement("reviewer")] AtomLoadableEntity<Person>? Reviewer,
        [property: XmlElement("proponent")] string? Proponent,
        [property: XmlElement("state")] ThesisState State,
        [property: XmlElement("student")] AtomLoadableEntity<Student>? Student,
        [property: XmlElement("submissionDeadline")]
        DateTime? SubmissionDeadline,
        [property: XmlElement("supervisor")] AtomLoadableEntity<Person>? Supervisor,
        [property: XmlElement("summary")] string? Summary,
        [property: XmlElement("type")] ProgrammeType Type,
        [property: XmlElement("dspaceUrl")] string? DSpaceUrl
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Thesis"/> class.
        /// </summary>
        public Thesis()
            : this
            (
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
                default!,
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