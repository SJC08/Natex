namespace Asjc.Natex
{
    /// <summary>
    /// Base class for matching values in <see cref="Natex"/>.
    /// </summary>
    public abstract class NatexMatcher : NatexMatcher<object>;

    /// <summary>
    /// Base class for matching values of a specific type in <see cref="Natex"/>.
    /// </summary>
    /// <typeparam name="T">The type of value to be matched.</typeparam>
    public abstract class NatexMatcher<T> : INatexMatcher
    {
        /// <inheritdoc cref="INatexMatcher.Create(Natex)"/>
        public abstract Func<T, bool?>? Create(Natex natex);

        Func<object?, bool?>? INatexMatcher.Create(Natex natex)
        {
            var func = Create(natex);
            if (func == null) return null;
            return value =>
            {
                if (value is T tValue)
                    return func(tValue);
                return null; // Incorrect type.
            };
        }
    }
}
