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
        /// <param name="natex">The <see cref="Natex"/> to parse.</param>
        /// <returns>The parsed readable data.</returns>
        object? Parse(Natex natex) => default;

        /// <summary>
        /// Determines if the parsing should be performed.
        /// </summary>
        /// <param name="first">Indicates if the parsing hasn't been performed.</param>
        /// <param name="data">The existing readable data (typically from the last parsing), or <see langword="default"/> if unavailable.</param>
        /// <param name="natex">The <see cref="Natex"/> to parse.</param>
        /// <returns><see langword="true"/> if parsing should occur; otherwise, <see langword="false"/>.</returns>
        bool ShouldParse(bool first, object? data, Natex natex) => default;

        /// <summary>
        /// Matches the provided object against the given <see cref="Natex"/> and readable data.
        /// </summary>
        /// <param name="value">The value to match.</param>
        /// <param name="data">The readable data for matching.</param>
        /// <param name="natex">The <see cref="Natex"/> for matching.</param>
        /// <returns>
        /// <see langword="true"/> if the match succeeds;
        /// <see langword="false"/> if the match fails;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        bool? Match(object? value, object? data, Natex natex);
    }
}
