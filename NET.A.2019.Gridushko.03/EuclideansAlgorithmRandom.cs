using System;
using System.Diagnostics;

namespace NET.W._2019.Gridushko._03
{
    class EuclideansAlgorithmRandom
    {
        /// <summary>
        /// Method enables to find greatest common factor
        /// for a random number set with any quantity of integers
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Insertions
            System.Int32 euclideArrayDemension = 0;
            do
            {
                Console.WriteLine("Insert number to random demension of array for test Euclidean algorithm");
                euclideArrayDemension = Convert.ToInt32(Console.ReadLine());

                if (euclideArrayDemension == 0)
                {
                    Console.WriteLine("Inserted number should not be 0");
                }
            }
            while (euclideArrayDemension == 0);

            Random rand = new Random();
            System.Int32[] myArr = new System.Int32[rand.Next(1, Math.Abs(euclideArrayDemension))];
            for (int i = 0; i < myArr.Length; i++)
            {
                Random random = new Random();
                myArr[i] = random.Next(-euclideArrayDemension, Math.Abs(euclideArrayDemension));
            }

            Array.Sort(myArr);
            Array.Reverse(myArr);
            for (int i = 0; i < myArr.Length; i++)
            {
                Console.WriteLine(myArr[i]);
            }

            #endregion

            #region EuclidanAlgorithm, Timing
            System.Int32 greatestСommonFactor = 0;
            System.Int32 searchNumber = myArr[0];

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < myArr.Length; i++)
            {
                if (myArr[i] % searchNumber == 0)
                {
                    greatestСommonFactor = searchNumber;
                }

                else
                {
                    searchNumber = greatestСommonFactor - 1;
                    greatestСommonFactor = searchNumber;
                    i = -1;
                }
            }
            watch.Stop();
            #endregion

            Console.WriteLine("GCF is {0} for {1} milliseconds", greatestСommonFactor, watch.Elapsed.TotalMilliseconds);
        }
    }
}
