using System;

namespace NET.W._2019.Gridushko._11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var timerSystem = new TimeManagementInstance();

            var listenerVar1 = new Listener();
            var listenerVar2 = new Listener();

            timerSystem.Notification += listenerVar1.Notify;
            timerSystem.Notification += listenerVar2.Notify;

            timerSystem.NotifyOnTimer(1, "Waiting for a onr second");

            Console.ReadLine();
        }
    }
}


