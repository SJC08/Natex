﻿using Asjc.Utils.Extensions;
using System.Collections;

namespace Asjc.Natex.Matchers
{
    public class NullOrEmptyMatcher : INatexMatcher
    {
        public bool? Match(Natex natex, object? data, object? value)
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
