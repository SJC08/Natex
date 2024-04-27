using Asjc.Extensions;

namespace Asjc.Natex.Matchers
{
    /// <summary>
    /// A NatexMatcher for replacing variables.
    /// </summary>
    public class VariableMatcher : NatexMatcher<object, string>
    {
        public List<(string, string)> Variables { get; set; } =
        [
            ("Now", DateTime.Now.ToString()),
            ("UtcNow", DateTime.UtcNow.ToString()),
            ("Today", DateTime.Today.ToString()),
            ("Random", new Random().Next().ToString()),
            ("MachineName", Environment.MachineName),
            ("UserName", Environment.UserName)
        ];

        public override string? Parse(Natex natex)
        {
            var str = natex.Pattern;
            foreach (var item in Variables)
                str = str.Replace($"[{item.Item1}]", item.Item2, true);
            return str == natex.Pattern ? null : str;
        }

        public override NatexMatchResult Match(object value, string data, Natex natex)
        {
            return new Natex(data, natex).Match(value) ? NatexMatchResult.Success : NatexMatchResult.Failure;
        }
    }
}
