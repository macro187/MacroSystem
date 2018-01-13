using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace
MacroSystem
{


public static class
StringExtensions
{


/// <summary>
/// Convert all line endings in a string to <see cref="LineEnding.Native"/>
/// </summary>
///
/// <param name="value">
/// The string to normalise
/// </param>
///
/// <returns>
/// <paramref name="value"/> with all line endings converted to <see cref="LineEnding.Native"/>
/// </returns>
///
/// <exception cref="ArgumentNullException">
/// <paramref name="value"/> is <c>null</c>
/// </exception>
///
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "Normalise",
    Justification = "How most of the world spells it")]
public static string
NormaliseLineEndings(string value)
{
    return NormaliseLineEndings(value, LineEnding.Native);
}


/// <summary>
/// Convert all line endings in a string to a particular kind of line ending
/// </summary>
///
/// <param name="value">
/// The string to normalise
/// </param>
///
/// <param name="lineEnding">
/// The kind of line ending to normalise to
/// </param>
///
/// <returns>
/// <paramref name="value"/> with all line endings converted to <paramref name="lineEnding"/>
/// </returns>
///
/// <exception cref="ArgumentNullException">
/// <paramref name="value"/> is <c>null</c>
/// - OR -
/// <paramref name="lineEnding"/> is <c>null</c>
/// </exception>
///
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "Normalise",
    Justification = "How most of the world spells it")]
public static string
NormaliseLineEndings(string value, LineEnding lineEnding)
{
    if (value == null) throw new ArgumentNullException(nameof(value));
    if (lineEnding == null) throw new ArgumentNullException(nameof(lineEnding));
    return value
        .Replace(LineEnding.CRLF, LineEnding.LF)
        .Replace(LineEnding.CR, LineEnding.LF)
        .Replace(LineEnding.LF, lineEnding);
}


/// <summary>
/// Split a string into lines
/// </summary>
///
/// <remarks>
/// Handles any mixture of line endings
/// </remarks>
///
/// <param name="value">
/// The string to split
/// </param>
///
/// <returns>
/// The sequence of one or more lines in <paramref name="value"/>
/// </returns>
///
/// <exception cref="ArgumentNullException">
/// <paramref name="value"/> is <c>null</c>
/// </exception>
///
public static IEnumerable<string>
SplitLines(string value)
{
    return NormaliseLineEndings(value, LineEnding.LF).Split('\n');
}


/// <summary>
/// Prefix all lines in a string
/// </summary>
///
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.Naming",
    "CA1719:ParameterNamesShouldNotMatchMemberNames",
    MessageId = "1#",
    Justification = "The word 'Prefix' is used as a verb in the method name and as a noun in the parameter name")]
public static string
Prefix(string value, string prefix)
{
    if (value == null) throw new ArgumentNullException(nameof(value));
    if (prefix == null) throw new ArgumentNullException(nameof(prefix));
    var lines = SplitLines(value);
    var prefixedLines = lines.Select(s => prefix + s);
    return string.Join(LineEnding.Native, prefixedLines);
}


/// <summary>
/// Prefix all lines in a string with two space characters
/// </summary>
///
public static string
Indent(string value)
{
    return Prefix(value, "  ");
}


/// <summary>
/// A version of String.Format() that always uses the invariant culture
/// </summary>
///
public static string
FormatInvariant(string format, params object[] args)
{
    return string.Format(CultureInfo.InvariantCulture, format, args);
}


}
}
