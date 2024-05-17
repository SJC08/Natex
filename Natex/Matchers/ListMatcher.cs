using System.Collections;

namespace Asjc.Natex.Matchers
{
    public class ListMatcher : NatexMatcher<IList, List<Natex>>
    {
        public override List<Natex>? Parse(Natex natex)
        {
            var natexes = natex.Pattern.Split(',').Select(s => new Natex(s, natex)).ToList();
            return natexes.Count > 0 ? natexes : null;
        }

        public override bool? Match(IList value, List<Natex> data, Natex natex)
        {
            if (natex.Mode == NatexMode.Exact)
            {
                // Sensitive to sequence.
                if (value.Count != data.Count)
                    return null;
                for (int i = 0; i < value.Count; i++)
                {
                    if (!data[i].Match(value[i]))
                        return null;
                }
            }
            else
            {
                // Inclusion is enough.
                foreach (var d in data)
                {
                    bool found = false;
                    foreach (var v in value)
                    {
                        if (d.Match(v))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        return null;
                }
            }
            return true;
        }
    }
}
