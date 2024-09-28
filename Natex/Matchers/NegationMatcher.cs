
namespace Asjc.Natex.Matchers
{
    public class NegationMatcher : INatexMatcher
    {
        public Func<object?, bool?>? Create(Natex natex)
        {
            if (!string.IsNullOrEmpty(natex.Pattern) && natex.Pattern[0] == '!')
            {
                Natex n = new(natex.Pattern[1..], natex);
                return value => !n.Match(value);
            }
            return null;
        }
    }
}
