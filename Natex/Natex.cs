using Asjc.Natex.Matchers;

namespace Asjc.Natex
{
    public class Natex
    {
        private readonly Dictionary<INatexMatcher, object?> map = [];

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

        public List<INatexMatcher> Matchers { get; set; } = [new ComparisonMatcher(), new PropertyMatcher()];

        public bool Match(object? obj)
        {
            foreach (var matcher in Matchers)
            {
                map.TryAdd(matcher, matcher.Parse(this));
                switch (matcher.Match(obj, map[matcher]))
                {
                    case 1:
                        return true;
                    case 2:
                        return false;
                }
            }
            return false;
        }

        public override string ToString() => Pattern;
    }
}
