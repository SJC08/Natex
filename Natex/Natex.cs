using Asjc.Natex.Matchers;

namespace Asjc.Natex
{
    public class Natex
    {
        public string Pattern { get; }

        public List<NatexMatcher> Matchers { get; set; } = [new PropertyMatcher(), new ComparisonMatcher()];

        public Natex(string pattern)
        {
            Pattern = pattern;
        }

        public Natex(string pattern, Natex natex)
        {
            Pattern = pattern;
            Matchers = natex.Matchers;
        }

        public bool Match(object? obj)
        {
            foreach (var matcher in Matchers)
            {
                if (!matcher.Parsed)
                    matcher.Parse(this);
                switch (matcher.Match(obj))
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
