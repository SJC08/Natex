namespace Asjc.Natex.Matchers
{
    public class PropertyMatcher : INatexMatcher
    {
        public object? Parse(Natex natex)
        {
            var arr = natex.Pattern.Split(':', 2);
            if (arr.Length == 2)
                return new Data(arr[0], new(arr[1], natex));
            else
                return null;
        }

        public int Match(object? obj, object? exp)
        {
            if (exp is Data data)
            {
                var info = obj?.GetType().GetProperty(data.Name);
                if (info != null)
                {
                    var value = info.GetValue(obj);
                    if (data.Natex.Match(value))
                        return 1;
                }
            }
            return 0;
        }

        private record Data(string Name, Natex Natex);
    }
}
