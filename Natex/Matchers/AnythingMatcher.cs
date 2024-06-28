using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    public class AnythingMatcher : NatexMatcher
    {
        public List<(string, bool)> Map { get; set; } =
        [
            new(string.Empty, false),
            new("*", true),
            new("any", true),
        ];

        public override bool? Match(object value, Natex natex)
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
