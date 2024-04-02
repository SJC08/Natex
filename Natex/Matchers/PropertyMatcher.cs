namespace Asjc.Natex.Matchers
{
    public class PropertyMatcher : NatexMatcher
    {
        private string[] pattern;

        public override void Parse(Natex natex)
        {
            base.Parse(natex);
            pattern = natex.Pattern.Split(':', 2);
        }

        public override int Match(object? obj)
        {
            var info = obj?.GetType().GetProperty(pattern[0]);
            if (info != null)
            {
                var value = info.GetValue(obj);
                if (new Natex(pattern[1], natex).Match(value)) return 1;
            }
            return 0;
        }
    }
}
