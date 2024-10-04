using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    public class ConstantMatcher : INatexMatcher
    {
        public List<(string, bool)> Constants { get; set; } =
        [
            new("*", true),
            new("any", true),
        ];

        /// <inheritdoc/>
        public Func<object?, bool?>? Create(Natex natex)
        {
            foreach (var item in Constants)
            {
                if (natex.Pattern.Equals(item.Item1, natex.CaseInsensitive))
                    return _ => item.Item2;
            }
            return null;
        }
    }
}
