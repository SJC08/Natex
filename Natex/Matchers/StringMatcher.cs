namespace Asjc.Natex.Matchers
{
    public class StringMatcher : INatexMatcher
    {
        public int Match(object? obj, object? exp)
        {
            if (exp is Natex natex)
            {
                if (natex.Pattern == obj?.ToString())
                    return 1;
            }
            return 0;
        }
    }
}
