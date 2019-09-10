using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NET.W._2019.Gridushko._01
{
    [TestClass]
    public class MergeSortingtests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionNull()
        {
            SortmeMerge<int> sorter = new SortmeMerge<int>(null);
        }
        /// <summary>
        /// Checking if our collection is empty
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CollectionEmpty()
        {
            SortmeMerge<int> sorter = new SortmeMerge<int>(new List<int>());
        }
        /// <summary>
        /// Checking if our collection onle one item
        /// </summary>
        [TestMethod]
        public void CollectionOneItem()
        {
            List<int> numbers = new List<int>() { 1 };
            SortmeMerge<int> sorter = new SortmeMerge<int>(numbers);
            List<int> sortedList = new List<int>(sorter.Sort());

            Assert.AreEqual(numbers[0], sortedList[0]);
        }

        [TestMethod]
        public void CollectionMultipleItem()
        {
            List<int> numbers = new List<int>() { 1, 22, 3, 1, 2, 3, 2, 6, 5, 17, 8, 7 };
            List<int> sortedValues = new List<int>() { 1, 1, 1, 1, 2, 2, 3, 5, 5};
            SortmeMerge<int> sorter = new SortmeMerge<int>(numbers);
            List<int> sortedList = new List<int>(sorter.Sort());

            for (int i = 0; i < numbers.Count; i++)
            {
                Assert.AreEqual(sortedValues[i], sortedList[i]);
            }
        }

        [TestMethod]
        public void CollectionSortedItem()
        {
            List<int> sortedValues = new List<int>() { 1, 2, 4, 4, 4, 4, 4, 5, 8, 8, 9, 9 };
            SortmeMerge<int> sorter = new SortmeMerge<int>(sortedValues);
            List<int> sortedList = new List<int>(sorter.Sort());

            for (int i = 0; i < sortedValues.Count; i++)
            {
                Assert.AreEqual(sortedValues[i], sortedList[i]);
            }
        }
    }
}
