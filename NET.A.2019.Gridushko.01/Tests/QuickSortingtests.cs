using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NET.W._2019.Gridushko._01
{
    [TestClass]
    public class QuickSortingtests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionNull()
        {
            SortmeQuick<int> sorter = new SortmeQuick<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CollectionEmpty()
        {
            SortmeQuick<int> sorter = new SortmeQuick<int>(new List<int>());
        }

        [TestMethod]
        public void CollectionOneItem()
        {
            List<int> numbers = new List<int>() { 1 };
            SortmeQuick<int> sorter = new SortmeQuick<int>(numbers);
            List<int> sortedList = new List<int>(sorter.Sort());

            Assert.AreEqual(numbers[0], sortedList[0]);
        }

        [TestMethod]
        public void CollectionMultipleItem()
        {
            List<int> numbers = new List<int>() { 1, 22, 3, 1, 2, 3, 2, 6, 5, 17, 8, 7 };
            List<int> sortedNumbers = new List<int>() { 1, 1, 1, 1, 2, 2, 3, 5, 5 };
            SortmeQuick<int> sorter = new SortmeQuick<int>(numbers);
            List<int> sortedList = new List<int>(sorter.Sort());

            for (int i = 0; i < numbers.Count; i++)
            {
                Assert.AreEqual(sortedNumbers[i], sortedList[i]);
            }
        }

        [TestMethod]
        public void CollectionItem()
        {
            List<int> sortedNumbers = new List<int>() { 1, 2, 4, 4, 4, 4, 4, 5, 8, 8, 9, 9 };
            SortmeQuick<int> sorter = new SortmeQuick<int>(sortedNumbers);
            List<int> sortedList = new List<int>(sorter.Sort());

            for (int i = 0; i < sortedNumbers.Count; i++)
            {
                Assert.AreEqual(sortedNumbers[i], sortedList[i]);
            }
        }
    }
}
