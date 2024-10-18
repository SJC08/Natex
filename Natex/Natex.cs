using Asjc.Collections.Extended;
using Asjc.Natex.Matchers;

namespace Asjc.Natex
{
    public class Natex
    {
        private readonly Dictionary<INatexMatcher, Func<object?, bool?>?> map = [];

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
        /// Initializes a new instance of the <see cref="Natex"/> class with with an empty pattern and settings copied from an existing <see cref="Natex"/> object.
        /// </summary>
        /// <param name="natex">An existing <see cref="Natex"/> object from which to copy settings.</param>
        public Natex(Natex natex)
        {
            Pattern = string.Empty;
            Matchers = new(pairs: natex.Matchers);
            Mode = natex.Mode;
            CaseInsensitive = natex.CaseInsensitive;
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
#if NET8_0
        public string Pattern { get; init; }
#else
        public string Pattern { get; }
#endif

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
                bool? result = map[matcher]?.Invoke(value);
                if (result != null) // No return for null.
                    return (bool)result;
            }
            return false; // We tried our best.
        }

        /// <summary>
        /// Use all matchers to parse.
        /// </summary>
        /// <param name="force"><see langword="true"/> if repeated parsing is allowed; otherwise, <see langword="false"/>.</param>
        public void Parse(bool force = false)
        {
            foreach (var matcher in Matchers)
                Parse(matcher, force);
        }

        /// <summary>
        /// Use the specified matcher to parse.
        /// </summary>
        /// <param name="matcher">The specified matcher for matching.</param>
        /// <param name="force"><see langword="true"/> if if repeated parsing is allowed; otherwise, <see langword="false"/>.</param>
        public void Parse(INatexMatcher matcher, bool force = false)
        {
            if (!map.ContainsKey(matcher) || force)
            {
                lock (map)
                {
                    if (!map.ContainsKey(matcher))
                        map.Add(matcher, matcher.Create(this));
                }

            }
        }

        /// <inheritdoc/>
        public override string ToString() => Pattern;
    }
}
