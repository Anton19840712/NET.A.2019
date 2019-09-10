using NUnit.Framework;
using System;

namespace NET.W._2019.Gridushko._03
{
    [TestFixture]
    public class Tests
    {
        [TestCase(10, -50, 55, 125, ExpectedResult = 5)]
        [TestCase(3, 33, -33, 333, ExpectedResult = 3)]
        [TestCase(63, 18, 9, 9999, 27, 36, 189, ExpectedResult = 3)]
        [TestCase(9, 7, 7, 3, -2, -6, ExpectedResult = 1)]
        [TestCase(19, 18, 16, 15, 11, 2, ExpectedResult = 1)]
        public int SteinsAlgorithmIf_Executed(params int[] digits)
        {
            return GreatestСommonFactorSearching.SteinsAlgorithm(out long timeCalculationGCD, digits);
        }

        [TestCase()]
        [TestCase(1)]
        public void SteinsAlgorithmIf_NotExecuted(params int[] digits)
        {
            Assert.Throws<ArgumentException>(() => GreatestСommonFactorSearching.SteinsAlgorithm(out long timeCalculationGCD, digits));
        }
    }
}

