using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._11
{
    public class Listener
    {
        public void Notify(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Message: {e.Message}");
        }
    }
}
