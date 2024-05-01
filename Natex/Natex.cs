using Asjc.Natex.Matchers;

namespace Asjc.Natex
{
    public class Natex
    {
        private readonly Dictionary<INatexMatcher, object?> map = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="Natex"/> class with the specified pattern.
        /// </summary>
        /// <param name="pattern">The Natex pattern to match.</param>
        public Natex(string pattern)
        {
            Pattern = pattern;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Natex"/> class with the specified pattern and settings copied from an existing <see cref="Natex"/> object.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="natex"></param>
        public Natex(string pattern, Natex natex)
        {
            Pattern = pattern;
            Matchers = natex.Matchers;
            Mode = natex.Mode;
            CaseInsensitive = natex.CaseInsensitive;
        }

        /// <summary>
        /// Gets the Natex pattern.
        /// </summary>
        public string Pattern { get; }

        /// <summary>
        /// Gets or sets the list of Natex matchers.
        /// </summary>
        public List<INatexMatcher> Matchers { get; set; } =
        [
            new VariableMatcher(),
            new StringMatcher(),
            new ComparisonMatcher(),
            new RangeMatcher(),
            new RegexMatcher(),
            new PropertyMatcher(),
            new MultiPatternMatcher()
        ];

        /// <summary>
        /// Gets or sets the Natex matching mode.
        /// </summary>
        public NatexMode Mode { get; set; } = NatexMode.Exact;

        /// <summary>
        /// Gets or sets a <see langword="bool"/> indicating whether matching is case insensitive.
        /// </summary>
        public bool CaseInsensitive { get; set; } = true;

        public bool Match(object? value)
        {
            foreach (var matcher in Matchers)
            {
                Parse(matcher);
                object? data = map.GetValueOrDefault(matcher);
                switch (matcher.Match(value, data, this))
                {
                    // No return for Default.
                    case NatexMatchResult.Success:
                        return true;
                    case NatexMatchResult.Failure:
                        return false;
                }
            }
            return false;
        }

        public void Parse()
        {
            foreach (var matcher in Matchers)
                Parse(matcher);
        }

        public void Parse(INatexMatcher matcher)
        {
            // Try to get the existing value.
            bool first = !map.TryGetValue(matcher, out object? data);
            if (matcher.ShouldParse(first, data, this))
                map[matcher] = matcher.Parse(this);
        }

        public override string ToString() => Pattern;
    }
}
