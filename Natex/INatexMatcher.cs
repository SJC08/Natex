namespace Asjc.Natex
{
    public interface INatexMatcher
    {
        /// <summary>
        /// Creates a matching delegate for the specified <see cref="Natex"/>.
        /// </summary>
        Func<object?, bool?>? Create(Natex natex);
    }
}
