using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._12
{
    class Person
    {
        public event Action GoToSleep;
        public void TakeTime(DateTime now)
        {
            if (now.Hour <= 8)
            {
                GoToSleep?.Invoke();
            }
        }
    }
}
