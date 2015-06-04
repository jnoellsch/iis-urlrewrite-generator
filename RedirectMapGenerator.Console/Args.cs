namespace RedirectMapGenerator.Console
{
    /// <summary>
    /// A model for command-line arguments.
    /// </summary>
    public class Args
    {
        /// <summary>
        /// The physical path to the redirect mapping file.
        /// </summary>
        public string InputFilePath { get; set; }

        /// <summary>
        /// The name of the redirect map.
        /// </summary>
        public string MapName { get; set; }
    }
}
