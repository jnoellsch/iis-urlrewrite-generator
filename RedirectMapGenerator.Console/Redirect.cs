namespace RedirectMapGenerator.Console
{
    /// <summary>
    /// A model for redirect source and destination.
    /// </summary>
    public class Redirect
    {
        /// <summary>
        /// The original URL.
        /// </summary>
        public string OriginalUrl { get; set; }

        /// <summary>
        /// The destination URL.
        /// </summary>
        public string RedirectUrl { get; set; }
    }
}