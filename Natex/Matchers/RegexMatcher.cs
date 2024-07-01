using System.Text.RegularExpressions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching via Regex.
    /// </summary>
    public class RegexMatcher : NatexMatcher<RegexMatcher.Data, string>
    {
        public override Data? Parse(Natex natex)
        {
            try
            {
                var pattern = natex.Mode == NatexMode.Exact ? $"^{natex.Pattern}$" : natex.Pattern;
                var options = natex.CaseInsensitive ? RegexOptions.IgnoreCase : RegexOptions.None;
                var regex = new Regex(pattern, options);
                return new(regex, natex.Mode, natex.CaseInsensitive);
            }
            catch
            {
                return null;
            }
        }

        public override bool ShouldParse(Natex natex, Data? data, bool first)
        {
            return first || data?.Mode != natex.Mode || data?.CaseInsensitive != natex.CaseInsensitive;
        }

        public override bool? Match(Natex natex, Data data, string value)
        {
            return data.Regex.IsMatch(value);
        }

        public record Data(Regex Regex, NatexMode Mode, bool CaseInsensitive);
    }
}
