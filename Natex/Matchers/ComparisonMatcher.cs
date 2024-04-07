using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    public class ComparisonMatcher : NatexMatcher
    {
        public override MatchResult Match(object? obj, Natex natex)
        {
            if (obj is IComparable comparable)
            {
                string pattern = natex.Pattern;
                if (pattern.StartsWith(">="))
                {
                    var value = pattern[2..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) >= 0 ? MatchResult.Match : MatchResult.Mismatch;
                }
                if (pattern.StartsWith('≥'))
                {
                    var value = pattern[1..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) >= 0 ? MatchResult.Match : MatchResult.Mismatch;
                }
                if (pattern.StartsWith('>'))
                {
                    var value = pattern[1..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) > 0 ? MatchResult.Match : MatchResult.Mismatch;
                }
                if (pattern.StartsWith("<="))
                {
                    var value = pattern[2..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) <= 0 ? MatchResult.Match : MatchResult.Mismatch;
                }
                if (pattern.StartsWith('≤'))
                {
                    var value = pattern[1..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) <= 0 ? MatchResult.Match : MatchResult.Mismatch;
                }
                if (pattern.StartsWith('<'))
                {
                    var value = pattern[1..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) < 0 ? MatchResult.Match : MatchResult.Mismatch;
                }
            }
            return 0;
        }
    }
}
