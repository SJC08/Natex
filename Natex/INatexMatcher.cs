namespace Asjc.Natex
{
    /// <summary>
    /// Interface for matching values in <see cref="Natex"/>.
    /// </summary>
    public interface INatexMatcher
    {
        /// <summary>
        /// Creates a matching delegate for the specified <see cref="Natex"/>.
        /// </summary>
        Func<object?, bool?>? Create(Natex natex);
    }
}
