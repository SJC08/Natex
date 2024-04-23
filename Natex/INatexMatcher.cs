namespace Asjc.Natex
{
    public interface INatexMatcher
    {
        object? Parse(Natex natex);

        NatexMatchResult Match(object? obj, object? data);
    }
}
