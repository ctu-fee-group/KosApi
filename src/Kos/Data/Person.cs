//
//  Person.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos person entity.
    /// </summary>
    /// <param name="FirstName">The first name of the person.</param>
    /// <param name="LastName">The last name of the person.</param>
    /// <param name="PersonalNumber">The personal number of the person.</param>
    /// <param name="Roles">The roles of the person.</param>
    /// <param name="TitlesPre">The titles in front of the name.</param>
    /// <param name="TitlesPost">The titles after the name.</param>
    /// <param name="Username">The username of the user.</param>
    [XmlType("person", Namespace = "http://kosapi.feld.cvut.cz/schema/3")]
    public record Person
    (
        [property: XmlElement("firstName")] string FirstName,
        [property: XmlElement("lastName")] string LastName,
        [property: XmlElement("personalNumber")]
        string PersonalNumber,
        [property: XmlElement("roles")] PersonRoles Roles,
        [property: XmlElement("titlesPre")] string? TitlesPre,
        [property: XmlElement("titlesPost")] string? TitlesPost,
        [property: XmlElement("username")] string Username
    ) : KosContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
            : this(default!, default!, default!, default!, default!, default!, default!)
        {
        }
    }
}