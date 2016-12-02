using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoInternationalization {

    class Source {

        private readonly IEnumerable<string> _sources;

        private readonly ProcessorFactory _factory;

        public Source(ProcessorFactory factory, IEnumerable<string> sources) {
            _factory = factory;
            _sources = sources;
        }

        public IEnumerable<string> GetFiles() {
            foreach(var s in _sources) {
                if(Directory.Exists(s)) {
                    foreach(var f in Directory.EnumerateFiles(s)) {
                        if(_factory.IsSupported(f)) {
                            yield return f;
                        }
                    }
                }
                else if(File.Exists(s)) {
                    yield return s;
                }
                else {
                    Console.Error.WriteLine("Warning: source {0} does not exist.", s);
                }
            }

            yield break;
        }

    }

}
