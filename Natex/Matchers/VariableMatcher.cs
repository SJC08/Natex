using Asjc.Utils.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for replacing variables.
    /// </summary>
    public class VariableMatcher : INatexMatcher
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
            "{{{0}}}"
        ];

        /// <inheritdoc/>
        public Func<object?, bool?>? Create(Natex natex)
        {
            return value =>
            {
                string newPattern = natex.Pattern;
                foreach (var f in Formats)
                {
                    foreach (var v in Variables)
                    {
                        string oldValue = string.Format(f, v.Item1);
                        newPattern = newPattern.Replace(oldValue, v.Item2(), natex.CaseInsensitive);
                    }
                }
                // Be careful not to make circular calls.
                Natex subNatex = new(newPattern, natex);
                subNatex.Matchers.Remove(this);
                return subNatex.Match(value);
            };
        }
    }
}
