﻿namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching property of an object.
    /// </summary>
    public class PropertyMatcher : NatexMatcher<object, PropertyMatcher.Data>
    {
        public override Data? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(':', 2);
            if (arr.Length == 2)
                return new(arr[0].Split('.'), arr[1]);
            return null;
        }

        public override NatexMatchResult Match(object? value, Data data, Natex natex)
        {
            foreach (var name in data.Names)
            {
                var property = value?.GetType().GetProperty(name);
                value = property?.GetValue(value);
            }
            if (new Natex(data.Pattern, natex).Match(value))
                return NatexMatchResult.Success;
            return NatexMatchResult.Default;
        }

        public record Data(string[] Names, string Pattern);
    }
}
