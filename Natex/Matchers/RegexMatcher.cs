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
                if (natex.Pattern.StartsWith('/') && natex.Pattern.EndsWith('/'))
                {
                    var pattern = natex.Pattern[1..^1];
                    var options = natex.CaseInsensitive ? RegexOptions.IgnoreCase : RegexOptions.None;
                    Regex regex = new(pattern, options);
                    return value => regex.IsMatch(value);
                }
                else
                {
                    var pattern = natex.Mode == NatexMode.Exact ? $"^{natex.Pattern}$" : natex.Pattern;
                    var options = natex.CaseInsensitive ? RegexOptions.IgnoreCase : RegexOptions.None;
                    Regex regex = new(pattern, options);
                    return value => regex.IsMatch(value) ? true : null;
                }
            }
            catch
            {
                // Failed to create a Regex.
                return null;
            }
        }
    }
}
