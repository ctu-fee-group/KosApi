using System;
using System.Xml.Serialization;

namespace Kos.Atom
{
    [Serializable]
    public record AtomLoadableEntity(
        [property: XmlAttribute("href", Namespace = "http://www.w3.org/1999/xlink")]
        string? Href,
        [property: XmlText] string? Title
    )
    {
        public AtomLoadableEntity()
            : this(default, default)
        {
        }
    }

    /// <summary>
    /// Entity holding information needed to load referenced entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public record AtomLoadableEntity<T> : AtomLoadableEntity
        where T : new();
}