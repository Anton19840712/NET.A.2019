using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._01
{
    /// <summary>
    /// Main sorter callers of algorithms like quicksort and mergesort
    /// </summary>
    public class QuickAndMergeMainSorting
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 11, 72, 46, 53, 32, 51, 71, 11, 33, 20, 17, 21 };
            SortmeQuick<int> sortingQuick = new SortmeQuick<int>(numbers);
            numbers = sortingQuick.Sort();

            Console.WriteLine(string.Join(",", numbers));

            SortmeMerge<int> sortingMerge = new SortmeMerge<int>(numbers);
            numbers = sortingMerge.Sort();

            Console.WriteLine(string.Join(",", numbers));
        }
    }
}
