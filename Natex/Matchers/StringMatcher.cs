namespace Asjc.Natex.Matchers
{
    public class StringMatcher : NatexMatcher
    {
        public override NatexMatchResult Match(object value, Natex natex)
        {
            return natex.Pattern == value?.ToString() ? NatexMatchResult.Success : NatexMatchResult.Default;
        }
    }
}
