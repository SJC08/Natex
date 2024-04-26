using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for comparing value with the given one.
    /// </summary>
    public class ComparisonMatcher : NatexMatcher<IComparable>
    {
        public override NatexMatchResult Match(IComparable value, Natex natex)
        {
            string pattern = natex.Pattern;
            if (pattern.StartsWith(">="))
            {
                var obj = pattern[2..].ChangeType(value.GetType());
                return value.CompareTo(obj) >= 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
            }
            if (pattern.StartsWith('≥'))
            {
                var obj = pattern[1..].ChangeType(value.GetType());
                return value.CompareTo(obj) >= 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
            }
            if (pattern.StartsWith('>'))
            {
                var obj = pattern[1..].ChangeType(value.GetType());
                return value.CompareTo(obj) > 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
            }
            if (pattern.StartsWith("<="))
            {
                var obj = pattern[2..].ChangeType(value.GetType());
                return value.CompareTo(obj) <= 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
            }
            if (pattern.StartsWith('≤'))
            {
                var obj = pattern[1..].ChangeType(value.GetType());
                return value.CompareTo(obj) <= 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
            }
            if (pattern.StartsWith('<'))
            {
                var obj = pattern[1..].ChangeType(value.GetType());
                return value.CompareTo(obj) < 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
            }
            return NatexMatchResult.Default;
        }
    }
}
