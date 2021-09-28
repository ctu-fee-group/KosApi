//
//  AtomEntry.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;
using Kos.Data;

namespace Kos.Atom
{
    /// <summary>
    /// Entry type retrieved from the kos api.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    [XmlRoot("entry", Namespace = "http://www.w3.org/2005/Atom"), Serializable]
    public class AtomEntry<TContent>
        where TContent : new()
    {
        private TContent _content = default!;

        /// <summary>
        /// Gets or sets the title of the entry.
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Gets or sets the author of the entry.
        /// </summary>
        [XmlElement("author")]
        public AtomAuthor Author { get; set; } = null!;

        /// <summary>
        /// Gets or sets the link for the entry.
        /// </summary>
        [XmlElement("link")]
        public AtomLink Link { get; set; } = null!;

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
        [XmlElement("content")]
        public TContent Content
        {
            get
            {
                if (_content is KosContent kosContent)
                {
                    kosContent.Id = Id;
                }

                return _content;
            }
            set => _content = value;
        }
    }
}