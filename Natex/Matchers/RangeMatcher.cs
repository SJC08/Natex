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
            var arr = natex.Pattern.Split('-', '~', '↔');
            if (arr.Length == 2)
                return new(arr[0], arr[1]);
            return null;
        }

        public override bool? Match(IComparable value, Data data, Natex natex)
        {
            Type type = value.GetType();
            if (data.Min.ConvertTo(type, out var min) && data.Max.ConvertTo(type, out var max))
                return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
            return false;
        }

        public record Data(string Min, string Max);
    }
}
