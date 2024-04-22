namespace Asjc.Natex
{
    public interface INatexMatcher
    {
        object? Parse(Natex natex);

        MatchResult Match(object? obj, object? data);
    }

    public interface INatexMatcher<T> : INatexMatcher
    {
        new T? Parse(Natex natex);

        MatchResult Match(object? obj, T data);
    }
}
