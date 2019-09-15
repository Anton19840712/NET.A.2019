using System;
using System.Collections.Generic;
using System.Globalization;

namespace FileCabinet
{
    /// <summary>
    /// Contains methods to print database info differently.
    /// </summary>
    public class Printers
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void PrintPersons(IEnumerable<Person> persons)
        {
            Console.WriteLine("The whole list of persons\n");

            var table = new TableFramer("Id", "First name", "Last name", "Date of birth");
            foreach (var person in persons)
            {
                table.AddRow("#" + person.Id, person.Firstname, person.Lastname, person.BirthDate.ToString("ddd, dd MMMM yyyy", CultureInfo.GetCultureInfo("en-en")));
            }
            table.Write();
            log.Info("Info listed");
        }
        public static void PrintEditPerson(Person person)
        {
            var table = new TableFramer("Id", "First name", "Last name", "Date of birth");
            table.AddRow("#" + person.Id, person.Firstname, person.Lastname, person.BirthDate.ToString("ddd, dd MMMM yyyy", CultureInfo.GetCultureInfo("en-en")));
            table.Write();
        }
        public static void PrintWholeId(IEnumerable<Person> persons)
        {
            Console.WriteLine("The whole list of Id:\n");
            var table = new TableFramer("Id");
            foreach (var person in persons)
            {
                table.AddRow("#" + person.Id);
            }
            table.Write();
        }
        public static void PrintImported(IEnumerable<Person> person)
        {
            var table = new TableFramer("Id", "First name", "Last name", "Date of birth");
            foreach (var p in person)
            {
                table.AddRow("#" + p.Id, p.Firstname, p.Lastname, p.BirthDate.ToString("ddd, dd MMMM yyyy", CultureInfo.GetCultureInfo("en-en")));
            }
            table.Write();
        }
    }
}
