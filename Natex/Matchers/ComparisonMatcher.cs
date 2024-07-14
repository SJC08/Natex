using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for comparing value with the given one.
    /// </summary>
    public class ComparisonMatcher : NatexBasicMatcher<IComparable>
    {
        public override bool? Match(Natex natex, IComparable value)
        {
            string pattern = natex.Pattern;
            if (pattern.StartsWith("<="))
                return CompareLessThanOrEqual(pattern[2..], value);
            if (pattern.StartsWith('≤'))
                return CompareLessThanOrEqual(pattern[1..], value);
            if (pattern.StartsWith('<'))
                return CompareLessThan(pattern[1..], value);
            if (pattern.StartsWith(">="))
                return CompareGreaterThanOrEqual(pattern[2..], value);
            if (pattern.StartsWith('≥'))
                return CompareGreaterThanOrEqual(pattern[1..], value);
            if (pattern.StartsWith('>'))
                return CompareGreaterThan(pattern[1..], value);
            else
                return CompareEquality(pattern, value);
        }

        protected virtual bool? CompareLessThan(string input, IComparable value)
            => input.TryChangeType(value.GetType(), out var result) ? value.CompareTo(result) < 0 : null;

        protected virtual bool? CompareGreaterThan(string input, IComparable value)
            => input.TryChangeType(value.GetType(), out var result) ? value.CompareTo(result) > 0 : null;

        protected virtual bool? CompareLessThanOrEqual(string input, IComparable value)
            => input.TryChangeType(value.GetType(), out var result) ? value.CompareTo(result) <= 0 : null;

        protected virtual bool? CompareGreaterThanOrEqual(string input, IComparable value)
            => input.TryChangeType(value.GetType(), out var result) ? value.CompareTo(result) >= 0 : null;

        protected virtual bool? CompareEquality(string input, IComparable value)
            => input.TryChangeType(value.GetType(), out var result) && value.CompareTo(result) == 0 ? true : null;
    }
}
