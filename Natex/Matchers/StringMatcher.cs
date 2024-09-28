using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching the string representation of an object.
    /// </summary>
    public class StringMatcher : NatexMatcher
    {
        /// <inheritdoc/>
        public override Func<object?, bool?>? Create(Natex natex)
        {
            return value =>
            {
                string? str = value?.ToString();
                if (str == null) return null;
                if (natex.Mode == NatexMode.Exact)
                    return str.Equals(natex.Pattern, natex.CaseInsensitive) ? true : null;
                else
                    return str.Contains(natex.Pattern, natex.CaseInsensitive) ? true : null;
            };
        }
    }
}
