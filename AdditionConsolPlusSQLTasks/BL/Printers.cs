using System;
using System.Collections.Generic;

namespace AdditionConsolPlusSQLTasks
{
    /// <summary>
    /// Contains methods to print database info differently.
    /// </summary>
    public class Printers
    {
        public static void PrintPersons(IEnumerable<Person> persons)
        {
            Console.WriteLine("The whole list of persons\n");

            var table = new ConsoleTable("Id", "First name", "Last name", "Date of birth");
            foreach (var person in persons)
            {
                table.AddRow("#" + person.Id, person.Firstname, person.Lastname, person.BirthDate.ToString("ddd, dd MMMM yyyy"));
            }
            table.Write();
        }
        public static void PrintEditPerson(Person person)
        {
            var table = new ConsoleTable("Id", "First name", "Last name", "Date of birth");
            table.AddRow("#" + person.Id, person.Firstname, person.Lastname, person.BirthDate.ToString("ddd, dd MMMM yyyy"));
            table.Write();
        }
        public static void PrintWholeId(IEnumerable<Person> persons)
        {
            Console.WriteLine("The whole list of Id:\n");
            var table = new ConsoleTable("Id");
            foreach (var person in persons)
            {
                table.AddRow("#" + person.Id);
            }
            table.Write();
        }
    }
}
