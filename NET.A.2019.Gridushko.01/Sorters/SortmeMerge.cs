using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._01
{
    public class SortmeMerge<T> where T : IComparable
    {
        private List<T> colection;
        /// <summary>
        /// Checking if list null or empty
        /// </summary>
        /// <param name="colection"></param>
        public SortmeMerge(List<T> colection)
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
            return SortValues(this.colection);
        }

        /// <summary>
        /// Sorting values logic
        /// </summary>
        /// <returns></returns>
        private List<T> SortValues(List<T> colection)
        {
            if (colection.Count <= 1)
            {
                return colection;
            }
            else
            {
                int middle = colection.Count / 2;
                List<T> left = new List<T>();
                List<T> right = new List<T>();

                for (int i = 0; i < middle; i++)
                {
                    left.Add(colection[i]);
                }

                for (int i = 0; i < colection.Count - middle; i++)
                {
                    right.Add(colection[middle + i]);
                }

                left = SortValues(left);
                right = SortValues(right);

                return Merge(new Queue<T>(left), new Queue<T>(right));
            }
        }

        private List<T> Merge(Queue<T> left, Queue<T> right)
        {
            List<T> result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.Peek().CompareTo(right.Peek()) <= 0)
                    {
                        result.Add(left.Dequeue());
                    }
                    else
                    {
                        result.Add(right.Dequeue());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.Dequeue());
                }
                else
                {
                    result.Add(right.Dequeue());
                }
            }

            return result;
        }
    }
}
