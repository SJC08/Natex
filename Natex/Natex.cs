using Asjc.Natex.Matchers;

namespace Asjc.Natex
{
    public class Natex(string pattern)
    {
        public string Pattern { get; } = pattern;

        public List<INatexMatcher> Matchers { get; set; } = [new ComparisonMatcher()];

        public NatexType Type { get; set; } = NatexType.Single | NatexType.Multiple;

        public bool Match(object obj)
        {
            if (Type.HasFlag(NatexType.Single))
            {
                foreach (var matcher in Matchers)
                {
                    switch (matcher.Match(obj, Pattern))
                    {
                        case 1:
                            return true;
                        case 2:
                            return false;
                    }
                }
            }
            if (Type.HasFlag(NatexType.Multiple))
            {

            }
            return false;
        }

        public override string ToString() => Pattern;
    }
}
