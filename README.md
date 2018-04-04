# Pseudo-i18n

Pseudo-internationalization utility for multiplatform resource files.

Get the [latest compiled version](https://github.com/LorenzCK/Pseudo-i18n/releases/latest) of the command-line resource translation utility.

Also available as a stand-alone .NET&nbsp;Standard [NuGet package](https://www.nuget.org/packages/Pseudo-i18n/) for runtime string pseudo-translation.

[![NuGet](https://img.shields.io/nuget/v/Pseudo-i18n.svg)](https://www.nuget.org/packages/Pseudo-i18n/)

Based on John Robbin's **Pseudoizer** and [Scott Hanselman's implementation](http://www.hanselman.com/blog/PsuedoInternationalizationAndYourASPNETApplication.aspx).

## Usage

```bash
Pseudo-i18n.exe [-i <file>...] [{-o <output-dir>|--overwrite}]
```

The program takes a list of files and directories as input (```-i```). All compatible resource files are processed:

* .NET ResX files (.resx),
* iOS strings (.strings),
* Android resources (.xml).

Processed files are output in the current working directory or a target directory if specified (```-o```).
If ```--overwrite``` is set, the original input files are overwritten instead.

If no list of files is provided, the program takes any text on its standard input and prints out the converted version to standard output.

## Internationalization

String translation rules are defined on the basis of [Scott Hanselman's Pseudoizer](https://github.com/shanselman/Psuedoizer):

* Strings shorter than 10 characters grow by 400% in length,
* Longer strings grow by 30%.
* Strings start with ```[``` and end with ```]```, to clearly mark their limits and show if they are clipped in UI.
* Characters between braces and brackets (```<>``` and ```{}```) are skipped.

All other (latin-only, for now) characters are converted to *funky* characters that look like them. For instance, ```Test string``` becomes ```[Ŧęşŧ şŧřįŉģ  !!! !!!]```.
