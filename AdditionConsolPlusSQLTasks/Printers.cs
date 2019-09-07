using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionConsolPlusSQLTasks
{
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
        public static void PrintEditPerson(ref Person person)
        {
            var table = new ConsoleTable("Id", "First name", "Last name", "Date of birth");
            table.AddRow("#" + person.Id, person.Firstname, person.Lastname, person.BirthDate.ToString("ddd, dd MMMM yyyy"));
            table.Write();
        }

        public static void PrintSpecialPersons(ref Person person)
        {
            var table = new ConsoleTable("Id", "First name", "Last name", "Date of birth");
            table.AddRow("#" + person.Id, person.Firstname, person.Lastname, person.BirthDate.ToString("ddd, dd MMMM yyyy"));
            table.Write();
        }
        public static void PrintOnePerson(ref Person person)
        {
            var table = new ConsoleTable("Id");
            table.AddRow("#" + person.Id);
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
        public static void PrintWholeFirstNames(IEnumerable<Person> persons)
        {
            var table = new ConsoleTable("FirstNames");
            foreach (var person in persons)
            {
                table.AddRow(person.Firstname);
            }
            table.Write();
        }
        public static void PrintWholeLastNames(IEnumerable<Person> persons)
        {
            var table = new ConsoleTable("LastNames");
            foreach (var person in persons)
            {
                table.AddRow(person.Lastname);
            }
            table.Write();
        }
    }
}
