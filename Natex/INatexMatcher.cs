namespace Asjc.Natex
{
    /// <summary>
    /// Interface for Natex matchers.
    /// </summary>
    public interface INatexMatcher
    {
        /// <summary>
        /// Parses the given <see cref="Natex"/> and returns readable data.
        /// </summary>
        /// <remarks>
        /// This method is typically called before the first <see cref="Match"/>.
        /// </remarks>
        /// <param name="natex">The <see cref="Natex"/> to parse.</param>
        /// <returns>The parsed readable data.</returns>
        object? Parse(Natex natex);

        /// <summary>
        /// Matches the provided object against the given <see cref="Natex"/> and readable data.
        /// </summary>
        /// <param name="value">The value to match.</param>
        /// <param name="data">The readable data for matching.</param>
        /// <param name="natex">The <see cref="Natex"/> for matching.</param>
        /// <returns>A <see cref="NatexMatchResult"/> indicating the match result.</returns>
        NatexMatchResult Match(object? value, ref object? data, Natex natex);
    }
}
