namespace RedirectMapGenerator.Console
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualBasic.FileIO;

    /// <summary>
    /// Parses redirects from a CSV file.
    /// </summary>
    public class CsvRedirectParser : IRedirectParser
    {
        private readonly string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvRedirectParser"/> class.
        /// </summary>
        /// <param name="filePath">The physical path to the redirect.</param>
        public CsvRedirectParser(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Parses the CSV datasource.
        /// </summary>
        /// <returns>A list of <see cref="Redirect"/>.</returns>
        public IEnumerable<Redirect> Parse()
        {
            string[] row;
            var redirects = new List<Redirect>();

            // extract redirects
            using (TextFieldParser tfp = new TextFieldParser(this.filePath))
            {
                // set to CSV delimited
                tfp.TextFieldType = FieldType.Delimited;
                tfp.SetDelimiters(",");

                // skip header. read each line into objects
                tfp.ReadLine();
                while (!tfp.EndOfData)
                {
                    row = tfp.ReadFields();
                    if (row != null)
                    {
                        redirects.Add(new Redirect() { OriginalUrl = row[0], RedirectUrl = row[1] });
                        Console.WriteLine("ORIGINAL: {0}", row[0]);
                        Console.WriteLine("REDIRECT: {0}{1}", row[1], Environment.NewLine);
                    }
                }
            }

            return redirects;
        } 
    }
}
