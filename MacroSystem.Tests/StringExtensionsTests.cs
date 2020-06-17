using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MacroSystem.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {

        const string SINGLE_LINE = "1";
        const string MULTI_LINE_CRLF = "1\r\n2\r\n3\r\n4";
        const string MULTI_LINE_LF = "1\n2\n3\n4";
        const string MULTI_LINE_CR = "1\r2\r3\r4";
        const string MULTI_LINE_MIXED = "1\r\n2\n3\r4";
        const string MULTI_LINE_MIXED_EMPTY_FIRST_AND_LAST = "\r\n1\r\n2\n3\r4\r\n";
        const string MULTI_LINE_MIXED_EMPTY_FIRST_AND_LAST_PREFIXED = "prefix\r\nprefix1\r\nprefix2\nprefix3\rprefix4\r\nprefix";
        const string MULTI_LINE_MIXED_EMPTY_FIRST_AND_LAST_INDENTED = "  \r\n  1\r\n  2\n  3\r  4\r\n  ";


        [TestMethod]
        public void NormalizeLineEndings_SingleLine_Returns_Same()
        {
            Assert.AreEqual(
                SINGLE_LINE,
                StringExtensions.NormalizeLineEndings(SINGLE_LINE, LineEnding.CRLF)
                );
        }


        [TestMethod]
        public void NormalizeLineEndings_Empty_Returns_Empty()
        {
            Assert.AreEqual(
                "",
                StringExtensions.NormalizeLineEndings("", LineEnding.CRLF)
                );
        }


        [TestMethod]
        public void NormalizeLineEndings_CRLF_Returns_Correct()
        {
            Assert.AreEqual(
                MULTI_LINE_CRLF,
                StringExtensions.NormalizeLineEndings(MULTI_LINE_CRLF, LineEnding.CRLF)
                );
        }


        [TestMethod]
        public void NormalizeLineEndings_LF_Returns_Correct()
        {
            Assert.AreEqual(
                MULTI_LINE_CRLF,
                StringExtensions.NormalizeLineEndings(MULTI_LINE_LF, LineEnding.CRLF)
                );
        }


        [TestMethod]
        public void NormalizeLineEndings_CR_Returns_Correct()
        {
            Assert.AreEqual(
                MULTI_LINE_CRLF,
                StringExtensions.NormalizeLineEndings(MULTI_LINE_CR, LineEnding.CRLF)
                );
        }


        [TestMethod]
        public void NormalizeLineEndings_Mixed_Returns_Correct()
        {
            Assert.AreEqual(
                MULTI_LINE_CRLF,
                StringExtensions.NormalizeLineEndings(MULTI_LINE_MIXED, LineEnding.CRLF)
                );
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NormalizeLineEndings_Null_Throws_ArgumentNullException()
        {
            StringExtensions.NormalizeLineEndings(null, LineEnding.CRLF);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NormalizeLineEndings_NullLineEnding_Throws_ArgumentNullException()
        {
            StringExtensions.NormalizeLineEndings("", null);
        }


        [TestMethod]
        public void SplitLines_Empty_Yields_SingleEmptyLine()
        {
            Assert.IsTrue(
                StringExtensions.SplitLines("")
                    .SequenceEqual(new[] {""}));
        }


        [TestMethod]
        public void SplitLines_Mixed_Yields_Correct()
        {
            Assert.IsTrue(
                StringExtensions.SplitLines(MULTI_LINE_MIXED)
                    .SequenceEqual(new[] {"1", "2", "3", "4"}));
        }


        [TestMethod]
        public void SplitLines_EmptyFirstAndLast_Yields_Correct()
        {
            Assert.IsTrue(
                StringExtensions.SplitLines(MULTI_LINE_MIXED_EMPTY_FIRST_AND_LAST)
                    .SequenceEqual(new[] {"", "1", "2", "3", "4", ""}));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SplitLines_Null_Throws_ArgumentNullException()
        {
            StringExtensions.SplitLines(null);
        }


        [TestMethod]
        public void Prefix_Returns_Correct()
        {
            Assert.AreEqual(
                StringExtensions.NormalizeLineEndings(MULTI_LINE_MIXED_EMPTY_FIRST_AND_LAST_PREFIXED),
                StringExtensions.Prefix(MULTI_LINE_MIXED_EMPTY_FIRST_AND_LAST, "prefix"));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Prefix_Null_Value_Throws_ArgumentNullException()
        {
            StringExtensions.Prefix(null, "");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Prefix_Null_Prefix_Throws_ArgumentNullException()
        {
            StringExtensions.Prefix("", null);
        }


        [TestMethod]
        public void Indent_Returns_Correct()
        {
            Assert.AreEqual(
                StringExtensions.NormalizeLineEndings(MULTI_LINE_MIXED_EMPTY_FIRST_AND_LAST_INDENTED),
                StringExtensions.Indent(MULTI_LINE_MIXED_EMPTY_FIRST_AND_LAST));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Indent_Null_Value_Throws_ArgumentNullException()
        {
            StringExtensions.Indent(null);
        }

    }
}
