using System.Reflection;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching property of an object.
    /// </summary>
    public class PropertyMatcher : NatexMatcher<object, PropertyMatcher.Data>
    {
        public List<string[]> DefaultPaths = [];

        public override Data? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(':', 2);
            var flags = BindingFlags.Instance | BindingFlags.Public;
            if (natex.CaseInsensitive)
                flags |= BindingFlags.IgnoreCase;
            return arr.Length switch
            {
                1 => new(null, arr[0], flags),
                2 => new(arr[0].Split('.'), arr[1], flags),
                _ => null // When?
            };
        }

        public override bool? Match(object value, Data data, Natex natex)
        {
            natex = new Natex(data.Pattern, natex);
            if (data.Path == null)
                return DefaultPaths.Any(Handle) ? true : null;
            else
                return Handle(data.Path);

            bool Handle(string[] path)
            {
                if (GetValue(value, path, out var v))
                    return natex.Match(v);
                return false;
            }
        }

        protected virtual bool GetValue(object? obj, string[] path, out object? value)
        {
            value = obj;
            foreach (var name in path)
            {
                if (value == null)
                    return false;
                var info = value.GetType().GetProperty(name);
                value = info?.GetValue(value);
            }
            return true;
        }

        public record Data(string[]? Path, string Pattern, BindingFlags Flags);
    }
}
