namespace Asjc.Natex.Matchers
{
    public class StringMatcher : NatexMatcher
    {
        public override MatchResult Match(object? obj, Natex natex)
        {
            return natex.Pattern == obj?.ToString() ? MatchResult.Success : MatchResult.Default;
        }
    }
}
