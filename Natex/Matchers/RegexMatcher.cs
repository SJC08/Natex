using System.Text.RegularExpressions;

namespace Asjc.Natex.Matchers
{
    public class RegexMatcher : NatexMatcher<Regex>
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

        public override int Match(object? obj, Regex data)
        {
            if (obj is string str)
                return data.IsMatch(str) ? 1 : 2;
            return 0;
        }
    }
}
