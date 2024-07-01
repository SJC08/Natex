namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for handling multiple patterns.
    /// </summary>
    public class MultiPatternMatcher : NatexMatcher<object, Natex[]>
    {
        public override Natex[]? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(" ");
            return arr.Length > 1 ? arr.Select(p => new Natex(p, natex)).ToArray() : null;
        }

        public override bool? Match(Natex natex, object value, Natex[] data)
        {
            return data.All(n => n.Match(value)) ? true : null;
        }
    }
}
