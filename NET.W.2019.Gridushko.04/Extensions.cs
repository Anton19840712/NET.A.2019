using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Gridushko._04
{
    public static class Extensions
    {
        /// <summary>
        ///An extension which calculates the sum of the row in a two dimensional array
        /// </summary>
        /// <returns>An array with sum of elements</returns>
        public static int[] RowsSum(this int[][] myArray)
        {
            int[] sum = new int[myArray.Length];
            for (int i = 0; i < myArray.Length; i++)
            {
                for (int j = 0; j < myArray[i].Length; j++)
                {
                    sum[i] += myArray[i][j];
                }
            }
            return sum;
        }
    }
}
