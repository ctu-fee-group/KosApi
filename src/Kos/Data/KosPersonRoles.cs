using System.Collections.Generic;
using System.Xml.Serialization;
using Kos.Atom;

namespace Kos.Data
{
    public record KosPersonRoles(
        [property: XmlElement("student")] IReadOnlyList<AtomLoadableEntity<KosStudent>> Students,
        [property: XmlElement("teacher")] AtomLoadableEntity<KosTeacher>? Teacher)
    {
        public KosPersonRoles()
            : this(default!, null)
        {
            
        }
    }
}