using System.Reflection;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching property of an object.
    /// </summary>
    public class PropertyMatcher : NatexMatcher<PropertyMatcher.Data>
    {
        public List<string[]> DefaultPaths { get; set; } = [];

        public bool AlwaysMatchDefault { get; set; } = true;

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

        public override bool? Match(Natex natex, Data data, object value)
        {
            natex = new Natex(data.Pattern, natex);
            if (data.Path is null)
                return DefaultPaths.Any(Handle) ? true : null;
            if (Handle(data.Path))
                return true;
            if (AlwaysMatchDefault)
                return DefaultPaths.Any(Handle);
            return false;


            bool Handle(string[] path)
            {
                object? obj = value;
                foreach (var name in path)
                {
                    if (obj == null) return false;
                    var info = obj.GetType().GetProperty(name, data.Flags);
                    obj = info?.GetValue(obj);
                }
                return natex.Match(obj);
            }
        }

        public record Data(string[]? Path, string Pattern, BindingFlags Flags);
    }
}
