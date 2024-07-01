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
        /// <param name="value">The value to match.</param>
        /// <param name="natex">The <see cref="Natex"/> for matching.</param>
        /// <returns>
        /// <see langword="true"/> if the match succeeds;
        /// <see langword="false"/> if the match fails;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        public abstract bool? Match(Natex natex, TValue value);

        bool? INatexMatcher.Match(Natex natex, object? value, object? data)
        {
            if (value is TValue v)
                return Match(natex, v);
            // Matcher may not support TValue.
            return null;
        }
    }

    /// <summary>
    /// Base abstract class for Natex matching with specified value and data types.
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

        /// <inheritdoc cref="INatexMatcher.ShouldParse"/>
        public virtual bool ShouldParse(Natex natex, bool first, TData? data) => first;

        /// <summary>
        /// Matches the provided object of type <typeparamref name="TValue"/> against the given <see cref="Natex"/> and readable data of type <typeparamref name="TData"/>.
        /// </summary>
        /// <param name="value">The value to match.</param>
        /// <param name="data">The readable data for matching.</param>
        /// <param name="natex">The <see cref="Natex"/> for matching.</param>
        /// <returns>
        /// <see langword="true"/> if the match succeeds;
        /// <see langword="false"/> if the match fails;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        public abstract bool? Match(Natex natex, TValue value, TData data);

        object? INatexMatcher.Parse(Natex natex) => Parse(natex);

        bool INatexMatcher.ShouldParse(Natex natex, bool first, object? data)
        {
            return data switch
            {
                TData v => ShouldParse(natex, first, v),
                _ => ShouldParse(natex, first, default) // This behavior may change.
            };
        }

        bool? INatexMatcher.Match(Natex natex, object? value, object? data)
        {
            if (value is TValue v && data is TData d)
                return Match(natex, v, d);
            // Matcher may not support TValue and data may be null.
            return null;
        }
    }
}
