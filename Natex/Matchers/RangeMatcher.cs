using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for determining whether a value is in a particular range.
    /// </summary>
    public class RangeMatcher : NatexMatcher<IComparable>
    {
        public override Func<IComparable, bool?>? Create(Natex natex)
        {
            var arr = natex.Pattern.Split('-', '~', '↔');
            if (arr.Length == 2)
            {
                return value =>
                {
                    Type type = value.GetType();
                    if (arr[0].TryChangeType(type, out var min) && arr[1].TryChangeType(type, out var max))
                        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
                    return false;
                };
            }
            return null;
        }
    }
}
