
namespace Asjc.Natex.Matchers
{
    public class NegationMatcher : INatexMatcher
    {
        /// <inheritdoc/>
        public Func<object?, bool?>? Create(Natex natex)
        {
            if (natex.Pattern.StartsWith('!'))
            {
                Natex n = new(natex.Pattern[1..], natex);
                return value => !n.Match(value);
            }
            return null;
        }
    }
}
