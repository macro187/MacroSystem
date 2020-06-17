using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MacroSystem
{

    /// <summary>
    /// Additional functionality for <see cref="string"/>
    /// </summary>
    ///
    public static class StringExtensions
    {

        /// <summary>
        /// Convert all line endings in a string to <see cref="LineEnding.Native"/>
        /// </summary>
        ///
        /// <param name="value">
        /// The string to normalize
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
        public static string NormalizeLineEndings(string value)
        {
            return NormalizeLineEndings(value, LineEnding.Native);
        }


        /// <summary>
        /// Convert all line endings in a string to a particular kind of line ending
        /// </summary>
        ///
        /// <param name="value">
        /// The string to normalize
        /// </param>
        ///
        /// <param name="lineEnding">
        /// The kind of line ending to normalize to
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
        public static string NormalizeLineEndings(string value, LineEnding lineEnding)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (lineEnding == null)
            {
                throw new ArgumentNullException(nameof(lineEnding));
            }

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
        public static IEnumerable<string> SplitLines(string value)
        {
            return NormalizeLineEndings(value, LineEnding.LF).Split('\n');
        }


        /// <summary>
        /// Prefix all lines in a string
        /// </summary>
        ///
        /// <param name="value">
        /// The string
        /// </param>
        ///
        /// <param name="prefix">
        /// A string to prepend to all lines in <paramref name="value"/>
        /// </param>
        ///
        /// <returns>
        /// <paramref name="value"/> with <paramref name="prefix"/> prepended to each line
        /// </returns>
        ///
        public static string Prefix(string value, string prefix)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix));
            }

            var lines = SplitLines(value);
            var prefixedLines = lines.Select(s => prefix + s);
            return string.Join(LineEnding.Native, prefixedLines);
        }


        /// <summary>
        /// Indent all lines in a string with two space characters
        /// </summary>
        ///
        /// <param name="value">
        /// The string
        /// </param>
        ///
        /// <returns>
        /// <paramref name="value"/> with two space characters prepended to each line
        /// </returns>
        ///
        public static string Indent(string value)
        {
            return Prefix(value, "  ");
        }


        /// <summary>
        /// Replaces the format items in a specified string with the string representations of corresponding objects in
        /// a specified array formatted according to <see cref="CultureInfo.InvariantCulture"/>
        /// </summary>
        ///
        /// <param name="format">
        /// A composite format string
        /// </param>
        ///
        /// <param name="args">
        /// An object array that contains zero or more objects to format
        /// </param>
        ///
        /// <returns>
        /// A copy of <paramref name="format"/> in which the format items have been replaced by the string
        /// representation of the corresponding objects in <paramref name="args"/>
        /// </returns>
        ///
        public static string FormatInvariant(string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }

    }
}
