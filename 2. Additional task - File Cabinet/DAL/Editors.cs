using System;
using System.Collections.Generic;

namespace FileCabinet
{
    public class Editors
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Method changes firstname of person
        /// </summary>
        /// <param name="person"></param>
        /// <param name="persons"></param>
        /// <param name="i"></param>
        public static void AddFirstName(Person person, IList<Person> persons, int i)
        {
            Console.WriteLine("Insert another firstname:");
            string anotherFirstname = Console.ReadLine();
            persons[i].Firstname = anotherFirstname;
            person.Firstname = anotherFirstname;
            MenuPanels.WriteResultOfEditions();
            Printers.PrintEditPerson(person);
            log.Info("Firstname in #" + i++ + " was edited");
        }

        /// <summary>
        /// Method changes lastname of person
        /// </summary>
        /// <param name="person"></param>
        /// <param name="persons"></param>
        /// <param name="i"></param>
        public static void AddLastName(Person person, IList<Person> persons, int i)
        {
            Console.WriteLine("Insert another lastname:");
            string anotherLastname = Console.ReadLine();
            persons[i].Lastname = anotherLastname;
            person.Lastname = anotherLastname;
            MenuPanels.WriteResultOfEditions();
            Printers.PrintEditPerson(person);
            log.Info("Lastname in #" + i++ + " was edited");
        }
        /// <summary>
        /// Method changes birtdate of person
        /// </summary>
        /// <param name="person"></param>
        /// <param name="persons"></param>
        /// <param name="i"></param>
        public static void AddBirthDate(Person person, IList<Person> persons, int i)
        {
            Console.WriteLine("Insert another birth of date:");
            DateTime anotherBirtdate = DateTime.Parse(Console.ReadLine());
            persons[i].BirthDate = anotherBirtdate;
            person.BirthDate = anotherBirtdate;
            MenuPanels.WriteResultOfEditions();
            Printers.PrintEditPerson(person);
            log.Info("Birthdate in #" + i++ + " was edited");
        }
    }
}
