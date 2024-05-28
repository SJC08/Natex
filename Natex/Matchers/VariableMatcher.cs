using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for replacing variables.
    /// </summary>
    public class VariableMatcher : NatexMatcher
    {
        public List<(string, Func<string>)> Variables { get; set; } =
        [
            ("Now", DateTime.Now.ToString),
            ("UtcNow", DateTime.UtcNow.ToString),
            ("Today", DateTime.Today.ToString),
            ("Random", new Random().Next().ToString),
            ("MachineName", ()=> Environment.MachineName),
            ("UserName",()=> Environment.UserName)
        ];

        public override bool? Match(object value, Natex natex)
        {
            string str = natex.Pattern;
            foreach (var item in Variables)
                str = str.Replace($"<{item.Item1}>", item.Item2(), natex.CaseInsensitive);
            // Be careful not to make circular calls.
            natex = new(str, natex);
            natex.Matchers.Remove(this);
            return natex.Match(value);
        }
    }
}
