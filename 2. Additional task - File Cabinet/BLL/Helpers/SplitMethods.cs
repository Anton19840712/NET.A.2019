using System.Linq;

namespace FileCabinet
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
                                              select c).ToArray());
            return tempString;
        }
    }
}
