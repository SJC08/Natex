namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for handling multiple patterns.
    /// </summary>
    public class MultiPatternMatcher : NatexMatcher<Natex[]>
    {
        public override Natex[]? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(" ");
            return arr.Length > 1 ? arr.Select(p => new Natex(p, natex)).ToArray() : null;
        }

        public override bool? Match(Natex natex, Natex[] data, object value)
        {
            return data.All(n => n.Match(value)) ? true : null;
        }
    }
}
