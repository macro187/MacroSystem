using System;

namespace MacroSystem
{

    /// <summary>
    /// Text file line endings
    /// </summary>
    ///
    /// <remarks>
    /// https://en.wikipedia.org/wiki/Newline
    /// </remarks>
    ///
    public class LineEnding
    {

        /// <summary>
        /// Unix-style line ending consisting of a single line-feed character
        /// </summary>
        ///
        public static readonly LineEnding LF = new LineEnding("\n");


        /// <summary>
        /// Windows-style line ending consisting of a carriage-return character followed by a line-feed character
        /// </summary>
        ///
        public static readonly LineEnding CRLF = new LineEnding("\r\n");


        /// <summary>
        /// Old Macintosh-style line ending consisting of a single carriage-return character
        /// </summary>
        ///
        public static readonly LineEnding CR = new LineEnding("\r");


        /// <summary>
        /// Line ending native to the operating system the process is running on
        /// </summary>
        ///
        public static readonly LineEnding Native = GetByValue(Environment.NewLine);


        private readonly string value;


        private LineEnding(string value)
        {
            this.value = value;
        }


        /// <summary>
        /// Implicit conversion from <see cref="LineEnding"/> to <see cref="string"/>
        /// </summary>
        ///
        /// <param name="lineEnding">
        /// The <see cref="LineEnding"/> to convert
        /// </param>
        ///
        public static implicit operator string(LineEnding lineEnding)
        {
            return lineEnding?.ToString();
        }


        /// <summary>
        /// Retrieve a <see cref="LineEnding"/> by string representation
        /// </summary>
        ///
        /// <param name="value">
        /// String representation of the line ending
        /// </param>
        ///
        /// <returns>
        /// The <see cref="LineEnding"/> associated with the specified string representation
        /// </returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c>
        /// </exception>
        ///
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> is not a known line ending
        /// </exception>
        ///
        public static LineEnding GetByValue(string value)
        {
            var lineEnding = FindByValue(value);
            if (lineEnding == null)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    value,
                    "Specified value is not a known line ending");
            }

            return lineEnding;
        }


        /// <summary>
        /// Search for a <c>LineEnding</c> by string representation
        /// </summary>
        ///
        /// <param name="value">
        /// String representation of the line ending
        /// </param>
        ///
        /// <returns>
        /// The <c>LineEnding</c> associated with the specified string representation
        /// - OR -
        /// <c>null</c> if no known <c>LineEnding</c> is associated with the string representation
        /// </returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c>
        /// </exception>
        ///
        public static LineEnding FindByValue(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (value == LF.ToString())
            {
                return LF;
            }
            else if (value == CRLF.ToString())
            {
                return CRLF;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Get the string representation of the line ending
        /// </summary>
        ///
        /// <returns>
        /// The string representation of the line ending
        /// </returns>
        ///
        public override string ToString()
        {
            return value;
        }

    }
}
