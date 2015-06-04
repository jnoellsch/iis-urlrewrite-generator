namespace RedirectMapGenerator.Console
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            // generate
            Args input = new ArgsParser().Parse(args);
            IRedirectParser parser = new CsvRedirectParser(input.InputFilePath);
            var maker = new IisRedirectMapMaker(parser);
            maker.GenerateMap(input.MapName);

            // pause for user checking
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
