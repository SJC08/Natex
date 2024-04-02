namespace Asjc.Natex.Matchers
{
    public class PropertyMatcher : NatexMatcher
    {
        private string? name;
        private Natex? value;

        public override void Parse(Natex natex)
        {
            var s = natex.Pattern.Split(':', 2);
            name = s[0];
            value = new(s[1], natex);
            Parsed = true;
        }

        public override int Match(object? obj)
        {
            if (name != null && value != null)
            {
                var info = obj?.GetType().GetProperty(name);
                if (value.Match(info?.GetValue(obj)))
                    return 1;
            }
            return 0;
        }
    }
}
