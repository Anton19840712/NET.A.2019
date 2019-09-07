using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdditionConsolPlusSQLTasks
{
    public class OperationsSplit
    {
        public static void SplitClean(string stringElement)
        {
            string preResultCommand = new string((from c in stringElement
                                                  where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                                  select c).ToArray()); // чистим команды от лишних вещей, чтобы далее было удобнее обрабатывать
        }
    }
}
