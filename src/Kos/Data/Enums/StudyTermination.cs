//
//   StudyTermination.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace Kos.Data
{
    /// <summary>
    /// Represents kos study termination.
    /// </summary>
    public enum StudyTermination
    {
        /// <summary>
        /// Successful examination.
        /// </summary>
        [XmlEnum("GRADUATION")]
        Graduation,

        /// <summary>
        /// The Student has quit the studies.
        /// </summary>
        [XmlEnum("WITHDRAW")]
        Withdraw,

        /// <summary>
        /// The student did not comply the programme.
        /// </summary>
        [XmlEnum("NONCOMPLIANCE")]
        Noncompliance,

        /// <summary>
        /// Accreditation of the programme was revoked.
        /// </summary>
        [XmlEnum("ACCREDITATION_REVOKED")]
        AccreditationRevoked,

        /// <summary>
        /// Acreditation has expired.
        /// </summary>
        [XmlEnum("ACCREDITATION_EXPIRED")]
        AccreditationExpired,

        /// <summary>
        /// The student was terminated, because of paragraph 65.
        /// </summary>
        [XmlEnum("EXPULSION_PAR_65")]
        ExpulsionPar65,

        /// <summary>
        /// The student was terminated, because of paragraph 67.
        /// </summary>
        [XmlEnum("EXPULSION_PAR_67")]
        ExpulsionPar67,

        /// <summary>
        /// Death of the student.
        /// </summary>
        [XmlEnum("DEATH")]
        Death,

        /// <summary>
        /// Transfer from other faculty.
        /// </summary>
        [XmlEnum("TRANSFER_TO_OTHER_FACULTY")]
        TransferToOtherFaculty,

        /// <summary>
        /// Undefined study termination.
        /// </summary>
        [XmlEnum("UNDEFINED")]
        Undefined,
    }
}