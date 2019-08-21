using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Gridushko._04
{
    public class BubbleSortForJaggedArrays
    {
        /// <summary>
        /// Bubble sort algorithm for a two dimensional array
        /// </summary>
        /// <param name="myArray"></param>
        /// <returns></returns>
        public static int[][] BubbleSortAscending(int[][] myArray)
        {
            if (myArray is null)
            {
                throw new ArgumentNullException("There is no null in a jagged array", nameof(myArray));
            }
            if (myArray.Length == 0)
            {
                throw new ArgumentException("There is no empty in a jagged array", nameof(myArray));
            }
            foreach (var item in myArray)
            {
                BubbleSortAscending(item);
            }
            return myArray;
        }

        /// <summary>
        /// Bubble sort for myArray asc
        /// </summary>
        public static int[] BubbleSortAscending(int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                for (int j = i + 1; j < myArray.Length; j++)
                {
                    if (myArray[i] > myArray[j])
                    {
                        Swap(ref myArray[i], ref myArray[j]);
                    }
                }
            }
            return myArray;
        }
        /// <summary>
        /// Bubble sort for myArray desc 1 part
        /// </summary>
        public static int[][] BubbleSortDescending(int[][] myArray)
        {
            if (myArray is null)
            {
                throw new ArgumentNullException("Jagged myArray cannot be null", nameof(myArray));
            }
            if (myArray.Length == 0)
            {
                throw new ArgumentException("Jagged myArray cannot be empty.", nameof(myArray));
            }
            foreach (var item in myArray)
            {
                BubbleSortDescending(item);
            }
            return myArray;
        }

        /// <summary>
        /// Bubble sort for myArray desc 2 part
        /// </summary>
        public static int[] BubbleSortDescending(int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                for (int j = i + 1; j < myArray.Length; j++)
                {
                    if (myArray[i] < myArray[j])
                    {
                        Swap(ref myArray[i], ref myArray[j]);
                    }
                }
            }
            return myArray;
        }
        /// <summary>
        /// An emplementation of row sum sorting algorithm
        /// </summary>
        /// <param name="myArray">Two dementional myArray for sorting</param>
        /// <returns>Sorted myArray</returns>
        public static int[] BubbleSortRowsSum(int[][] myArray)
        {
            if (myArray is null)
            {
                throw new ArgumentNullException("Jagged myArray cannot be null", nameof(myArray));
            }
            if (myArray.Length == 0)
            {
                throw new ArgumentException("Jagged myArray cannot be empty.", nameof(myArray));
            }
            int[] sum = myArray.RowsSum();
            BubbleSortAscending(sum);
            return sum;
        }

        /// <summary>
        /// Item swap method
        /// </summary>
        private static void Swap(ref int firstElement, ref int secondElement)
        {
            int temporary = firstElement;
            firstElement = secondElement;
            secondElement = temporary;
        }
    }
}
