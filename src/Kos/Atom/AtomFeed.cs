//
//   AtomFeed.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Kos.Atom
{
    /// <summary>
    /// Feed type retrieved from the kos api.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom"), Serializable]
    public class AtomFeed<TContent>
    {
        /// <summary>
        /// Gets or sets the title of the entry.
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Gets or sets the id of the entry.
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date the entity was updated.
        /// </summary>
        [XmlElement("updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the content itself.
        /// May be null if the entity was not found.
        /// </summary>
        [XmlElement("entry")]
        public List<AtomEntry<TContent>> Entries { get; set; } = null!;
    }
}