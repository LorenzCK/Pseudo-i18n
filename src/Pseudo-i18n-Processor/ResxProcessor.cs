using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PseudoInternationalization {

    class ResxProcessor : BaseProcessor {

        List<DictionaryEntry> _resources;

        protected override void Load(Stream input) {
            _resources = new List<DictionaryEntry>();

            using (var r = new ResXResourceReader(input)) {
                foreach(DictionaryEntry entry in r) {
                    if (entry.Value == null)
                        continue;

                    if (!(entry.Value is string))
                        continue;

                    var key = entry.Key.ToString();
                    if(
                        key.StartsWith(">>") ||
                        (key.StartsWith("$") && !key.Equals("$this.Text", StringComparison.InvariantCultureIgnoreCase))
                    ) {
                        // Make sure the key does not start with meta-characters, excluding
                        // "$this.Text" for Form titles.
                        continue;
                    }

                    _resources.Add(entry);
                }
            }
        }

        protected override void Save(Stream output) {
            using(var w = new ResXResourceWriter(output)) {
                foreach(var entry in _resources) {
                    w.AddResource(
                        entry.Key.ToString(),
                        Translator.ConvertToFakeInternationalized((string)entry.Value)
                    );
                }
            }
        }

    }

}
