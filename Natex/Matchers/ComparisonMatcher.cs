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
            string str = natex.Pattern;
            // Less than or equal operator.
            if (str.StartsWith("<="))
            {
                str = str[2..];
                return value => str.TryChangeType(value.GetType(), out var result) ? Compare(value, result) <= 0 : null;
            }
            if (str.StartsWith('≤'))
            {
                str = str[1..];
                return value => str.TryChangeType(value.GetType(), out var result) ? Compare(value, result) <= 0 : null;
            }
            // Less than operator.
            if (str.StartsWith('<'))
            {
                str = str[1..];
                return value => str.TryChangeType(value.GetType(), out var result) ? Compare(value, result) < 0 : null;
            }       
            if (str.StartsWith('＜'))
            {
                str = str[1..];
                return value => str.TryChangeType(value.GetType(), out var result) ? Compare(value, result) < 0 : null;
            }   
            // Greater than or equal operator.
            if (str.StartsWith(">="))
            {
                str = str[2..];
                return value => str.TryChangeType(value.GetType(), out var result) ? Compare(value, result) >= 0 : null;
            }        
            if (str.StartsWith('≥'))
            {
                str = str[1..];
                return value => str.TryChangeType(value.GetType(), out var result) ? Compare(value, result) >= 0 : null;
            }           
            // Greater than operator.
            if (str.StartsWith('>'))
            {
                str = str[1..];
                return value => str.TryChangeType(value.GetType(), out var result) ? Compare(value, result) > 0 : null;
            }
            if (str.StartsWith('＞'))
            {
                str = str[1..];
                return value => str.TryChangeType(value.GetType(), out var result) ? Compare(value, result) > 0 : null;
            }
            // Equality operator.
            if (str.StartsWith('='))
            {
                str = str[1..];
                return value => str.TryChangeType(value.GetType(), out var result) ? Compare(value, result) == 0 : null;
            }
            return value => str.TryChangeType(value.GetType(), out var result) && Compare(value, result) == 0 ? true : null;
        }

        protected virtual int Compare(IComparable value, object obj) => value.CompareTo(obj);
    }
}
