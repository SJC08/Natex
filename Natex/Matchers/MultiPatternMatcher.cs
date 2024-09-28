
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
            var arr = natex.Pattern.Split(" ");
            if (arr.Length <= 1) return null;
            return value => arr.Select(p => new Natex(p, natex)).All(n => n.Match(value)) ? true : null;
        }
    }
}
