//
//   ThesisReview.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos thesis review.
    /// </summary>
    /// <param name="Thesis">The thesis being reviewed.</param>
    /// <param name="Author">The author of the review.</param>
    /// <param name="ProposedGrade">The grade that is proposed (A - F)</param>
    /// <param name="DocumentUrl">The url to pdf document with the review.</param>
    [XmlType("thesisreview", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record ThesisReview
    (
        [property: XmlElement("thesis")] AtomLoadableEntity<Thesis> Thesis,
        [property: XmlElement("author")] AtomLoadableEntity<Teacher> Author,
        [property: XmlElement("proposedGrade")] string? ProposedGrade,
        [property: XmlElement("documentUrl")] string? DocumentUrl
    ) : KosContent;
}