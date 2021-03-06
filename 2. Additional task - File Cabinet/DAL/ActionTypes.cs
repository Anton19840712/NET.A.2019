﻿namespace FileCabinet
{
    /// <summary>
    /// Consists of types of legal application commands
    /// </summary>
    public class ActionTypes
    {
        /// <summary>
        /// String massive of available commands in application: listcommands
        /// </summary>
        public static string[] listcommands = new string[14]
         {
            "list id",
            "firstname",
            "lastname",
            "list",
            "stat",
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
