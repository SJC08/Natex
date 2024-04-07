namespace Asjc.Natex.Matchers
{
    public class PropertyMatcher : NatexMatcher<PropertyMatcher.Data>
    {
        public override Data? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(':', 2);
            if (arr.Length == 2)
                return new(arr[0], new(arr[1], natex));
            else
                return null;
        }

        public override MatchResult Match(object? obj, Data data)
        {
            var info = obj?.GetType().GetProperty(data.Name);
            if (info != null)
            {
                var value = info.GetValue(obj);
                if (data.Natex.Match(value))
                    return MatchResult.Match;
            }
            return MatchResult.Default;
        }

        public record Data(string Name, Natex Natex);
    }
}
