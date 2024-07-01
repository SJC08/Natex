namespace Asjc.Natex
{
    /// <summary>
    /// Base abstract class for Natex matching (no support for saving data).
    /// </summary>
    public abstract class NatexBasicMatcher : NatexBasicMatcher<object> { }

    /// <summary>
    /// Base abstract class for Natex matching with specified value type (no support for saving data).
    /// </summary>
    /// <typeparam name="TValue">The type of the matched value.</typeparam>
    public abstract class NatexBasicMatcher<TValue> : INatexMatcher
    {
        public abstract bool? Match(Natex natex, TValue value);

        bool? INatexMatcher.Match(Natex natex, object? data, object? value)
        {
            if (value is TValue v)
                return Match(natex, v);
            return null;
        }
    }
}
