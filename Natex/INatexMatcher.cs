namespace Asjc.Natex
{
    public interface INatexMatcher
    {
        public object? Parse(Natex natex) => natex;

        public int Match(object? obj, object? data);
    }
}
