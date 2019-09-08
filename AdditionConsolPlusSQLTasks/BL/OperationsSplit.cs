using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdditionConsolPlusSQLTasks
{
    /// <summary>
    /// Small LINQ based helper to obtain our resultCommand variable
    /// </summary>
    public static class OperationsSplit
    {
        public static string SplitClean(this string stringElement)
        {
            string tempString = new string((from c in stringElement
                                              where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                              select c).ToArray()); // чистим команды от лишних вещей, чтобы далее было удобнее обрабатывать
            return tempString;
        }

    }
}
