namespace Asjc.Natex.Matchers
{
    public class NegationMatcher : NatexBasicMatcher
    {
        public override bool? Match(Natex natex, object value)
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
