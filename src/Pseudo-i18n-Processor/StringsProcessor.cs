using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PseudoInternationalization {

    class StringsProcessor : BaseProcessor {

        // This matches strings in the following format:
        // "key_name" = "Clear upload \"queue\"";
        private static readonly Regex _regexLine = new Regex(
            @"^""(?<key>[\w-]*)""\s*=\s*""(?<value>([^""]|\\"")*)"";",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase
        );

        private Dictionary<string, string> _values;

        protected override void Load(Stream input) {
            _values = new Dictionary<string, string>();

            using (var reader = new StreamReader(input)) {
                while (true) {
                    var line = reader.ReadLine();
                    if (line == null)
                        break;

                    var matches = _regexLine.Match(line);
                    if (matches.Success) {
                        _values[matches.Groups["key"].Value] = matches.Groups["value"].Value;
                    }
                }
            }
        }

        protected override void Save(Stream output) {
            using (var writer = new StreamWriter(output)) {
                foreach(var pair in (from v in _values orderby v.Key select v)) {
                    writer.WriteLine(@"""{0}"" = ""{1}"";",
                        pair.Key,
                        Translator.ConvertToFakeInternationalized(pair.Value)
                    );
                }
            }
        }

    }

}
