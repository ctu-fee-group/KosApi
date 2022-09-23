//
//   SemesterFilter.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Kos.Filters
{
    /// <summary>
    /// Represents SemesterFilter for kos api to filter relative or absolute semesters.
    /// </summary>
    /// <remarks>
    /// For more information, see https://kosapi.fit.cvut.cz/projects/kosapi/wiki/SemesterFilter.
    /// </remarks>
    public struct SemesterFilter
    {
        private const string CYYS = "^([AB])(\\d{2})([12])$";
        private const string YYYYS = "^(\\d{4})([WS])$";

        /// <summary>
        /// Initializes a new instance of the <see cref="SemesterFilter"/> struct.
        /// </summary>
        /// <param name="year">The year to filter.</param>
        /// <param name="season">The season to filter.</param>
        public SemesterFilter(int year, SemesterSeason season)
        {
            Year = year;
            Season = season;
            RelativeFilter = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SemesterFilter"/> struct.
        /// </summary>
        /// <param name="relativeSemesterFilter">The relative semester to filter.</param>
        public SemesterFilter(RelativeSemesterFilter relativeSemesterFilter)
        {
            RelativeFilter = relativeSemesterFilter;
            Year = null;
            Season = null;
        }

        /// <summary>
        /// The year of the semester.
        /// </summary>
        public int? Year { get; }

        /// <summary>
        /// The relative filter of the semester.
        /// </summary>
        public RelativeSemesterFilter? RelativeFilter { get; }

        /// <summary>
        /// The position of the semester filter.
        /// </summary>
        public SemesterSeason? Season { get; }

        /// <summary>
        /// Gets whether the filter is relative.
        /// </summary>
        /// <returns>Whether the filter is relative.</returns>
        [MemberNotNullWhen(true, "RelativeFilter")]
        [MemberNotNullWhen(false, "Season")]
        [MemberNotNullWhen(false, "Year")]
        public bool IsRelative()
            => RelativeFilter is not null;

        /// <summary>
        /// Gets whether the filter is absolute.
        /// </summary>
        /// <returns>Whether the filter is absolute.</returns>
        [MemberNotNullWhen(true, "Season")]
        [MemberNotNullWhen(true, "Year")]
        [MemberNotNullWhen(false, "RelativeFilter")]
        public bool IsAbsolute()
            => Year is not null && Season is not null;

        /// <summary>
        /// Obtains semester that was prior to this one.
        /// </summary>
        /// <returns>The previous semester.</returns>
        /// <exception cref="InvalidOperationException">Thrown if semester is relative and either "Previous" or "Scheduling". Correct value cannot be obtained then.</exception>
        public SemesterFilter GetPreviousSemester()
        {
            if (IsRelative())
            {
                var relative = RelativeFilter switch
                {
                    RelativeSemesterFilter.Current => RelativeSemesterFilter.Previous,
                    RelativeSemesterFilter.Next => RelativeSemesterFilter.Current,
                    _ => throw new InvalidOperationException()
                };

                return new SemesterFilter(relative);
            }

            if (Season == SemesterSeason.Winter)
            {
                return new SemesterFilter(Year.Value - 1, SemesterSeason.Summer);
            }

            return new SemesterFilter(Year.Value, SemesterSeason.Winter);

        }

        /// <summary>
        /// Obtains semester that is later to this one.
        /// </summary>
        /// <returns>The next semester.</returns>
        /// <exception cref="InvalidOperationException">Thrown if semester is relative and either "Next" or "Scheduling". Correct value cannot be obtained then.</exception>
        public SemesterFilter GetNextSemester()
        {
            if (IsRelative())
            {
                var relative = RelativeFilter switch
                {
                    RelativeSemesterFilter.Current => RelativeSemesterFilter.Next,
                    RelativeSemesterFilter.Previous => RelativeSemesterFilter.Current,
                    _ => throw new InvalidOperationException()
                };

                return new SemesterFilter(relative);
            }

            if (Season == SemesterSeason.Winter)
            {
                return new SemesterFilter(Year.Value, SemesterSeason.Summer);
            }

            return new SemesterFilter(Year.Value + 1, SemesterSeason.Winter);
        }

        /// <summary>
        /// Tries to parse the given value to the semester filter.
        /// </summary>
        /// <remarks>
        /// Parses SemesterFilter according to https://kosapi.fit.cvut.cz/projects/kosapi/wiki/SemesterFilter.
        /// Accepts either CYYS or YYYYS format.
        /// </remarks>
        /// <param name="value">The value to parse.</param>
        /// <param name="filter">The output filter value. Non-null in case the method returns true.</param>
        /// <returns>True if parsing was successful.</returns>
        public static bool TryParse(string value, [NotNullWhen(true)] out SemesterFilter? filter)
        {
            var matching = Regex.Match(value, CYYS);
            if (matching.Success)
            {
                filter = new SemesterFilter
                (
                    (matching.Groups[1].Value == "A"
                        ? 1900
                        : 2000)
                    + int.Parse(matching.Groups[2].Value),
                    matching.Groups[3].Value == "1" ? SemesterSeason.Winter : SemesterSeason.Summer
                );
                return true;
            }

            matching = Regex.Match(value, YYYYS);
            if (matching.Success)
            {
                filter = new SemesterFilter
                (
                    int.Parse(matching.Groups[1].Value),
                    matching.Groups[2].Value == "W" ? SemesterSeason.Winter : SemesterSeason.Summer
                );
                return true;
            }

            if (value == "curr" || value == "current")
            {
                filter = new SemesterFilter(RelativeSemesterFilter.Current);
                return true;
            }

            if (value == "next")
            {
                filter = new SemesterFilter(RelativeSemesterFilter.Next);
                return true;
            }

            if (value == "prev")
            {
                filter = new SemesterFilter(RelativeSemesterFilter.Previous);
                return true;
            }

            if (value == "sched" || value == "scheduling")
            {
                filter = new SemesterFilter(RelativeSemesterFilter.Scheduling);
                return true;
            }

            filter = null;
            return false;
        }

        /// <summary>
        /// Formats the relative filter for kos api.
        /// </summary>
        /// <param name="filter">The filter to format.</param>
        /// <returns>The formatted string.</returns>
        public static string FormatRelativeFilter(RelativeSemesterFilter filter)
            => filter switch
            {
                RelativeSemesterFilter.Current => "curr",
                RelativeSemesterFilter.Next => "next",
                RelativeSemesterFilter.Previous => "prev",
                RelativeSemesterFilter.Scheduling => "sched",
                _ => throw new ArgumentException(nameof(filter))
            };

        /// <inheritdoc />
        public override string ToString()
            => IsAbsolute()
                ? (Year + (Season == SemesterSeason.Summer
                    ? "S"
                    : "W"))
                : FormatRelativeFilter((RelativeSemesterFilter)RelativeFilter);

        /// <summary>
        /// The position of the semester in the academical year.
        /// </summary>
        public enum SemesterSeason
        {
            /// <summary>
            /// The semester is the first one of the academical year
            /// (typically starts on September and ends on February).
            /// </summary>
            Winter,

            /// <summary>
            /// The semester is the second one of the academical year
            /// (typically starts on February and ends on June).
            /// </summary>
            Summer,
        }

        /// <summary>
        /// Relative filter of the semester.
        /// </summary>
        public enum RelativeSemesterFilter
        {
            /// <summary>
            /// The current semester.
            /// </summary>
            Current,

            /// <summary>
            /// The next semester.
            /// </summary>
            Next,

            /// <summary>
            /// The previous semester.
            /// </summary>
            Previous,

            /// <summary>
            /// The scheduling semester.
            /// </summary>
            Scheduling
        }
    }
}