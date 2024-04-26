namespace Asjc.Natex
{
    /// <summary>
    /// Base abstract class for Natex matching.
    /// </summary>
    /// </summary>
    public abstract class NatexMatcher : NatexMatcher<object> { }

    /// <summary>
    /// Base abstract class for Natex matching with specified value type.
    /// </summary>
    /// <typeparam name="TValue">The type of value used to match.</typeparam>
    public abstract class NatexMatcher<TValue> : INatexMatcher
    {
        /// <summary>
        /// Matches the provided object against the given <see cref="Natex"/>.
        /// </summary>
        /// <param name="value">The object to match.</param>
        /// <param name="natex">The readable data for matching.</param>
        /// <returns>A <see cref="NatexMatchResult"/> indicating the match result.</returns>
        public abstract NatexMatchResult Match(TValue value, Natex natex);

        object? INatexMatcher.Parse(Natex natex) => null;

        NatexMatchResult INatexMatcher.Match(object? value, object? data, Natex natex)
        {
            if (value is TValue v)
                return Match(v, natex);
            return NatexMatchResult.Default;
        }
    }

    /// <summary>
    ///  Base abstract class for Natex matching with specified value and data types.
    /// </summary>
    /// <typeparam name="TValue">The type of value used to match</typeparam>
    /// <typeparam name="TData">The type of data used to match</typeparam>
    public abstract class NatexMatcher<TValue, TData> : INatexMatcher
    {
        /// <summary>
        /// Parses the given <see cref="Natex"/> and returns readable data of type <typeparamref name="TData"/>.
        /// </summary>
        /// <param name="natex">The <see cref="Natex"/> to parse.</param>
        /// <returns>The parsed readable data.</returns>
        public abstract TData? Parse(Natex natex);

        /// <summary>
        /// Matches the provided object of type <typeparamref name="TValue"/> against the given <see cref="Natex"/> and readable data of type <typeparamref name="TData"/>.
        /// </summary>
        /// <param name="value">The object to match.</param>
        /// <param name="data">The readable data for matching.</param>
        /// <param name="natex"></param>
        /// <returns>A <see cref="NatexMatchResult"/> indicating the match result.</returns>
        public abstract NatexMatchResult Match(TValue value, TData data, Natex natex);

        object? INatexMatcher.Parse(Natex natex) => Parse(natex);

        NatexMatchResult INatexMatcher.Match(object? value, object? data, Natex natex)
        {
            if (value is TValue v && data is TData d)
                return Match(v, d, natex);
            return NatexMatchResult.Default;
        }
    }
}
