namespace RedirectMapGenerator.Console
{
    using System.Collections.Generic;

    /// <summary>
    /// Parses redirects.
    /// </summary>
    public interface IRedirectParser
    {
        /// <summary>
        /// Parses the datasource.
        /// </summary>
        /// <returns>A list of <see cref="Redirect"/>.</returns>
        IEnumerable<Redirect> Parse();
    }
}