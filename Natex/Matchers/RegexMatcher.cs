using System.Text.RegularExpressions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching via Regex.
    /// </summary>
    public class RegexMatcher : NatexMatcher<string, RegexMatcher.Data>
    {
        public override Data? Parse(Natex natex)
        {
            try
            {
                return natex.Mode == NatexMode.Exact
                    ? new(new($"^{natex.Pattern}$"), natex.Mode)
                    : new(new(natex.Pattern), natex.Mode);
            }
            catch
            {
                return null;
            }
        }

        public override bool ShouldParse(bool first, Data? data, Natex natex)
        {
            return first || data?.Mode != natex.Mode;
        }

        public override bool? Match(string value, Data data, Natex natex)
        {
            return data.Regex.IsMatch(value);
        }

        public record Data(Regex Regex, NatexMode Mode);
    }
}
