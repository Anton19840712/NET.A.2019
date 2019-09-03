using System;

namespace NET.W._2019.Gridushko._13
{
    class Person
    {
        public event Action GoToSleep;

        public void TakeTime(DateTime now)
        {
            if (now.Hour <=8)
            {
                GoToSleep?.Invoke();
            }
        }
    }
}
