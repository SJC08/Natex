using System.Reflection;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching property of an object.
    /// </summary>
    public class PropertyMatcher : NatexMatcher
    {
        public List<string[]> DefaultPaths { get; set; } = [];

        public List<char> ImplicitCase { get; set; } = ['<', '>', '≤', '≥'];

        public bool AlwaysMatchDefault { get; set; } = true;

        /// <inheritdoc/>
        public override Func<object?, bool?>? Create(Natex natex)
        {
            var flags = BindingFlags.Instance | BindingFlags.Public;
            if (natex.CaseInsensitive) flags |= BindingFlags.IgnoreCase;
            string[]? path = null;
            string pattern;
            var arr = natex.Pattern.Split(':', 2);
            if (arr.Length == 2)
            {
                path = arr[0].Split('.');
                pattern = arr[1];
            }
            else
            {
                pattern = arr[0];
                foreach (var c in ImplicitCase)
                {
                    int index = natex.Pattern.IndexOf(c);
                    if (index > 0)
                    {
                        path = natex.Pattern[..index].Split('.');
                        pattern = natex.Pattern[index..];
                        break;
                    }
                }
            }
            natex = new(pattern, natex);
            return value =>
            {
                if (path == null)
                    return DefaultPaths.Any(Handle) ? true : null;
                if (Handle(path))
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
                        var info = obj.GetType().GetProperty(name, flags);
                        obj = info?.GetValue(obj);
                    }
                    return natex.Match(obj);
                }
            };
        }
    }
}
