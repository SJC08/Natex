using Asjc.Extensions;
using System.Collections;

namespace Asjc.Natex.Matchers
{
    // A question about generics confused me, so I'm using the interface here instead.
    public class NullOrEmptyMatcher : INatexMatcher
    {
        public object? Parse(Natex natex) => null;

        public bool ShouldParse(bool first, object? data, Natex natex) => false;

        public bool? Match(object? value, object? data, Natex natex)
        {
            if (natex.Pattern.Equals("null", natex.CaseInsensitive))
            {
                return value is null;
            }
            else if (natex.Pattern.Equals("empty", natex.CaseInsensitive))
            {
                if (value is string s)
                    return s.Length == 0;
                if (value is ICollection c)
                    return c.Count == 0;
            }
            return null;
        }
    }
}
