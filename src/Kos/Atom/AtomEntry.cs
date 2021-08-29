using System;
using System.Xml.Serialization;

namespace Kos.Atom
{
    /// <summary>
    /// Entry type shared between all entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [XmlRoot("entry", Namespace = "http://www.w3.org/2005/Atom"), Serializable]
    public class AtomEntry<T>
    {
        [XmlElement("title")] public string Title { get; set; } = null!;

        [XmlElement("id")] public string Id { get; set; } = null!;
        
        [XmlElement("updated")]
        public DateTime Updated { get; set; }

        [XmlElement("content")]
        public T? Content { get; set; }
    }
}