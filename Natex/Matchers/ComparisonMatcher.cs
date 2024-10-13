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
            {
                return value =>
                {
                    int? i = Compare(pattern[2..], value);
                    return i != null ? i <= 0 : null;
                };
            }
            if (pattern.StartsWith('≤'))
            {
                return value =>
                {
                    int? i = Compare(pattern[1..], value);
                    return i != null ? i <= 0 : null;
                };
            }
            // Less than operator.
            if (pattern.StartsWith('<'))
            {
                return value =>
                {
                    int? i = Compare(pattern[1..], value);
                    return i != null ? i < 0 : null;
                };
            }
            if (pattern.StartsWith('＜'))
            {
                return value =>
                {
                    int? i = Compare(pattern[1..], value);
                    return i != null ? i < 0 : null;
                };
            }
            // Greater than or equal operator.
            if (pattern.StartsWith(">="))
            {
                return value =>
                {
                    int? i = Compare(pattern[2..], value);
                    return i != null ? i >= 0 : null;
                };
            }
            if (pattern.StartsWith('≥'))
            {
                return value =>
                {
                    int? i = Compare(pattern[1..], value);
                    return i != null ? i >= 0 : null;
                };
            }
            // Greater than operator.
            if (pattern.StartsWith('>'))
            {
                return value =>
                {
                    int? i = Compare(pattern[1..], value);
                    return i != null ? i > 0 : null;
                };
            }
            if (pattern.StartsWith('＞'))
            {
                return value =>
                {
                    int? i = Compare(pattern[1..], value);
                    return i != null ? i > 0 : null;
                };
            }
            // Equality operator.
            if (pattern.StartsWith('='))
            {
                return value =>
                {
                    int? i = Compare(pattern[1..], value);
                    return i != null ? i == 0 : null;
                };
            }
            return value =>
            {
                int? i = Compare(pattern, value);
                return i == 0 ? true : null;
            };
        }

        protected virtual int? Compare(string input, IComparable value)
        {
            return input.TryChangeType(value.GetType(), out var result) ? value.CompareTo(result) : null;
        }
    }
}
