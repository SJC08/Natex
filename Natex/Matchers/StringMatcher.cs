using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching the string representation of an object.
    /// </summary>
    public class StringMatcher : NatexMatcher
    {
        public override NatexMatchResult Match(object value, Natex natex)
        {
            if (natex.Mode == NatexMode.Exact)
            {
                if (natex.Pattern.Equals(value.ToString(), natex.CaseInsensitive))
                    return NatexMatchResult.Success;
                else
                    return NatexMatchResult.Default;
            }
            else
            {
                if (natex.Pattern.Contains(value.ToString(), natex.CaseInsensitive))
                    return NatexMatchResult.Success;
                else
                    return NatexMatchResult.Default;
            }
        }
    }
}
