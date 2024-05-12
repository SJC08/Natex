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
                _ => null
            };
        }

        public override NatexMatchResult Match(object value, Data data, Natex natex)
        {
            object? current = null;
            if (data.Property == null)
            {
                foreach (var property in DefaultProperties)
                    Handle(property);
            }
            else
            {
                Handle(data.Property);
            }
            if (new Natex(data.Pattern, natex).Match(current))
                return NatexMatchResult.Success;
            return NatexMatchResult.Default;

            void Handle(string[] property)
            {
                current = value; // Reset.
                foreach (var name in property)
                {
                    if (current == null)
                        break;
                    var info = current.GetType().GetProperty(name);
                    current = info?.GetValue(current);
                }
            }
        }

        public record Data(string[]? Property, string Pattern);
    }
}
