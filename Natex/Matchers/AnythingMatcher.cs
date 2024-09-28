using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    public class AnythingMatcher : INatexMatcher
    {
        public List<(string, bool)> Map { get; set; } =
        [
            new(string.Empty, false),
            new("*", true),
            new("any", true),
        ];

        /// <inheritdoc/>
        public Func<object?, bool?>? Create(Natex natex)
        {
            foreach (var item in Map)
            {
                if (natex.Pattern.Equals(item.Item1, natex.CaseInsensitive))
                    return _ => item.Item2;
            }
            return null;
        }
    }
}
