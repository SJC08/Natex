using System.Collections;

namespace Asjc.Natex.Matchers
{
    public class ListMatcher : NatexMatcher<IList>
    {
        /// <inheritdoc/>
        public override Func<IList, bool?>? Create(Natex natex)
        {
            var natexes = natex.Pattern.Split(',').Select(s => new Natex(s, natex)).ToList();
            if (natexes.Count == 0) return null;
            return value =>
            {
                if (natex.Mode == NatexMode.Exact)
                {
                    // Sensitive to sequence.
                    if (value.Count != natexes.Count)
                        return null;
                    for (int i = 0; i < value.Count; i++)
                    {
                        if (!natexes[i].Match(value[i]))
                            return null;
                    }
                    return true;
                }
                else
                {
                    // Inclusion is enough.
                    if (natexes.All(d => value.Cast<object>().Any(d.Match)))
                        return true;
                    return null;
                }
            };
        }
    }
}
