namespace Asjc.Natex
{
    public abstract class NatexMatcher
    {
        internal Natex? natex;

        public bool Parsed { get; internal set; }

        public virtual void Parse(Natex natex)
        {
            this.natex = natex;
            Parsed = true;
        }

        public virtual int Match(object? obj) => natex != null ? Match(obj, natex) : 0;

        public virtual int Match(object? obj, Natex natex) => 0;
    }
}
