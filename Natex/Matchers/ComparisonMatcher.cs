using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    public class ComparisonMatcher : NatexMatcher
    {
        public override NatexMatchResult Match(object? value, Natex natex)
        {
            if (value is IComparable comparable)
            {
                string pattern = natex.Pattern;
                if (pattern.StartsWith(">="))
                {
                    var obj = pattern[2..].ChangeType(comparable.GetType());
                    return obj != null && comparable.CompareTo(obj) >= 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
                }
                if (pattern.StartsWith('≥'))
                {
                    var obj = pattern[1..].ChangeType(comparable.GetType());
                    return obj != null && comparable.CompareTo(obj) >= 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
                }
                if (pattern.StartsWith('>'))
                {
                    var obj = pattern[1..].ChangeType(comparable.GetType());
                    return obj != null && comparable.CompareTo(obj) > 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
                }
                if (pattern.StartsWith("<="))
                {
                    var obj = pattern[2..].ChangeType(comparable.GetType());
                    return obj != null && comparable.CompareTo(obj) <= 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
                }
                if (pattern.StartsWith('≤'))
                {
                    var obj = pattern[1..].ChangeType(comparable.GetType());
                    return obj != null && comparable.CompareTo(obj) <= 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
                }
                if (pattern.StartsWith('<'))
                {
                    var obj = pattern[1..].ChangeType(comparable.GetType());
                    return obj != null && comparable.CompareTo(obj) < 0 ? NatexMatchResult.Success : NatexMatchResult.Failure;
                }
            }
            return NatexMatchResult.Default;
        }
    }
}
