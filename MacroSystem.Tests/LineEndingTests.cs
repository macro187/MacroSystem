using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace
MacroSystem.Tests
{


[TestClass]
public class
LineEndingTests
{


[TestMethod]
public void
FindByValue_ValidLineEnding_Returns_Correct()
{
    Assert.AreSame(LineEnding.LF, LineEnding.FindByValue("\n"));
}


[TestMethod]
public void
FindByValue_InvalidLineEnding_Returns_Null()
{
    Assert.AreSame(null, LineEnding.FindByValue("not a line ending"));
}


[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void
FindByValue_Null_Throws_ArgumentNullException()
{
    LineEnding.FindByValue(null);
}


[TestMethod]
[ExpectedException(typeof(ArgumentOutOfRangeException))]
public void
GetByValue_InvalidLineEnding_Throws_ArgumentOutOfRangeException()
{
    LineEnding.GetByValue("not a line ending");
}


[TestMethod]
public void
Native_Is_Correct()
{
    Assert.AreEqual(Environment.NewLine, LineEnding.Native.ToString());
}


[TestMethod]
public void
ToString_Returns_Correct()
{
    Assert.AreEqual("\n", LineEnding.LF.ToString());
}


[TestMethod]
public void
ImplicitConversionToString_Returns_Correct()
{
    string s = LineEnding.LF;
    Assert.AreEqual("\n", s);
}


[TestMethod]
public void
EqualityComparisonToString_Works_Correctly()
{
    Assert.IsTrue("\n" == LineEnding.LF);
    Assert.IsTrue(LineEnding.LF == "\n");
}


[TestMethod]
public void
InequalityComparisonToString_Works_Correctly()
{
    Assert.IsTrue("nope" != LineEnding.LF);
    Assert.IsTrue(LineEnding.LF != "nope");
}


}
}
