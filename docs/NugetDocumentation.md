# Pseudo-i18n

*Simple pseudo-internationalization utility library.*

The library allows you to convert any latin alphabet string to a pseudo-language in order to test whether your application is localization-ready. The generated pseudo-string will try to respect links, tags, and other markup in your original strings.

## Usage

Use the `Translator` class to translate strings at runtime:

```cs
PseudoInternationalization.Translator.ConvertToFakeInternationalized("Hello world");
```

This will return the string `[Ħęľľő ŵőřľđ !!! !!!]`.

An extension method can also be used:

```cs
using PseudoInternationalization;

"Hello world".ToPseudo();
```

The following rules will be applied:

* Strings containing URLs will not be translated,
* Strings shorter than 10 characters will grow by 400%, longer strings will grow by 30% (`!` is used as a padding character),
* Translated strings will always start with `[` and end with `]`,
* Tags, braces, and other markup will not be translated.

## Links

A command-line utility that converts resource files is available from the [library’s Github page](https://github.com/LorenzCK/Pseudo-i18n).

Based on [John Robbin’s Pseudoizer](http://msdn.microsoft.com/msdnmag/issues/04/04/Bugslayer/default.aspx) and [Scott Hanselman’s implementation](http://www.hanselman.com/blog/PsuedoInternationalizationAndYourASPNETApplication.aspx).
