namespace Asjc.Natex
{
    public interface INatexMatcher
    {
        object? Parse(Natex natex);

        int Match(object? obj, object? data);
    }
}
