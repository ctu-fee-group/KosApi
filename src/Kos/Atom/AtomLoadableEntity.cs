//
//  AtomLoadableEntity.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace Kos.Atom
{
    /// <summary>
    /// The base loadable entity class used just for xml serializer to initialize it correctly.
    /// </summary>
    /// <param name="Href"></param>
    /// <param name="Title"></param>
    [Obsolete]
    public record AtomLoadableEntity
    (
        [property: XmlAttribute("href", Namespace = "http://www.w3.org/1999/xlink")] string? Href,
        [property: XmlText] string? Title
    );

    /// <summary>
    /// Represents reference to an entity that can be loaded using the Atom Api.
    /// </summary>
    /// <typeparam name="TContent">The type of the content that will be loaded.</typeparam>
#pragma warning disable 612
    public record AtomLoadableEntity<TContent> : AtomLoadableEntity
#pragma warning restore 612
        where TContent : new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AtomLoadableEntity{T}"/> class.
        /// </summary>
        public AtomLoadableEntity()
            : base(default!, default!)
        {
        }
    }
}