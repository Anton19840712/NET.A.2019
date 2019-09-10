using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._02
{
    /// <summary>
    /// Class to manipulate bytes, contains several methods
    /// </summary>
    public class BytemManipulations

    {
        /// <summary>
        /// Methods inserts bits so that the bits of the second number could take position from bit j to bit i
        /// </summary>
        /// <param name="numberSource"></param>
        /// <param name="numberin"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static int InsertNumber(int numberSource, int numberin, int i, int j)
        {
            BitPositionChecking(i, j);

            BitArray SourceArray = new BitArray(new[] { numberSource });
            BitArray InArray = new BitArray(new[] { numberin });

            for (int repeat = i, iteration = 0; repeat <= j; repeat++, iteration++)
            {
                if (SourceArray[repeat])
                {
                    SourceArray[repeat] = SourceArray[repeat] & InArray[iteration];
                }
                else
                {
                    SourceArray[repeat] = SourceArray[repeat] | InArray[iteration];
                }
            }

            return ConvertFrombitsTointeger(SourceArray);
        }

        /// <summary>
        /// Method cheks the right position of bit
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void BitPositionChecking(int i, int j)
        {
            if (i < 0 || j < 0 || i > 31 || j > 31)
            {
                throw new ArgumentOutOfRangeException("Position of bits - wrong!");
            }

            if (i > j)
            {
                throw new ArgumentException("Position of bits - wrong!");
            }
        }
        /// <summary>
        /// Method converts bits from array to numbers
        /// </summary>
        /// <param name="arrayofbits"></param>
        /// <returns></returns>
        private static int ConvertFrombitsTointeger(BitArray arrayofbits)
        {
            if (arrayofbits.Length > 32)
            {
                throw new ArgumentException("It's more than 32 bits, we need less!");
            }

            int[] numsarray = new int[1];
            arrayofbits.CopyTo(numsarray, 0);
            return numsarray[0];
        }
        /// <summary>
        /// Method finds the next the largest number
        /// </summary>
        /// <param name="num"></param>
        /// <param name="FindNextBiggerNumberTimer"></param>
        /// <returns></returns>
        public static int FindNextBiggerNumber(int num, out long FindNextBiggerNumberTimer)
        {
            int followingBigNum;
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();
            followingBigNum = FindNextBiggerNumber(num);
            stopwatch.Stop();

            FindNextBiggerNumberTimer = stopwatch.ElapsedMilliseconds;

            return followingBigNum;
        }
        /// <summary>
        /// Method returns the largest integer
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static int FindNextBiggerNumber(int num)
        {
            int[] numArrays = MakeIntsForArray(num);

            int index = FindIndex(numArrays);

            if (index < numArrays.Length && index != -1)
            {
                Swap(ref numArrays[index], ref numArrays[index + 1]);
                Array.Sort(numArrays, index + 1, numArrays.Length - index - 1);
            }
            else
            {
                return -1;
            }

            return ParseIntergersOutArray(numArrays);
        }
        /// <summary>
        /// Metthod finds the index of number, array should be sorted from
        /// </summary>
        /// <param name="numsarray"></param>
        /// <returns></returns>
        private static int FindIndex(int[] numsarray)
        {
            for (int i = numsarray.Length - 1; i > 0; i--)
            {
                if (numsarray[i] > numsarray[i - 1])
                {
                    return i - 1;
                }
            }

            return -1;
        }
        /// <summary>
        /// Method makes array of source number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static int[] MakeIntsForArray(int num)
        {
            int[] numsarray = new int[num.ToString().Length];

            for (int i = numsarray.Length - 1; i >= 0; i--)
            {
                numsarray[i] = num % 10;
                num = num / 10;
            }

            return numsarray;
        }
        /// <summary>
        /// Method creates numbers from array
        /// </summary>
        /// <param name="numsarray"></param>
        /// <returns></returns>
        private static int ParseIntergersOutArray(int[] numsarray)
        {
            int num = 0;
            for (int i = 0; i < numsarray.Length; i++)
            {
                num += numsarray[i];
                num *= 10;
            }
            return num / 10;
        }

        /// <summary>
        /// Method to swap numbers
        /// </summary>
        /// <param name="numberSource"></param>
        /// <param name="numberin"></param>
        private static void Swap(ref int numberSource, ref int numberin)
        {
            int temp = numberSource;
            numberSource = numberin;
            numberin = temp;
        }
        /// <summary>
        /// Method filters the list, so that only numbers that contain needed digit could be in the output.
        /// </summary>
        /// <param name="numsarray"></param>
        /// <param name="numeric"></param>
        /// <returns></returns>
        public static int[] FilterDigit(int[] numsarray, int numeric)
        {
            if (numsarray.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Our array - empty!");
            }
            if (numeric < 0 || numeric > 9)
            {
                throw new ArgumentException("This is wrong num!!");
            }

            List<int> newArray = new List<int>();

            for (int i = 0; i < numsarray.Length; i++)
            {
                if (numsarray[i].ToString().Contains(numeric.ToString()))
                {
                    newArray.Add(numsarray[i]);
                }
            }

            return newArray.ToArray();
        }
        /// <summary>
        /// Method calculates the root of the nth (n∈N) 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="level"></param>
        /// <param name="exactness"></param>
        /// <returns></returns>
        public static double FindNthRoot(double num, int level, double exactness)
        {
            if (level < 0)
            {
                throw new ArgumentOutOfRangeException("This num is not natural");
            }

            if ((num < 0) && (level % 2 == 0))
            {
                throw new ArgumentOutOfRangeException("Can not calculate your root because there is a negative num.");
            }

            if (exactness > 1 || exactness <= 0)
            {
                throw new ArgumentOutOfRangeException("You should have values > 0 and < or == 1.");
            }

            int intOutcome = FindIntAccuracy(exactness);

            double tempOutcome;
            double outcome = num;

            do
            {
                tempOutcome = outcome;
                outcome = tempOutcome - ((Math.Pow(tempOutcome, level) - num) / (Math.Pow(tempOutcome, level - 1) * level));
            }
            while (Math.Abs(outcome - tempOutcome) > exactness);

            return Math.Round(outcome, intOutcome);
        }
        /// <summary>
        /// The method converts the exactness to int.
        /// </summary>
        /// <param name="exactness"></param>
        /// <returns></returns>
        private static int FindIntAccuracy(double exactness)
        {
            int intOutcome = 0;
            while (exactness < 1)
            {
                exactness *= 10;
                intOutcome++;
            }

            return intOutcome;
        }
    }
}
