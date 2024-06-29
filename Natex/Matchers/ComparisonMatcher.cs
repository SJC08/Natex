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

        public virtual bool? CompareLessThan(string input, IComparable value) 
            => input.ConvertTo(value.GetType(), out var result) ? value.CompareTo(result) < 0 : null;

        public virtual bool? CompareGreaterThan(string input, IComparable value) 
            => input.ConvertTo(value.GetType(), out var result) ? value.CompareTo(result) > 0 : null;

        public virtual bool? CompareLessThanOrEqual(string input, IComparable value) 
            => input.ConvertTo(value.GetType(), out var result) ? value.CompareTo(result) <= 0 : null;

        public virtual bool? CompareGreaterThanOrEqual(string input, IComparable value) 
            => input.ConvertTo(value.GetType(), out var result) ? value.CompareTo(result) >= 0 : null;

        public virtual bool? CompareEquality(string input, IComparable value)
            => input.ConvertTo(value.GetType(), out var result) && value.CompareTo(result) == 0 ? true : null;
    }
}
