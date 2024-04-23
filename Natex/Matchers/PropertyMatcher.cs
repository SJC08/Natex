namespace Asjc.Natex.Matchers
{
    public class PropertyMatcher : NatexMatcher<PropertyMatcher.Data, object>
    {
        public override Data? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(':', 2);
            if (arr.Length == 2)
                return new(arr[0], new(arr[1], natex));
            else
                return null;
        }

        public override NatexMatchResult Match(object? value, Data data, Natex natex)
        {
            var info = value?.GetType().GetProperty(data.Name);
            if (info != null)
            {
                if (data.Natex.Match(info.GetValue(value)))
                    return NatexMatchResult.Success;
            }
            return NatexMatchResult.Default;
        }

        public record Data(string Name, Natex Natex);
    }
}
