//https://dotnetfiddle.net/2hJJl4
using System;
using System.Linq;

// Задание: реализовать метод FilterArray таким образом, чтобы он возвращал массив равный expectedArray.

public class Program
{
    public static void Main()
    {
        var source = new int[] { 0, 1, 2, 2, 5, 4, 4, 5, 1, 8, 4, 9, 1, 3, 4, 5, 7 };

        var result = FilterArray(source);

        var expectedArray = new int[] { 0, 1, 2, 5, 4, 8, 9, 3, 7 };
        if (result.SequenceEqual(expectedArray))
        {
            Console.WriteLine("Task completed.");
        }
        else
        {
            Console.WriteLine("Result array is not correct.");
        }
    }

    public static int[] FilterArray(int[] source)
    {
        return source.Distinct<int>().ToArray();
    }
}