using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._01
{
    public class SortmeQuick<T> where T : IComparable
    {
        private List<T> colection;

        public SortmeQuick(List<T> colection)
        {
            if (colection == null)
            {
                throw new ArgumentNullException("NO null in collection!");
            }
            else if (colection.Count == 0)
            {
                throw new ArgumentException("NO empty collection!");
            }

            this.colection = new List<T>(colection);
        }

        public List<T> Sort()
        {
            return QuickSorting(this.colection);
        }

        private List<T> QuickSorting(List<T> currList)
        {
            if (currList.Count <= 1)
            {
                return currList;
            }

            T pivot = currList[currList.Count / 2];
            currList.RemoveAt(currList.Count / 2);

            List<T> less = new List<T>();
            List<T> gratter = new List<T>();

            foreach (var item in currList)
            {
                if (item.CompareTo(pivot) < 0)
                {
                    less.Add(item);
                }
                else
                {
                    gratter.Add(item);
                }
            }

            return Concatenate(QuickSorting(less), pivot, QuickSorting(gratter));
        }

        private List<T> Concatenate(List<T> less, T pivot, List<T> gratter)
        {
            List<T> concatenatedList = new List<T>();
            concatenatedList.AddRange(less);
            concatenatedList.Add(pivot);
            concatenatedList.AddRange(gratter);

            return concatenatedList;
        }
    }

}
