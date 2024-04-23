namespace Asjc.Natex
{
    public abstract class NatexMatcher : NatexMatcher<object> { }

    public abstract class NatexMatcher<TValue> : INatexMatcher
    {
        public abstract NatexMatchResult Match(TValue value, Natex natex);

        object? INatexMatcher.Parse(Natex natex) => null;

        NatexMatchResult INatexMatcher.Match(object? value, object? data, Natex natex)
        {
            if (value is TValue v)
                return Match(v, natex);
            return NatexMatchResult.Default;
        }
    }

    public abstract class NatexMatcher<TData, TValue> : INatexMatcher
    {
        public abstract TData? Parse(Natex natex);

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
