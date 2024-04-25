namespace Asjc.Natex.Matchers
{
    public class TemplateMatcher : NatexMatcher<object, string>
    {
        public List<(string, string)> Templates { get; set; } =
        [
            ("Now", DateTime.Now.ToString()),
            ("UtcNow", DateTime.UtcNow.ToString()),
            ("Today", DateTime.Today.ToString())
        ];

        public override string? Parse(Natex natex)
        {
            var str = natex.Pattern;
            foreach (var item in Templates)
                str = str.Replace($"#{item.Item1}", item.Item2);
            return str == natex.Pattern ? null : str;
        }

        public override NatexMatchResult Match(object value, string data, Natex natex)
        {
            return new Natex(data, natex).Match(value) ? NatexMatchResult.Success : NatexMatchResult.Failure;
        }
    }
}
