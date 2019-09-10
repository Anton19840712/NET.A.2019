using System;

namespace NET.W._2019.Gridushko._14

{
    class Program
    {
        static void Main(string[] args)
        {
            string anyString = "Mama мылом моет раму";
            string newString = anyString.StringCutter();
            Console.WriteLine(newString);
            Console.ReadLine();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace lecture_15
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("input string");
//            string str = Console.ReadLine();
//            string newString = str.StringfiveSymbol();
//            Console.WriteLine(newString);
//            Console.ReadLine();
//        }
//    }
//}