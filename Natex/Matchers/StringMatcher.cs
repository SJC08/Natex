namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching the string representation of an object.
    /// </summary>
    public class StringMatcher : NatexMatcher
    {
        public override NatexMatchResult Match(object value, Natex natex)
        {
            return natex.Pattern == value?.ToString() ? NatexMatchResult.Success : NatexMatchResult.Default;
        }
    }
}
