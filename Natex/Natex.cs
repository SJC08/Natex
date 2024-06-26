﻿using Asjc.Collections.Extended;
using Asjc.Natex.Matchers;

namespace Asjc.Natex
{
    public class Natex
    {
        private readonly Dictionary<INatexMatcher, object?> map = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="Natex"/> class with an empty pattern.
        /// </summary>
        public Natex()
        {
            Pattern = string.Empty;
            Matchers =
            [
                new AnythingMatcher(),
                new NullOrEmptyMatcher(),
                new VariableMatcher(),
                new NegationMatcher(),
                new StringMatcher(),
                new ComparisonMatcher(),
                new RangeMatcher(),
                new ListMatcher(),
                new RegexMatcher(),
                new MultiPatternMatcher(),
                new PropertyMatcher(),
            ];
            Mode = NatexMode.Exact;
            CaseInsensitive = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Natex"/> class with the specified pattern.
        /// </summary>
        /// <param name="pattern">The Natex pattern to match.</param>
        public Natex(string pattern)
        {
            Pattern = pattern;
            Matchers =
            [
                new AnythingMatcher(),
                new NullOrEmptyMatcher(),
                new VariableMatcher(),
                new NegationMatcher(),
                new StringMatcher(),
                new ComparisonMatcher(),
                new RangeMatcher(),
                new ListMatcher(),
                new RegexMatcher(),
                new MultiPatternMatcher(),
                new PropertyMatcher(),
            ];
            Mode = NatexMode.Exact;
            CaseInsensitive = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Natex"/> class with the specified pattern and settings copied from an existing <see cref="Natex"/> object.
        /// </summary>
        /// <param name="pattern">The Natex pattern to match.</param>
        /// <param name="natex">An existing <see cref="Natex"/> object from which to copy settings.</param>
        public Natex(string pattern, Natex natex)
        {
            Pattern = pattern;
            Matchers = new(pairs: natex.Matchers);
            Mode = natex.Mode;
            CaseInsensitive = natex.CaseInsensitive;
        }

        /// <summary>
        /// Gets the Natex pattern.
        /// </summary>
        public string Pattern { get; init; }

        /// <summary>
        /// Gets or sets the list of Natex matchers.
        /// </summary>
        public UniqueTypeList<INatexMatcher> Matchers { get; set; }

        /// <summary>
        /// Gets or sets the Natex matching mode.
        /// </summary>
        public NatexMode Mode { get; set; }

        /// <summary>
        /// Gets or sets a <see langword="bool"/> indicating whether matching is case insensitive.
        /// </summary>
        public bool CaseInsensitive { get; set; }

        public bool Match(object? value)
        {
            foreach (var matcher in Matchers)
            {
                Parse(matcher);
                object? data = map.GetValueOrDefault(matcher);
                bool? result = matcher.Match(this, data, value);
                if (result != null) // No return for null.
                    return (bool)result;
            }
            return false;
        }

        /// <summary>
        /// Use all matchers to parse.
        /// </summary>
        /// <param name="force"><see langword="true"/> if <see cref="INatexMatcher.ShouldParse"/> should not be performed to check; otherwise, <see langword="false"/>.</param>
        public void Parse(bool force = false)
        {
            foreach (var matcher in Matchers)
                Parse(matcher, force);
        }

        /// <summary>
        /// Use the specified matcher to parse.
        /// </summary>
        /// <param name="matcher">The specified matcher for matching.</param>
        /// <param name="force"><see langword="true"/> if <see cref="INatexMatcher.ShouldParse"/> is needed to check; otherwise, <see langword="false"/>.</param>
        public void Parse(INatexMatcher matcher, bool force = false)
        {
            // Try to get the existing value.
            bool first = !map.TryGetValue(matcher, out object? data);
            if (force || matcher.ShouldParse(this, data, first))
                map[matcher] = matcher.Parse(this);
        }

        public override string ToString() => Pattern;
    }
}
