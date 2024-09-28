using System.Text.RegularExpressions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching via Regex.
    /// </summary>
    public class RegexMatcher : NatexMatcher<string>
    {
        /// <inheritdoc/>
        public override Func<string, bool?>? Create(Natex natex)
        {
            try
            {
                var pattern = natex.Mode == NatexMode.Exact ? $"^{natex.Pattern}$" : natex.Pattern;
                var options = natex.CaseInsensitive ? RegexOptions.IgnoreCase : RegexOptions.None;
                Regex regex = new(pattern, options);
                return value => regex.IsMatch(value);
            }
            catch
            {
                return null;
            }
        }

        public record Data(Regex Regex, NatexMode Mode, bool CaseInsensitive);
    }
}
