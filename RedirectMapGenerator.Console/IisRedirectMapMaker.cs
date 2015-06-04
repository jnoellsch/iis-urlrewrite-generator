namespace RedirectMapGenerator.Console
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// A redirect map maker specifically for the IIS Url Rewrite Module.
    /// </summary>
    public class IisRedirectMapMaker
    {
        private readonly IRedirectParser _parser;

        /// <summary>
        /// Initializes a new instance of the <see cref="IisRedirectMapMaker"/> class.
        /// </summary>
        /// <param name="parser">The parser.</param>
        public IisRedirectMapMaker(IRedirectParser parser)
        {
            if (parser == null)
                throw new ArgumentNullException("parser");
            
            this._parser = parser;
        }

        /// <summary>
        /// Generates the rewrite map element block and saves it to a web.config instance.
        /// </summary>
        /// <param name="mapName">The name of the map group.</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1116:SplitParametersMustStartOnLineAfterDeclaration", Justification = "Reviewed. Suppression is OK here.")]
        public void GenerateMap(string mapName)
        {
            IEnumerable<Redirect> redirects = this._parser.Parse();

            // shape data into key/value elements
            var redirectKeys = redirects
                .OrderBy(r => r.OriginalUrl)
                .Select(r => new XElement("add",
                                    new XAttribute("key", r.OriginalUrl),
                                    new XAttribute("value", r.RedirectUrl)));

            // generate XML doc
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("configuration",
                    new XElement("system.webServer",
                        new XElement("rewrite",
                            new XElement("rewriteMaps",
                                new XElement("rewriteMap",
                                new XAttribute("name", mapName),
                                redirectKeys))))));

            // save
            doc.Save("web.config");
        }
    }
}