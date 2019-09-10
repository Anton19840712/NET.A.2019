using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2019.Gridushko._02
{

    [TestClass]
    public class ByteTest
    {
        [TestMethod]
        public void TestInsertNumber1()
        {
            int numberSource = 8;
            int numberin = 15;
            int i = 3;
            int j = 8;
            int correctResult = 120;
            int result = BytemManipulations.InsertNumber(numberSource, numberin, i, j);
            Assert.AreEqual(result, correctResult);
        }

        [TestMethod]
        public void TestInsertNumber2()
        {
            int numberSource = 8;
            int numberin = 15;
            int i = 0;
            int j = 0;
            int correctResult = 9;
            int result = BytemManipulations.InsertNumber(numberSource, numberin, i, j);
            Assert.AreEqual(result, correctResult);
        }

        [TestMethod]
        public void TestInsertNumber3()
        {
            int numberSource = 15;
            int numberin = 15;
            int i = 0;
            int j = 0;
            int correctResult = 15;
            int result = BytemManipulations.InsertNumber(numberSource, numberin, i, j);
            Assert.AreEqual(result, correctResult);
        }
    }
}
