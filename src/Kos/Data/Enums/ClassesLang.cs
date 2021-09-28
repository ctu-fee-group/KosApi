//
//   ClassesLang.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos language of classes.
    /// </summary>
    public enum ClassesLang
    {
        /// <summary>
        /// Czech language.
        /// </summary>
        [XmlEnum("CS")]
        Czech,

        /// <summary>
        /// German language.
        /// </summary>
        [XmlEnum("DE")]
        German,

        /// <summary>
        /// English language.
        /// </summary>
        [XmlEnum("EN")]
        English,

        /// <summary>
        /// Spanish language.
        /// </summary>
        [XmlEnum("ES")]
        Spanish,

        /// <summary>
        /// French language.
        /// </summary>
        [XmlEnum("FR")]
        French,

        /// <summary>
        /// Polish language.
        /// </summary>
        [XmlEnum("PL")]
        Polish,

        /// <summary>
        /// Russian language.
        /// </summary>
        [XmlEnum("RU")]
        Russian,

        /// <summary>
        /// Slovak language.
        /// </summary>
        [XmlEnum("SK")]
        Slovak,

        /// <summary>
        /// Undefined languages.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined
    }
}