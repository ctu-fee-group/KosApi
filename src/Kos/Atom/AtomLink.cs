//
//   AtomLink.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Atom
{
    /// <summary>
    /// Represents the link of <see cref="AtomEntry{TContent}"/>.
    /// </summary>
    public class AtomLink
    {
        /// <summary>
        /// The endpoint of the entity.
        /// </summary>
        [XmlAttribute("href")]
        public string Href { get; set; } = null!;
    }
}