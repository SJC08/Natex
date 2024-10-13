using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for comparing value with the given one.
    /// </summary>
    public class ComparisonMatcher : NatexMatcher<IComparable>
    {
        /// <inheritdoc/>
        public override Func<IComparable, bool?>? Create(Natex natex)
        {
            string pattern = natex.Pattern;
            // Less than or equal operator.
            if (pattern.StartsWith("<="))
                return value => pattern[2..].TryChangeType(value.GetType(), out var result) ? Compare(value, result) <= 0 : null;
            if (pattern.StartsWith('≤'))
                return value => pattern[1..].TryChangeType(value.GetType(), out var result) ? Compare(value, result) <= 0 : null;
            // Less than operator.
            if (pattern.StartsWith('<'))
                return value => pattern[1..].TryChangeType(value.GetType(), out var result) ? Compare(value, result) < 0 : null;
            if (pattern.StartsWith('＜'))
                return value => pattern[1..].TryChangeType(value.GetType(), out var result) ? Compare(value, result) < 0 : null;
            // Greater than or equal operator.
            if (pattern.StartsWith(">="))
                return value => pattern[2..].TryChangeType(value.GetType(), out var result) ? Compare(value, result) >= 0 : null;
            if (pattern.StartsWith('≥'))
                return value => pattern[1..].TryChangeType(value.GetType(), out var result) ? Compare(value, result) >= 0 : null;
            // Greater than operator.
            if (pattern.StartsWith('>'))
                return value => pattern[1..].TryChangeType(value.GetType(), out var result) ? Compare(value, result) > 0 : null;
            if (pattern.StartsWith('＞'))
                return value => pattern[1..].TryChangeType(value.GetType(), out var result) ? Compare(value, result) > 0 : null;
            // Equality operator.
            if (pattern.StartsWith('='))
                return value => pattern[1..].TryChangeType(value.GetType(), out var result) ? Compare(value, result) == 0 : null;
            return value => pattern.TryChangeType(value.GetType(), out var result) && Compare(value, result) == 0 ? true : null;
        }

        protected virtual int Compare(IComparable value, object obj) => value.CompareTo(obj);
    }
}
