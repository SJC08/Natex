namespace Asjc.Natex
{
    public interface INatexMatcher
    {
        object? Parse(Natex natex);

        MatchResult Match(object? obj, object? data);
    }
}
