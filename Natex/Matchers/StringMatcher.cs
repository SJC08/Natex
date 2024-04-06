namespace Asjc.Natex.Matchers
{
    public class StringMatcher : NatexMatcher
    {
        public override int Match(object? obj, Natex natex)
        {
            return natex.Pattern == obj?.ToString() ? 1 : 0;
        }
    }
}
