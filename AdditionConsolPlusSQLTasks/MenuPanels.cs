using System;

namespace AdditionConsolPlusSQLTasks
{
    /// <summary>
    /// Class consists of several menus, enable user to make his own choice 
    /// to continue application using
    /// </summary>
    public class MenuPanels
    {
        /// <summary>
        /// Greeting menu
        /// </summary>
        public static void WriteInputGreeeting()
        {
            Console.WriteLine("WELCOME TO CATALOG EXPRESS\n         SYSTEM");
            Console.WriteLine("Choose your command to continue");
        }
        /// <summary>
        /// Visual separator between logical spases of menus
        /// </summary>
        public static void WriteInputLine()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(new string('.', 32));
            Console.ResetColor();
            Console.WriteLine();
        }
        /// <summary>
        /// Command menu
        /// </summary>
        public static void WriteInputCommandMainMenu()
        {
            Console.WriteLine(("LIST OF COMMANDS:\n"));
            Console.WriteLine("list - outputs collection");
            Console.WriteLine("list id, lastname...etc - outputs only indicated fields");
            Console.WriteLine("stat - outputs number of records of collection");
            Console.WriteLine("find firstname firstname_to_searh - outputs the list of all indicated first names");
            Console.WriteLine("find lastname lastname_to_searh - outputs the list of all indicated last names");
            Console.WriteLine("create - iserts new person in collection");
            Console.WriteLine("edit #number_of_id_record - changes person data in collection");
            Console.WriteLine("remove #number_of_id_record - deletes all relevant person records from collection");
            Console.WriteLine("purge - cleans out all data in collection");
            Console.WriteLine("export xml/export xml yourfilename.xml - exports all elements of collection in xml format, saves and stores");
            Console.WriteLine("export csv/export csv yourfilename.csv - exports all elements of collection in csv format, saves and stores");
            Console.WriteLine("exit - enables to leave catalog\n");

            Console.WriteLine("Enter Your Choice:\n");

            Console.Write(">");
        }
        /// <summary>
        /// Edition menu to edit records of dataset
        /// </summary>
        public static void WriteInputNumberUpdateMenu()
        {
            Console.WriteLine("\nInput the number of the field you want to change\n");
            Console.WriteLine("1 - Change firstname");
            Console.WriteLine("2 - Change lastname");
            Console.WriteLine("3 - Change date of birth");
        }
    }
}
