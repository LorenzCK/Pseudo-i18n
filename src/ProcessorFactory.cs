using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoInternationalization {

    class ProcessorFactory {

        private static readonly Dictionary<string, Type> _extensionMap = new Dictionary<string, Type> {
            { ".resx", typeof(ResxProcessor) },
            { ".xml", typeof(AndroidProcessor) },
            { ".strings", typeof(StringSplitOptions) }
        };

        public bool IsSupported(string path) => _extensionMap.ContainsKey(Path.GetExtension(path));

        public IProcessor GetProcessor(string path) {
            var extension = Path.GetExtension(path);
            if (_extensionMap.ContainsKey(extension)) {
                return (IProcessor)Activator.CreateInstance(_extensionMap[extension]);
            }
            else {
                throw new ArgumentException("File type not supported");
            }
        }

    }

}
