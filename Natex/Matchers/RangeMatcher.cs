using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for determining whether a value is in a particular range.
    /// </summary>
    public class RangeMatcher : NatexMatcher<IComparable, RangeMatcher.Data>
    {
        public override Data? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(['-', '~', '↔']);
            if (arr.Length == 2)
                return new(arr[0], arr[1]);
            return null;
        }

        public override bool? Match(IComparable value, Data data, Natex natex)
        {
            var c1 = data.Min.ChangeType(value.GetType());
            var c2 = data.Max.ChangeType(value.GetType());
            return value.CompareTo(c1) >= 0 && value.CompareTo(c2) <= 0;
        }

        public record Data(string Min, string Max);
    }
}
