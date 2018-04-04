using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fclp;

namespace PseudoInternationalization {

    public class Program {

        public static IList<string> Input { get; private set; } = new string[0];

        public static bool Overwrite { get; private set; } = false;

        public static string Output { get; private set; } = null;

        public static int Main(string[] args) {
            var p = new FluentCommandLineParser();

            p.Setup<List<string>>('i', "input")
                .Callback(files => Input = files)
                .WithDescription("Paths to input directories or files");

            p.Setup<bool>("overwrite")
                .Callback(v => Overwrite = v)
                .WithDescription("Overwrites input files");

            p.Setup<string>('o', "output")
                .Callback(o => Output = o)
                .WithDescription("Output directory for all input files")
                .SetDefault(Environment.CurrentDirectory);

            p.SetupHelp("h", "help", "?")
                .Callback(PrintHelp)
                .WithCustomFormatter(new CustomHelpFormatter());

            try {
                // Parsing and error checking
                var result = p.Parse(args);
                if (result.HelpCalled) {
                    return 1;
                }
                if (result.HasErrors) {
                    Console.Error.WriteLine(result.ErrorText);
                    return 1;
                }
                
                if(Input.Any()) {
                    return ProcessInput();
                }
                else {
                    return ProcessStandardInput();
                }
            }
            catch(Exception ex) {
                Console.Error.WriteLine("Error: {0}.", ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
                return 1;
            }

            Console.WriteLine("Done.");

            return 0;
        }

        private static int ProcessInput() {
            if (!Directory.CreateDirectory(Output).Exists) {
                Console.Error.WriteLine("Error: output directory does not exist.");
                return 1;
            }

            var factory = new ProcessorFactory();
            var source = new Source(factory, Input);
            foreach (var file in source.GetFiles()) {
                Console.WriteLine("Processing {0}... ", Path.GetFileName(file));

                var proc = factory.GetProcessor(file);
                proc.Process(file);
            }

            return 0;
        }

        private static int ProcessStandardInput() {
            Console.OutputEncoding = Encoding.UTF8;

            while (true) {
                var line = Console.ReadLine();
                if (line == null)
                    return 0;

                Console.WriteLine(Translator.ConvertToFakeInternationalized(line));
            }
        }

        private static void PrintHelp(string text) {
            Console.Error.WriteLine(text);
        }

    }

}
