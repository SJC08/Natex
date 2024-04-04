using System.Text.RegularExpressions;

namespace Asjc.Natex.Matchers
{
    public class RegexMatcher : INatexMatcher
    {
        public object? Parse(Natex natex)
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

        public int Match(object? obj, object? exp)
        {
            if (obj is string str && exp is Regex regex)
            {
                return regex.IsMatch(str) ? 1 : 2;
            }
            return 0;
        }
    }
}
