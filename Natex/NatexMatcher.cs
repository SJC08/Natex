namespace Asjc.Natex
{
    /// <summary>
    /// Base abstract class for Natex matching.
    /// </summary>
    public abstract class NatexMatcher : NatexMatcher<object> { }

    /// <summary>
    /// Base abstract class for Natex matching with specified value type.
    /// </summary>
    /// <typeparam name="TData">The type of data used to match.</typeparam>
    public abstract class NatexMatcher<TData> : NatexMatcher<TData, object> { }

    /// <summary>
    /// Base abstract class for Natex matching with specified value and data types.
    /// </summary>
    /// <typeparam name="TData">The type of data used to match.</typeparam>
    /// <typeparam name="TValue">The type of the matched value.</typeparam>
    public abstract class NatexMatcher<TData, TValue> : INatexMatcher
    {
        public abstract TData? Parse(Natex natex);

        public virtual bool ShouldParse(Natex natex, TData? data, bool first) => first;

        public abstract bool? Match(Natex natex, TData data, TValue value);

        object? INatexMatcher.Parse(Natex natex) => Parse(natex);

        bool INatexMatcher.ShouldParse(Natex natex, object? data, bool first)
        {
            return data switch
            {
                TData v => ShouldParse(natex, v, first),
                _ => ShouldParse(natex, default, first)
            };
        }

        bool? INatexMatcher.Match(Natex natex, object? data, object? value)
        {
            if (data is TData d && value is TValue v)
                return Match(natex, d, v);
            return null;
        }
    }
}
