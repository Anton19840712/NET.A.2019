using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._11
{
    public class Binarysearch
    {
        /// <summary>
        /// Entry point in programm
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[100];
            for (int i = numbers.Length-1;  i>-1; i--)
            {
                numbers[i] = random.Next(1, 100);
            }
            Array.Sort(numbers);

            Console.Write("Please enter the number you searh(1-100):");
            int searchNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Value found at index: " + BinarySearch(numbers, searchNumber));
            Console.ReadKey();
        }
        /// <summary>
        /// Methods implements logic of binary search
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] numbers, int searchValue)
        {
            int midIndex;
            int leftIndex = 0;
            int rightIndex = numbers.Length - 1;
            while (leftIndex <= rightIndex)
            {
                midIndex = leftIndex + ((rightIndex - leftIndex) / 2);
                if (numbers[midIndex] == searchValue)
                {
                    return midIndex;
                }
                else
                {
                    if (numbers[midIndex] > searchValue)
                    {
                        rightIndex = midIndex - 1;
                    }
                    else
                    {
                        leftIndex = midIndex + 1;
                    }
                }
            }
            return -1;//If the number doesn't exists
        }
    }
}
