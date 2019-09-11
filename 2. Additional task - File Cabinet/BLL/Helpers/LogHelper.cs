using System.Runtime.CompilerServices;

namespace _2.Additional_task___File_Cabinet.BLL.Helpers
{
    public class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
