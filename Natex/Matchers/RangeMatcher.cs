namespace Asjc.Natex.Matchers
{
    public class RangeMatcher : NatexMatcher<double[], string>
    {
        public override double[]? Parse(Natex natex)
        {
            double[] result = new double[2];
            var arr = natex.Pattern.Split(['-', '~']);
            if (arr.Length == 2)
            {
                try
                {
                    result[0] = double.Parse(arr[0]);
                    result[1] = double.Parse(arr[1]);
                }
                catch { }
            }
            return null;
        }

        public override NatexMatchResult Match(string value, double[] data, Natex natex)
        {
            if (double.TryParse(value, out var d))
            {
                if (d >= data[0] && d <= data[1])
                    return NatexMatchResult.Success;
                else
                    return NatexMatchResult.Failure;
            }
            return NatexMatchResult.Default;
        }
    }
}
