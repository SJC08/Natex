using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for comparing value with the given one.
    /// </summary>
    public class ComparisonMatcher : NatexMatcher<IComparable>
    {
        public override bool? Match(IComparable value, Natex natex)
        {
            string pattern = natex.Pattern;
            if (pattern.StartsWith(">="))
            {
                var obj = pattern[2..].ChangeType(value.GetType());
                return obj is null ? null : value.CompareTo(obj) >= 0;
            }
            if (pattern.StartsWith('≥'))
            {
                var obj = pattern[1..].ChangeType(value.GetType());
                return obj is null ? null : value.CompareTo(obj) >= 0;
            }
            if (pattern.StartsWith('>'))
            {
                var obj = pattern[1..].ChangeType(value.GetType());
                return obj is null ? null : value.CompareTo(obj) > 0;
            }
            if (pattern.StartsWith("<="))
            {
                var obj = pattern[2..].ChangeType(value.GetType());
                return obj is null ? null : value.CompareTo(obj) <= 0;
            }
            if (pattern.StartsWith('≤'))
            {
                var obj = pattern[1..].ChangeType(value.GetType());
                return obj is null ? null : value.CompareTo(obj) <= 0;
            }
            if (pattern.StartsWith('<'))
            {
                var obj = pattern[1..].ChangeType(value.GetType());
                return obj is null ? null : value.CompareTo(obj) < 0;
            }
            else
            {
                var obj = pattern.ChangeType(value.GetType());
                return obj is null || value.CompareTo(obj) != 0 ? null : true;
            }
        }
    }
}
