namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for handling multiple patterns.
    /// </summary>
    public class MultiPatternMatcher : NatexMatcher<object, IEnumerable<Natex>>
    {
        public override IEnumerable<Natex>? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(" ");
            return arr.Length > 1 ? arr.Select(p => new Natex(p, natex)) : null;
        }

        public override NatexMatchResult Match(object value, ref IEnumerable<Natex> data, Natex natex)
        {
            return data.All(n => n.Match(value)) ? NatexMatchResult.Success : NatexMatchResult.Default;
        }
    }
}
