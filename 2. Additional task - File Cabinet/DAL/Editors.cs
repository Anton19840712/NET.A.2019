using System;
using System.Collections.Generic;
using System.Globalization;

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
            Validators.CheckFirstNameAnnotation(person);
            MenuPanels.WriteResultOfEditions();
            Printers.PrintEditPerson(person);
            log.Info("FirstName in #" + i++ + " was edited");
        }

        /// <summary>
        /// Method changes lastname of person
        /// </summary>
        /// <param name="person"></param>
        /// <param name="persons"></param>
        /// <param name="i"></param>
        public static void AddLastName(Person person, IList<Person> persons, int i)
        {
            Validators.CheckLastNameAnnotation(person);
            MenuPanels.WriteResultOfEditions();
            Printers.PrintEditPerson(person);
            log.Info("LastName in #" + i++ + " was edited");
        }
        /// <summary>
        /// Method changes birtdate of person
        /// </summary>
        /// <param name="person"></param>
        /// <param name="persons"></param>
        /// <param name="i"></param>
        public static void AddBirthDate(Person person, IList<Person> persons, int i)
        {
            Validators.Asigning(i, person);
            MenuPanels.WriteResultOfEditions();
            Printers.PrintEditPerson(person);
            log.Info("Birthdate in #" + i++ + " was edited");
        }
    }
}
