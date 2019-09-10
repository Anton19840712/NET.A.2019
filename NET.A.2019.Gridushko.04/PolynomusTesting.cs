using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Gridushko._04
{
    class PolynomusTesting
    {
        [TestCase(new double[] { 1, 2, 0, -4, 17.2579, -0.001 }, new double[] { 1, 2, 0, -1, 17.2579, -0.00001 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 0, -4, 17.2579, -0.79 }, new double[] { 1, 2, 0, -1, 17.2579, -0.78 }, ExpectedResult = false)]
        public static bool Polynomial_Equals(double[] array1, double[] array2)
        {
            Polynomus p1 = new Polynomus(array1);
            Polynomus p2 = new Polynomus(array2);
            return p1.Equals(p2);
        }
    }
}
