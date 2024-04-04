using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    public class ComparisonMatcher : INatexMatcher
    {
        public int Match(object? obj, object? exp)
        {
            if (obj is IComparable comparable && exp is Natex natex)
            {
                string pattern = natex.Pattern;
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
