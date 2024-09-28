namespace Asjc.Natex
{
    public interface INatexMatcher
    {
        Func<object?, bool?>? Create(Natex natex);
    }
}
