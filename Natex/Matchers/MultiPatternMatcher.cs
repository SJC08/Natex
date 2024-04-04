namespace Asjc.Natex.Matchers
{
    public class MultiPatternMatcher : INatexMatcher
    {
        public object? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(" ");
            return arr.Length > 1 ? arr.Select(p => new Natex(p, natex)) : null;
        }

        public int Match(object? obj, object? exp)
        {
            if (exp is IEnumerable<Natex> natexes)
                return natexes.All(n => n.Match(obj)) ? 1 : 2;
            else
                return 0;
        }
    }
}
