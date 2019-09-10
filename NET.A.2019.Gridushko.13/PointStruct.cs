using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Gridushko._13
{
    public struct PointStruct
    {
        public int X { get; }
        public int Y { get; }

        public PointStruct(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class PointComparer : Comparer<PointStruct>
    {
        public override int Compare(PointStruct x, PointStruct y)
        {
            return x.X.CompareTo(y.Y);
        }
    }
}
