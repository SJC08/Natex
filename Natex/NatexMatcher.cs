namespace Asjc.Natex
{
    public abstract class NatexMatcher : NatexMatcher<Natex>
    {
        public override Natex? Parse(Natex natex) => natex;
    }

    public abstract class NatexMatcher<T> : INatexMatcher
    {
        public abstract T? Parse(Natex natex);

        public abstract MatchResult Match(object? obj, T data);

        object? INatexMatcher.Parse(Natex natex) => Parse(natex);

        MatchResult INatexMatcher.Match(object? obj, object? data) => data is T t ? Match(obj, t) : MatchResult.Default;
    }
}
