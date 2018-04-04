using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoInternationalization {

    public static class Translator {

        /// <summary>
        /// Converts a string to a pseudo-internationalized string.
        /// </summary>
        /// <remarks>
        /// Primarily for latin based languages.
        /// This will need updating to work with Eastern languages.
        /// Taken from: https://github.com/shanselman/Psuedoizer
        /// </remarks>
        /// <param name="inputString">The string to use as a base.</param>
        /// <returns>A longer and twiddled string.</returns>
        public static string ConvertToFakeInternationalized(string inputString) {
            // If the input string contains a http or https link do not localize
            // TODO: skip links only, not entire string
            if (inputString.Contains("http://") || inputString.Contains("https://")) {
                return inputString;
            }
            
            // Calculate the extra space necessary for pseudo
            // internationalization. The rules, according to "Developing
            // International Software" is that < 10 characters you should grow
            // by 400% while >= 10 characters should grow by 30%.
            int origLen = inputString.Length;
            int pseudoLen = 0;
            if (origLen < 10) {
                pseudoLen = (origLen * 4) + origLen;
            }
            else {
                pseudoLen = ((int)(origLen * 0.3)) + origLen;
            }

            var sb = new StringBuilder(pseudoLen);

            // The pseudo string will always start with a "[" and end
            // with a "]" so you can tell if strings are not built
            // correctly in the UI.
            sb.Append("[");

            // TODO: add support for multiple nested braces or other symbols
            bool waitingForEndBrace = false;
            bool waitingForGreaterThan = false;
            foreach (char currChar in inputString) {
                switch (currChar) {
                    case '{':
                        waitingForEndBrace = true;
                        break;
                    case '}':
                        waitingForEndBrace = false;
                        break;
                    case '<':
                        waitingForGreaterThan = true;
                        break;
                    case '>':
                        waitingForGreaterThan = false;
                        break;
                }
                if (waitingForEndBrace || waitingForGreaterThan) {
                    sb.Append(currChar);
                    continue;
                }

                switch (currChar) {
                    case 'A':
                        sb.Append('Å');
                        break;
                    case 'B':
                        sb.Append('ß');
                        break;
                    case 'C':
                        sb.Append('C');
                        break;
                    case 'D':
                        sb.Append('Đ');
                        break;
                    case 'E':
                        sb.Append('Ē');
                        break;
                    case 'F':
                        sb.Append('F');
                        break;
                    case 'G':
                        sb.Append('Ğ');
                        break;
                    case 'H':
                        sb.Append('Ħ');
                        break;
                    case 'I':
                        sb.Append('Ĩ');
                        break;
                    case 'J':
                        sb.Append('Ĵ');
                        break;
                    case 'K':
                        sb.Append('Ķ');
                        break;
                    case 'L':
                        sb.Append('Ŀ');
                        break;
                    case 'M':
                        sb.Append('M');
                        break;
                    case 'N':
                        sb.Append('Ń');
                        break;
                    case 'O':
                        sb.Append('Ø');
                        break;
                    case 'P':
                        sb.Append('P');
                        break;
                    case 'Q':
                        sb.Append('Q');
                        break;
                    case 'R':
                        sb.Append('Ŗ');
                        break;
                    case 'S':
                        sb.Append('Ŝ');
                        break;
                    case 'T':
                        sb.Append('Ŧ');
                        break;
                    case 'U':
                        sb.Append('Ů');
                        break;
                    case 'V':
                        sb.Append('V');
                        break;
                    case 'W':
                        sb.Append('Ŵ');
                        break;
                    case 'X':
                        sb.Append('X');
                        break;
                    case 'Y':
                        sb.Append('Ÿ');
                        break;
                    case 'Z':
                        sb.Append('Ż');
                        break;

                    case 'a':
                        sb.Append('ä');
                        break;
                    case 'b':
                        sb.Append('þ');
                        break;
                    case 'c':
                        sb.Append('č');
                        break;
                    case 'd':
                        sb.Append('đ');
                        break;
                    case 'e':
                        sb.Append('ę');
                        break;
                    case 'f':
                        sb.Append('ƒ');
                        break;
                    case 'g':
                        sb.Append('ģ');
                        break;
                    case 'h':
                        sb.Append('ĥ');
                        break;
                    case 'i':
                        sb.Append('į');
                        break;
                    case 'j':
                        sb.Append('ĵ');
                        break;
                    case 'k':
                        sb.Append('ĸ');
                        break;
                    case 'l':
                        sb.Append('ľ');
                        break;
                    case 'm':
                        sb.Append('m');
                        break;
                    case 'n':
                        sb.Append('ŉ');
                        break;
                    case 'o':
                        sb.Append('ő');
                        break;
                    case 'p':
                        sb.Append('p');
                        break;
                    case 'q':
                        sb.Append('q');
                        break;
                    case 'r':
                        sb.Append('ř');
                        break;
                    case 's':
                        sb.Append('ş');
                        break;
                    case 't':
                        sb.Append('ŧ');
                        break;
                    case 'u':
                        sb.Append('ū');
                        break;
                    case 'v':
                        sb.Append('v');
                        break;
                    case 'w':
                        sb.Append('ŵ');
                        break;
                    case 'x':
                        sb.Append('χ');
                        break;
                    case 'y':
                        sb.Append('y');
                        break;
                    case 'z':
                        sb.Append('ž');
                        break;
                    default:
                        sb.Append(currChar);
                        break;
                }
            }

            // Poke on extra text to fill out the string.
            const string padStr = " !!!";
            int padCount = (pseudoLen - origLen - 2) / padStr.Length;
            if (padCount < 2) {
                padCount = 2;
            }

            for (int x = 0; x < padCount; x++) {
                sb.Append(padStr);
            }

            // Pop on the trailing "]"
            sb.Append("]");

            return sb.ToString();
        }

    }

}
