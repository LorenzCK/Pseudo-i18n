using System;

namespace PseudoInternationalization {

    public static class TranslatorExtensions {

        /// <summary>
        /// Converts a string to a pseudo-internationalized string.
        /// </summary>
        /// <remarks>
        /// Primarily for latin based languages.
        /// This will need updating to work with Eastern languages.
        /// Taken from: https://github.com/shanselman/Psuedoizer
        /// </remarks>
        /// <param name="s">The string to use as a base.</param>
        /// <returns>A longer and twiddled string.</returns>
        public static string ToPseudo(this string s) {
            return Translator.ConvertToFakeInternationalized(s);
        }

    }

}
