namespace Asjc.Natex
{
    public abstract class NatexMatcher
    {
        internal Natex? natex;

        public bool Valid { get; set; } = true;
        public bool Parsed { get; set; }

        public virtual void Parse(Natex natex)
        {
            this.natex = natex;
        }

        public virtual int Match(object? obj)
        {
            return Match(obj, natex!);
        }

        public virtual int Match(object? obj, Natex natex) => 0;
    }
}
