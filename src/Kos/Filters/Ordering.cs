//
//   Ordering.cs
//
//   Copyright (c) Christofel authors. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kos.Filters
{
    /// <summary>
    /// Represents kos ordering parameter for atom feeds.
    /// </summary>
    public class Ordering
    {
        private const string RegexPattern = "^(-?[a-z]+)*$";

        private readonly List<ParameterOrdering> _orderings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ordering"/> class.
        /// </summary>
        public Ordering()
        {
            _orderings = new List<ParameterOrdering>();
        }

        /// <summary>
        /// Tries to parse the given value to the ordering.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="ordering">The output ordering value. Non-null in case the method returns true.</param>
        /// <returns>True if parsing was successful.</returns>
        public static bool TryParse(string value, [NotNullWhen(true)] out Ordering? ordering)
        {
            var parameters = value.Split(',');
            if (!Regex.IsMatch(value, RegexPattern))
            {
                ordering = null;
                return false;
            }

            ordering = new Ordering();
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            foreach (var parameter in parameters)
            {
                var ascending = parameter[0] == '-';
                var parameterName = ascending
                    ? parameter
                    : parameter.Skip(1).ToString();
                if (parameterName is not null)
                {
                    ordering.AppendParameter(parameterName, ascending);
                }
            }

            return true;
        }

        /// <summary>
        /// The requested ordering of parameters.
        /// </summary>
        public IReadOnlyList<ParameterOrdering> Orderings => _orderings;

        /// <summary>
        /// Appends the given parameter at the end of the ordering.
        /// </summary>
        /// <remarks>
        /// The parameter will have the least value.
        /// </remarks>
        /// <param name="parameter">The name of the parameter.</param>
        /// <param name="ascending">Whether the order should be ascending.</param>
        /// <returns>The ordering object.</returns>
        public Ordering AppendParameter(string parameter, bool ascending)
        {
            _orderings.Add(new ParameterOrdering(parameter, ascending));
            return this;
        }

        /// <summary>
        /// Prepends the given parameter at the start of the ordering.
        /// </summary>
        /// <remarks>
        /// The parameter will have the least value.
        /// </remarks>
        /// <param name="parameter">The name of the parameter.</param>
        /// <param name="ascending">Whether the order should be ascending.</param>
        /// <returns>The ordering object.</returns>
        public Ordering PrependParameter(string parameter, bool ascending)
        {
            _orderings.Insert(0, new ParameterOrdering(parameter, ascending));
            return this;
        }

        /// <summary>
        /// Inserts the given parameter at the specified index of the ordering.
        /// </summary>
        /// <remarks>
        /// The parameter will have the least value.
        /// </remarks>
        /// <param name="index">The index to insert at.</param>
        /// <param name="parameter">The name of the parameter.</param>
        /// <param name="ascending">Whether the order should be ascending.</param>
        /// <returns>The ordering object.</returns>
        public Ordering InsertParameter(int index, string parameter, bool ascending)
        {
            _orderings.Insert(index, new ParameterOrdering(parameter, ascending));
            return this;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            List<string> ordering = new List<string>();
            foreach (var parameterOrder in _orderings)
            {
                ordering.Add
                (
                    (parameterOrder.Ascending
                        ? string.Empty
                        : "-") +
                    parameterOrder.ParameterName
                );
            }

            return string.Join(',', ordering);
        }

        /// <summary>
        /// Represents the ordering of one single parameter.
        /// </summary>
        /// <param name="ParameterName">The name of the parameter to be ordered.</param>
        /// <param name="Ascending">Whether the order is ascending. The order is descending if false.</param>
        public record ParameterOrdering(string ParameterName, bool Ascending);
    }
}