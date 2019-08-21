using System;
using System.Diagnostics;
using System.Linq;

namespace NET.W._2019.Gridushko._03
{
    /// <summary>
    /// This class containts Stein's method which can find myGSF.
    /// </summary>
    public class GreatestСommonFactorSearching
    {
        private delegate int GCF_CalculationsAlgorithm(int myFirstDigit, int mySecondDigit);

        /// <summary>
        /// Method calculates GCF using Steins calculation logic
        /// </summary>
        /// <param name="GCF_TimeCalculation"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int SteinsAlgorithm(out long GCF_TimeCalculation, params int[] digits)
        {
            return Calculation(out GCF_TimeCalculation, new GCF_CalculationsAlgorithm(SteinsAlgorithm), digits);
        }
        /// <summary>
        /// Private method to calculate GSF using two numbers
        /// </summary>
        /// <param name="myFirstDigit">First number in calculations</param>
        /// <param name="mySecondDigit">Second number in calculations</param>
        /// <returns></returns>
        private static int SteinsAlgorithm(int myFirstDigit, int mySecondDigit)
        {
            if (myFirstDigit == 0)
            {
                return mySecondDigit;
            }

            if (mySecondDigit == 0)
            {
                return myFirstDigit;
            }

            if (myFirstDigit == mySecondDigit)
            {
                return myFirstDigit;
            }

            if ((myFirstDigit == 1) || (mySecondDigit == 1))
            {
                return 1;
            }

            if (myFirstDigit % 2 == 0)
            {
                return (mySecondDigit % 2 == 0) ? (2 * SteinsAlgorithm(myFirstDigit / 2, mySecondDigit / 2)) : (SteinsAlgorithm(myFirstDigit / 2, mySecondDigit));
            }
            else
            {
                return (mySecondDigit % 2 == 0) ? (SteinsAlgorithm(myFirstDigit, mySecondDigit / 2)) : (SteinsAlgorithm(mySecondDigit, Math.Abs(myFirstDigit - mySecondDigit)));
            }
        }
        /// <summary>
        /// Method calculates GSF
        /// </summary>
        /// <param name="GCF_TimeCalculation">This is an output parameter and contains the execution time of the algorithm</param>
        /// <param name="GCF_CalculationsAlgorithm">The delegate with the algorithm method inside</param>
        /// <param name="digits">This is array of params with numbers for finding the GCF</param>
        /// <returns></returns>
        private static int Calculation(out long GCF_TimeCalculation, GCF_CalculationsAlgorithm GCF_CalculationsAlgorithm, int[] digits)
        {
            if (digits.Length <= 1)
            {
                throw new ArgumentException("Our array is empty or there is only one element in it.");
            }

            All_Digits(digits);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int myGSF = Calculation(digits, GCF_CalculationsAlgorithm);
            stopwatch.Stop();
            GCF_TimeCalculation = stopwatch.ElapsedMilliseconds;
            return myGSF;
        }
        /// <summary>
        /// Method enables to find the absolute value of all digits.
        /// </summary>
        /// <param name="digits"></param>
        private static void All_Digits(int[] digits)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = Math.Abs(digits[i]);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="digits">This is array of params with numbers for finding the GCF</param>
        /// <param name="GCF_CalculationsAlgorithm">The delegate with the algorithm method inside</param>
        /// <returns></returns>
        private static int Calculation(int[] digits, GCF_CalculationsAlgorithm GCF_CalculationsAlgorithm)
        {
            int[] myGSF_Array = new int[digits.Length - 1];

            for (int i = 0; i < digits.Length - 1; i++)
            {
                myGSF_Array[i] = GCF_CalculationsAlgorithm(digits[i], digits[i + 1]);
            }
            return myGSF_Array.Min();
        }
    }
}

