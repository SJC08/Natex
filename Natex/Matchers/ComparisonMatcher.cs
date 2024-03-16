using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    public class ComparisonMatcher : INatexMatcher
    {
        public int Match(object obj, string pattern)
        {
            if (obj is IComparable comparable)
            {
                if (pattern.StartsWith(">="))
                {
                    var value = pattern[2..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) >= 0 ? 1 : 2;
                }
                if (pattern.StartsWith('≥'))
                {
                    var value = pattern[1..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) >= 0 ? 1 : 2;
                }
                if (pattern.StartsWith('>'))
                {
                    var value = pattern[1..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) > 0 ? 1 : 2;
                }
                if (pattern.StartsWith("<="))
                {
                    var value = pattern[2..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) <= 0 ? 1 : 2;
                }
                if (pattern.StartsWith('≤'))
                {
                    var value = pattern[1..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) <= 0 ? 1 : 2;
                }
                if (pattern.StartsWith('<'))
                {
                    var value = pattern[1..].ChangeType(comparable.GetType());
                    return value != null && comparable.CompareTo(value) < 0 ? 1 : 2;
                }
            }
            return 0;
        }
    }
}
