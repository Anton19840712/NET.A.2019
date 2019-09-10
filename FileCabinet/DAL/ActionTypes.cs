using System;
using System.Collections.Generic;
using System.Text;

namespace FileCabinet
{
    public class ActionTypes
    {
        /// <summary>
        /// String massive of available commands in application: listcommands
        /// </summary>
        public static string[] listcommands = new string[16]
         {
            "list id",
            "firstname",
            "lastname",
            "list",
            "stat",
            "find firstname ",
            "find lastname",
            "create",
            "edit",
            "remove",
            "purge",
            "export xml",
            "export csv",
            "import xml",
            "import csv",
            "exit"
         };
    }
}
