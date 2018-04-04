using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PseudoInternationalization {

    class AndroidProcessor : BaseProcessor {

        private XDocument _doc;

        protected override void Load(Stream input) {
            _doc = XDocument.Load(input);
        }

        protected override void Save(Stream output) {
            foreach(var s in _doc.Descendants("string")) {
                s.Value = Translator.ConvertToFakeInternationalized(s.Value);
            }

            _doc.Save(output);
        }

    }

}
