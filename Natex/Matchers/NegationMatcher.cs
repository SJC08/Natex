namespace Asjc.Natex.Matchers
{
    public class NegationMatcher : NatexMatcher
    {
        public override bool? Match(object value, Natex natex)
        {
            if (!string.IsNullOrEmpty(natex.Pattern))
            {
                if (natex.Pattern[0] == '!')
                {
                    Natex n = new(natex.Pattern[1..], natex);
                    return !n.Match(value);
                }
            }
            return null;
        }
    }
}
