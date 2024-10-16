
namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for handling multiple patterns.
    /// </summary>
    public class MultiPatternMatcher : INatexMatcher
    {
        /// <inheritdoc/>
        public Func<object?, bool?>? Create(Natex natex)
        {
            var patterns = natex.Pattern.Split(" ");
            if (patterns.Length <= 1) return null;
            var natexes = patterns.Select(p => new Natex(p, natex));
            return value => natexes.All(n => n.Match(value)) ? true : null;
        }
    }
}
