namespace Asjc.Natex
{
    public abstract class NatexMatcher : NatexMatcher<Natex, object>
    {
        public override Natex? Parse(Natex natex) => natex;
    }

    public abstract class NatexMatcher<TData, TValue> : INatexMatcher<TData, TValue>
    {
        public abstract TData? Parse(Natex natex);

        public abstract NatexMatchResult Match(TValue obj, TData data);

        object? INatexMatcher.Parse(Natex natex) => Parse(natex);

        NatexMatchResult INatexMatcher.Match(object? obj, object? data)
        {
            if (obj is TValue v && data is TData d)
                return Match(v, d);
            return NatexMatchResult.Default;
        }
    }
}
