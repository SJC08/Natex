using Asjc.Utils.Extensions;
using System.Collections;

namespace Asjc.Natex.Matchers
{
    public class NullOrEmptyMatcher : INatexMatcher
    {
        /// <inheritdoc/>
        public Func<object?, bool?>? Create(Natex natex)
        {
            if (natex.Pattern.Equals("null", natex.CaseInsensitive))
            {
                return value =>
                {
                    return value == null;
                };
            }
            if (natex.Pattern.Equals("empty", natex.CaseInsensitive))
            {
                return value =>
                {
                    if (value is string s)
                        return s.Length == 0;
                    if (value is ICollection c)
                        return c.Count == 0;
                    return null;
                };
            }
            return null;
        }
    }
}
