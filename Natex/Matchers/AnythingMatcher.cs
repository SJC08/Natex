using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    public class AnythingMatcher : NatexMatcher
    {
        /// <inheritdoc/>
        public override Func<object, bool?>? Create(Natex natex)
        {
            if (natex.Pattern.Equals("*", natex.CaseInsensitive) ||
                natex.Pattern.Equals("any", natex.CaseInsensitive))
                return _ => true;
            return null;
        }
    }
}
