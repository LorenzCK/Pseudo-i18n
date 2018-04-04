using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoInternationalization {

    abstract class BaseProcessor : IProcessor {

        public void Process(string path) {
            using(var fs = new FileStream(path, FileMode.Open)) {
                Load(fs);
            }
            
            var outputPath = GenerateOutputPath(path);
            using (var fs = new FileStream(outputPath, FileMode.Create)) {
                Save(fs);
            }
        }

        private string GenerateOutputPath(string path) {
            if (Program.Overwrite)
                return path;
            else
                return Path.Combine(Program.Output, Path.GetFileName(path));
        }

        protected abstract void Load(Stream input);

        protected abstract void Save(Stream output);

    }

}
