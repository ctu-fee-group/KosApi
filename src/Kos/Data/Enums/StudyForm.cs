//
//   StudyForm.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos study form.
    /// </summary>
    public enum StudyForm
    {
        /// <summary>
        /// Full time study form. (The student comes to the school every day).
        /// </summary>
        [XmlEnum("FULLTIME")]
        FullTime,

        /// <summary>
        /// Part time study form. (The student comes to the school only few days of week).
        /// </summary>
        [XmlEnum("PARTTIME")]
        PartTime,

        /// <summary>
        /// Distance study form. (The student does not come to the school for lessons).
        /// </summary>
        [XmlEnum("DISTANCE")]
        Distance,

        /// <summary>
        /// Life long study form.
        /// </summary>
        [XmlEnum("SELF_PAYER")]
        Lifelong,

        /// <summary>
        /// Undefined study form.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}