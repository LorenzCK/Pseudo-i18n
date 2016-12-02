using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fclp;
using Fclp.Internals;

namespace PseudoInternationalization {

    class CustomHelpFormatter : ICommandLineOptionFormatter {

        public string Format(IEnumerable<ICommandLineOption> options) {
            if (options == null)
                throw new ArgumentNullException();

            var sb = new StringBuilder();

            sb.Append(Path.GetFileName(Assembly.GetExecutingAssembly().Location));
            sb.AppendLine(": takes any number of resource files (.resx, .xml, or.strings) and creates an artificial, but still readable, copy to exercise your i18n code.");
            sb.AppendLine();

            foreach(var o in options) {
                sb.Append(" --");
                if (o.HasShortName) {
                    sb.Append(o.ShortName);
                    if (o.HasLongName)
                        sb.Append("|");
                }
                if (o.HasLongName)
                    sb.Append(o.LongName);

                sb.Append("\t");
                sb.Append(o.Description);

                if(o.IsRequired) {
                    sb.Append(" (required)");
                }

                sb.AppendLine();
            }

            sb.AppendLine(" --help\t\tShows this help screen");

            return sb.ToString();
        }

    }

}
