namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for matching property of an object.
    /// </summary>
    public class PropertyMatcher : NatexMatcher<object, PropertyMatcher.Data>
    {
        public List<string[]> DefaultProperties = [];

        public override Data? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(':', 2);
            return arr.Length switch
            {
                1 => new(null, arr[0]),
                2 => new(arr[0].Split('.'), arr[1]),
                _ => null // When?
            };
        }

        public override bool? Match(object value, Data data, Natex natex)
        {
            natex = new Natex(data.Pattern, natex);
            if (data.Property == null)
                return DefaultProperties.Any(Handle) ? true : null;
            else
                return Handle(data.Property);

            bool Handle(string[] property)
            {
                object? current = value;
                foreach (var name in property)
                {
                    if (current == null)
                        return false;
                    var info = current.GetType().GetProperty(name);
                    current = info?.GetValue(current);
                }
                return natex.Match(current);
            }
        }

        public record Data(string[]? Property, string Pattern);
    }
}
