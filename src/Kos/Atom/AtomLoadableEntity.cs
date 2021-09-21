//
//  AtomLoadableEntity.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Atom
{
    /// <summary>
    /// Represents reference to an entity that can be loaded using the Atom Api.
    /// </summary>
    /// <typeparam name="TContent">The type of the content that will be loaded.</typeparam>
    public record AtomLoadableEntity<TContent>
    (
        [property: XmlAttribute("href", Namespace = "http://www.w3.org/1999/xlink")]
        string? Href,
        [property: XmlText] string? Title
    )
        where TContent : new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AtomLoadableEntity{T}"/> class.
        /// </summary>
        public AtomLoadableEntity()
            : this(default!, default)
        {
        }
    }
}