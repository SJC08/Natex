using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for replacing variables.
    /// </summary>
    public class VariableMatcher : NatexBasicMatcher
    {
        public List<(string, Func<string>)> Variables { get; set; } =
        [
            ("Now", DateTime.Now.ToString),
            ("UtcNow", DateTime.UtcNow.ToString),
            ("Today", DateTime.Today.ToString),
            ("Date", DateTime.Now.ToShortDateString),
            ("Time", DateTime.Now.ToShortTimeString),
            ("Random", new Random().Next().ToString),
            ("MachineName", () => Environment.MachineName),
            ("UserName",() => Environment.UserName)
        ];

        public List<string> Formats { get; set; } =
        [
            "({0})",
            "[{0}]",
            "{{{0}}}",
            "<{0}>"
        ];

        public override bool? Match(Natex natex, object value)
        {
            string str = natex.Pattern;
            foreach (var f in Formats)
            {
                foreach (var v in Variables)
                {
                    string oldValue = string.Format(f, v.Item1);
                    str = str.Replace(oldValue, v.Item2(), natex.CaseInsensitive);
                }
            }
            // Be careful not to make circular calls.
            natex = new(str, natex);
            natex.Matchers.Remove(this);
            return natex.Match(value);
        }
    }
}
