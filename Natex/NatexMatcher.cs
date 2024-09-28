namespace Asjc.Natex
{
    /// <summary>
    /// Base abstract class for Natex matching.
    /// </summary>
    public abstract class NatexMatcher : NatexMatcher<object>;

    /// <summary>
    /// Base abstract class for Natex matching with specified value type.
    /// </summary>
    /// <typeparam name="T">The type of value to be matched</typeparam>
    public abstract class NatexMatcher<T> : INatexMatcher
    {
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
