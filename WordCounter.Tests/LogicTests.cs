using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Tests
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void TestSpecification()
        {
            var result = FileParser.CountWords("SpecificationTest.txt");
            Assert.AreEqual(1,result["Go"]);
            Assert.AreEqual(2,result["do"]);
            Assert.AreEqual(2,result["that"]);
            Assert.AreEqual(1,result["thing"]);
            Assert.AreEqual(1,result["you"]);
            Assert.AreEqual(1,result["so"]);
            Assert.AreEqual(1,result["well"]);
        }


        //Failing unit test here to cover case where an apostrophe i.e. Harry's or it's is not properly handled.
        [TestMethod]
        public void TestApostrophes()
        {
            var result = FileParser.CountWords("apostrophes.txt");
            Assert.AreEqual(2, result["Harrys"]);
            Assert.AreEqual(2, result["Harry's"]);
        }
    }
}
