//https://dotnetfiddle.net/tjAu4c

using System;
using System.Linq;

namespace Classworks
{
    public class SimpleRecursiveFilter
    {
        public static void Main()
        {
            var source = new int[] { 0, 1, 2, 2, 5, 4, 4, 5, 1, 8, 4, 9, 1, 3, 4, 5, 7 };
            var result = RecursiveFilterArray(source);

            var expectedResult = new int[] { 0, 1, 2, 5, 4, 8, 9, 3, 7 };
            if (result.SequenceEqual(expectedResult))
            {
                Console.WriteLine("Task completed.");
            }
            else
            {
                Console.WriteLine("Result array is not correct.");
            }
        }

        public static int[] RecursiveFilterArray(int[] source)
        {
            int index = 0;
            if (CompareItems(source, out index))
            {
                return RecursiveFilterArray(DeleteArrayElement(source, index));
            }
            return source;
        }

        public static int[] DeleteArrayElement(int[] source, int index)
        {
            int[] returnSourse = new int[source.Length - 1];
            for (int i = 0; i < index; i++)
            {
                returnSourse[i] = source[i];
            }
            for (int i = index; i < source.Length - 1; i++)
            {
                returnSourse[i] = source[i + 1];
            }
            return returnSourse;
        }

        public static bool CompareItems(int[] source, out int index)
        {
            for (int i = 0; i < source.Length; i++)
            {
                for (int j = i; j < source.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (source[i] == source[j])
                    {
                        index = j;
                        return true;
                    }
                }
            }
            index = 0;
            return false;
        }
    }
}
