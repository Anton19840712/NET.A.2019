using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Gridushko._04
{
    class BubbleSortForJaggedArraysTest
    {
        /// <summary>
        /// Tets bubblesort ascending order
        /// </summary>
        [Test]
        public void SortBubble_Ascending()
        {

            int[][] bubbleSortArray = new int[][]
            {
                new int[] {345, 365, 43, -8, 0, 546}
            };

            var resultFact = BubbleSortForJaggedArrays.BubbleSortAscending(bubbleSortArray);

            var resultExpectPlan = new int[][]
            {
                new int[] {-8, 0, 43, 345, 365, 546}
            };

            Assert.AreEqual(resultExpectPlan, resultFact);
        }

        /// <summary>
        /// Tets bubblesort descending order 
        /// </summary>
        [Test]
        public void SortBubble_Descending()
        {
            int[][] sortArray = new int[][]
            {
                new int[] { 345, 365, 43, -8, 0, 546 }
            };

            var resultFact = BubbleSortForJaggedArrays.BubbleSortDescending(sortArray);

            var resultExpectPlan = new int[][]
            {
                new int[] {546, 365, 345, 43, 0, -8}
            };

            Assert.AreEqual(resultExpectPlan, resultFact);
        }

        [Test]
        public void SortRowsSum_Ascending()
        {
            int[][] bubbleSortArray = new int[][]
            {
                new int[] {2, 8, 33},
                new int[] {21, 4, 42, 0, 28},
                new int[] {46, 2, 5, 8, 1, 0 , 43},
                new int[] {40, 7, 32, 34, 2, 33}
            };

            var resultFact = BubbleSortForJaggedArrays.BubbleSortRowsSum(bubbleSortArray);

            int[] resultExpectPlan = new int[] { 43, 95, 105, 148 };

            Assert.AreEqual(resultFact, resultExpectPlan);
        }
    }
}