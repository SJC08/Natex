using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching the string representation of an object.
    /// </summary>
    public class StringMatcher : NatexMatcher
    {
        public override bool? Match(object value, Natex natex)
        {
            if (natex.Mode == NatexMode.Exact)
            {
                if (natex.Pattern.Equals(value.ToString(), natex.CaseInsensitive))
                    return true;
                else
                    return null;
            }
            else
            {
                if (natex.Pattern.Contains(value.ToString(), natex.CaseInsensitive))
                    return true;
                else
                    return null;
            }
        }
    }
}
