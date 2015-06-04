namespace RedirectMapGenerator.Console
{
    using System;
    using System.IO;

    /// <summary>
    /// A command-line argument parser for validation and assignment to a model.
    /// </summary>
    public class ArgsParser
    {
        /// <summary>
        /// Validates and parses the command line arguments.
        /// </summary>
        public Args Parse(string[] args)
        {
            if (this.ValidateInput(args))
            {
                return new Args() { InputFilePath = args[0], MapName = args[1] };
            }

            Environment.Exit(-1);
            return null;
        }

        /// <summary>
        /// Validates input has proper length, value types, file existance.
        /// </summary>
        /// <param name="args">The raw command line arguements.</param>
        /// <returns>True if the arguements are valid; otherwise, false.</returns>
        private bool ValidateInput(string[] args)
        {
            if (args.Length != 2 || (string.IsNullOrWhiteSpace(args[0]) || 
                                     string.IsNullOrWhiteSpace(args[1])))
            {
                this.DisplayProperUsage();
                return false;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Input file path could not be found.");
                this.DisplayProperUsage();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Renders a message to the console with proper parameter hints.
        /// </summary>
        private void DisplayProperUsage()
        {
            Console.WriteLine("Usage: RedirectMapGenerator <input file path> <map name>");
            Console.WriteLine("Example: RedirectMapGenerator C:\\redirects.csv 'Website Cutover'");
        }
    }
}
