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

        public Natex(string pattern, Natex natex)
        {
            Pattern = pattern;
            Matchers = natex.Matchers;
        }

        public string Pattern { get; }

        public List<INatexMatcher> Matchers { get; set; } =
        [
            new StringMatcher(),
            new ComparisonMatcher(),
            new RangeMatcher(),
            new RegexMatcher(),
            new PropertyMatcher(),
            new MultiPatternMatcher()
        ];

        public bool Match(object? obj)
        {
            foreach (var matcher in Matchers)
            {
                map.TryAdd(matcher, matcher.Parse(this));
                switch (matcher.Match(obj, map[matcher], this))
                {
                    case NatexMatchResult.Success:
                        return true;
                    case NatexMatchResult.Failure:
                        return false;
                }
            }
            return false;
        }

        public override string ToString() => Pattern;
    }
}
