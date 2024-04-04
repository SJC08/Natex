namespace Asjc.Natex
{
    public interface INatexMatcher
    {
        /// <summary>
        /// Parses the provided Natex into an internal representation.
        /// </summary>
        /// <param name="natex">The Natex to parse.</param>
        /// <returns>The parsed representation of the Natex.</returns>
        public object? Parse(Natex natex) => natex;

        /// <summary>
        /// Matches the given object against the expected expression.
        /// </summary>
        /// <param name="obj">The object to match.</param>
        /// <param name="exp">The expected expression to match.</param>
        /// <returns>
        /// An integer indicating the match result:
        /// <list type="table">
        /// <item><term>1</term><description>The object matches the expression.</description></item>
        /// <item><term>2</term><description>The object doesn't match the expression.</description></item>
        /// <item><term>0</term><description>The match result is indeterminate or not applicable.</description></item>
        /// </list>
        /// </returns>
        public int Match(object? obj, object? exp);
    }
}
