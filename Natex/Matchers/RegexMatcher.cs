using System.Text.RegularExpressions;

namespace Asjc.Natex.Matchers
{
    public class RegexMatcher : NatexMatcher<Regex, string>
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

        public override NatexMatchResult Match(string value, Regex data)
        {
            return data.IsMatch(value) ? NatexMatchResult.Success : NatexMatchResult.Failure;
        }
    }
}
