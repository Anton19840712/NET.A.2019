using System;
using System.Text;
using static System.Math;

namespace NET.W._2019.Gridushko._03
{
    /// <summary>
    ///The class contains static method that convert double-precision floating point value to binary format.
    /// </summary>
    public static class MethodExtensionForDoubles
    {
        
        private const int TailMantissabit = 52;
        private const int MiddlePartBit = 11;
        /// <summary>
        /// The method converts the double value to binary value.
        /// </summary>
        /// <param name="doubleVal"></param>
        /// <returns></returns>
        public static string ToBitConvertionsFromDouble(this double doubleVal)
        {
            string result = string.Empty;

            if (doubleVal < 0)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }

            string[] splitArray = doubleVal.ToString().Split(',');
            string unitedStr = IntToBin(Abs(int.Parse(splitArray[0])));
            string bitStrReminder = RemainderToBit(double.Parse("0," + splitArray[1]), TailMantissabit - unitedStr.Length + 1);
            string expToBit = IntToBin(unitedStr.Length - 1 + 1023);

            for (int i = 0; i < expToBit.Length - MiddlePartBit; i++)
            {
                expToBit += "0";
            }

            result += expToBit + GetMantissa(unitedStr, bitStrReminder);
            return result;
        }
        private static string RemainderToBit(double remaindMe, int maxLength)
        {

            var str = new StringBuilder();
            if (remaindMe < 0 || remaindMe >= 1)
            {
                throw new ArgumentException();
            }

            if (remaindMe == 0)
            {
                for (int i = 0; i < maxLength - 1; i++)
                {
                    str.Append("0");
                }
                return str.ToString();
            }
            for (int i = 0; i < maxLength; i++)
            {
                remaindMe *= 2;
                if (remaindMe == 1)
                {
                    str.Append("1");
                    return str.ToString();
                }
                if (remaindMe > 1)
                {
                    str.Append("1");
                    remaindMe--;
                }
                else
                {
                    str.Append("0");
                }
                remaindMe = Round(remaindMe, 3);
            }

            return str.ToString();
        }
        private static string IntToBin(long number)
        {
            var stBuild = new StringBuilder();

            for (var i = sizeof(long) * 8 - 1; i >= 0; i--)
                stBuild.Append((number & ((long)1 << i)) != 0 ? '1' : '0');

            return stBuild.ToString().TrimStart('0');
        }
        private static string GetMantissa(string wholePart, string remainderPart)
        {
            var strBuild = new StringBuilder();
            char[] ch = wholePart.ToCharArray();
            for (int i = 1; i < ch.Length; i++)
            {
                strBuild.Append(ch[i]);
            }
            strBuild.Append(remainderPart);

            for (var i = 0; i <= TailMantissabit - wholePart.Length - remainderPart.Length; i++)
            {
                strBuild.Append("0");
            }
            strBuild.ToString();
            int m = strBuild.Length;
            return strBuild.ToString();
        }
    }
}
