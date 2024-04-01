namespace Asjc.Natex.Matchers
{
    public class PropertyMatcher : INatexMatcher
    {
        public int Match(object? obj, Natex natex)
        {
            var pattern = natex.Pattern.Split(':', 2);
            var info = obj?.GetType().GetProperty(pattern[0]);
            if (info != null)
            {
                var value = info.GetValue(obj);
                if (new Natex(pattern[1],natex).Match(value)) return 1;
            }
            return 0;
        }
    }
}
