using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for determining whether a value is in a particular range.
    /// </summary>
    public class RangeMatcher : NatexMatcher<RangeMatcher.Data, IComparable>
    {
        public override Data? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split('-', '~', '↔');
            if (arr.Length == 2)
                return new(arr[0], arr[1]);
            return null;
        }

        public override bool? Match(Natex natex, Data data, IComparable value)
        {
            Type type = value.GetType();
            if (data.Min.TryChangeType(type, out var min) && data.Max.TryChangeType(type, out var max))
                return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
            return false;
        }

        public record Data(string Min, string Max);
    }
}
