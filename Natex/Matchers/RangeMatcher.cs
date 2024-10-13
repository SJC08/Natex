using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for determining whether a value is in a particular range.
    /// </summary>
    public class RangeMatcher : NatexMatcher<IComparable>
    {
        /// <inheritdoc/>
        public override Func<IComparable, bool?>? Create(Natex natex)
        {
            var arr = natex.Pattern.Split('-', '~', '↔');
            if (arr.Length == 2)
            {
                return value =>
                {
                    Type type = value.GetType();
                    if (arr[0].TryChangeType(type, out var min) && arr[1].TryChangeType(type, out var max))
                        return Compare(min, value) >= 0 && Compare(max, value) <= 0;
                    return null;
                };
            }
            return null;
        }

        protected virtual int Compare(object obj, IComparable value) => value.CompareTo(obj);
    }
}
