namespace Asjc.Natex.Matchers
{
    public class MultiPatternMatcher : NatexMatcher<IEnumerable<Natex>>
    {
        public override IEnumerable<Natex>? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(" ");
            return arr.Length > 1 ? arr.Select(p => new Natex(p, natex)) : null;
        }

        public override int Match(object? obj, IEnumerable<Natex> data)
        {
            return data.All(n => n.Match(obj)) ? 1 : 2;
        }
    }
}
