using NET.W._2019.Gridushko._03;
using NUnit.Framework;

namespace TestsMethodExtensionForDoubles
{
    public class TestsMethodExtensionForDoubles
    {

        [TestCase(57.6, ExpectedResult = "0100000001001100110011001100110011001100110011001100110011001101")]
        [TestCase(123.8, ExpectedResult = "0100000001011110111100110011001100110011001100110011001100110011")]
        [TestCase(-2342345.235423, ExpectedResult = "110000010100000111011110111001001001111000100010 0101011101000011")]
        public string ToBitConvertionsFromDouble_Test(double value)
        {
            return value.ToBitConvertionsFromDouble();
        }
    }
}