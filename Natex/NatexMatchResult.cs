namespace Asjc.Natex
{
    /// <summary>
    /// Specifies the result of <see cref="INatexMatcher.Match"/>
    /// </summary>
    public enum NatexMatchResult
    {
        Default,

        /// <summary>
        /// The match succeeded.
        /// </summary>
        Success,

        /// <summary>
        /// The match failed.
        /// </summary>
        Failure
    }
}
