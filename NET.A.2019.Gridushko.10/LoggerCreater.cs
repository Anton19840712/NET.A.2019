using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._10
{
    public class LoggerCreater
    {
        public static ILogger GetLogger(string className)
        {
            return new NLogLogger(className);
        }
    }
}
