using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    public class AnythingMatcher : NatexBasicMatcher
    {
        public List<(string, bool)> Map { get; set; } =
        [
            new(string.Empty, false),
            new("*", true),
            new("any", true),
        ];

        public override bool? Match(Natex natex, object value)
        {
            foreach (var item in Map)
            {
                if (item.Item1.Equals(natex.Pattern, natex.CaseInsensitive))
                    return item.Item2;
            }
            return null;
        }
    }
}
