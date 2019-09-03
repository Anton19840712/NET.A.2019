//using System;
//using System.Collections.Generic;

//namespace NET.W._2019.Gridushko._11
//{
//    /// <summary>
//    /// Method demonstrates the sequence of generation of Fibonacci numbers
//    /// </summary>
//    public class Fibonaccimethod
//    {
//        public static int Fibonacci(int n)
//        {
//            int fib1 = 0;
//            int fib2 = 1;
//            for (int i = 0; i < n; i++)
//            {
//                int temporary = fib1;
//                fib1 = fib2;
//                fib2 = temporary + fib2;
//            }
//            return fib1;
//        }
//        static void Main(string[] args)
//        {
//            for (int i = 0; i < 15; i++)
//            {
//                Console.WriteLine(Fibonacci(i));
//            }
//        }
//    }
//}
