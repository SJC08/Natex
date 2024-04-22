namespace Asjc.Natex
{
    public interface INatexMatcher
    {
        object? Parse(Natex natex);

        NatexMatchResult Match(object? obj, object? data);
    }

    public interface INatexMatcher<TData, TValue> : INatexMatcher
    {
        new TData? Parse(Natex natex);

        NatexMatchResult Match(TValue value, TData data);
    }
}
