using System.Text.RegularExpressions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching via Regex.
    /// </summary>
    public class RegexMatcher : NatexMatcher<string, Regex>
    {
        public override Regex? Parse(Natex natex)
        {
            try
            {
                return new Regex(natex.Pattern);
            }
            catch
            {
                return null;
            }
        }

        public override NatexMatchResult Match(string value, ref Regex data, Natex natex)
        {
            return data.IsMatch(value) ? NatexMatchResult.Success : NatexMatchResult.Failure;
        }
    }
}
