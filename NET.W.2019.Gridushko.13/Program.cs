using System;

namespace NET.W._2019.Gridushko._13
{
    public delegate void MyDelegate();
    public class Program
    {
        //public delegate int ValueDelegate(int i);
        //public delegate void MyDelegate();
        //public event MyDelegate Event;
        //public event Action EventAction;
        static void Main(string[] args)
        {
            #region
            //    MyDelegate myDelegate = Method1;
            //    myDelegate += Method4;
            //    myDelegate();

            //    MyDelegate myDelegate2 = new MyDelegate(Method4);
            //    myDelegate2 += Method4;
            //    myDelegate2 -= Method4;
            //    myDelegate2.Invoke();

            //    MyDelegate myDelegate3 = myDelegate + myDelegate2;
            //    myDelegate3.Invoke();
            //    var valueDelegate = new ValueDelegate(MethodValue);

            //    valueDelegate((new Random()).Next(10, 50));

            //    Action action = Method1;
            //    action();
            //    Console.ReadLine();
            //}

            //public static int MethodValue(int i)
            //{
            //    Console.WriteLine(i);
            //    return i;
            //}
            //public static void Method1()
            //{
            //    Console.WriteLine("Method1");
            //}
            //public static int Method2()
            //{
            //    Console.WriteLine("Method2");
            //    return 0;
            //}
            //public static void Method3(int i)
            //{
            //    Console.WriteLine("Method3");
            //}
            //public static void Method4()
            //{
            //    Console.WriteLine("Method4");
            //}
            #endregion

            Person person = new Person();
            person.GoToSleep += Person_GoToSleep;
            person.TakeTime(DateTime.Parse("27.12.2019 21:12:00"));
            person.TakeTime(DateTime.Parse("27.12.2019 4:12:00"));
        }

        private static void Person_GoToSleep()
        {
            Console.WriteLine("Человек пошел спать");
            Console.ReadLine();
        }
    }
}
