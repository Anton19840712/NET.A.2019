using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace FileCabinet
{
    /// <summary>
    /// Class contains basic CRUD logic
    /// </summary>
    public class CRUDactions
    {
        /// <summary>
        /// Method shows all records in table
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="identis"></param>
        /// <returns></returns>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static object GetPersons(object obj, int identis)
        {
            var person = obj as Person;
            Validators.CheckFirstNameAnnotation(person);
            Validators.CheckLastNameAnnotation(person);
            Validators.Asigning(identis, person);
            return person;
        }
        /// <summary>
        /// Method creates a person 
        /// </summary>
        /// <param name="persons"></param>
        public static void Create(IList<Person> persons)
        {
            var identis = (from t in persons select t.Id).Last() + 1;
            Person person = new Person();

            GetPersons(person, identis);
            persons.Add(new Person
            {
                Id = person.Id,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                BirthDate = person.BirthDate,
            });
            log.Info("Person was created!");
            Console.WriteLine("Record like: \n");
            Printers.PrintEditPerson(person);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Was created successfully!\n");
            Console.ResetColor();
        }
        /// <summary>
        /// Methods finds Firstname of Person
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="lastValue"></param>
        public static void Firstname(IEnumerable<Person> persons, string lastValue)
        {
            foreach (var person in persons)
            {
                if (person.Firstname == Convert.ToString(lastValue))
                {
                    Console.WriteLine("#" + person.Id);
                }
            }
        }
        /// <summary>
        /// Methods finds Lastname of Person
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="lastValue"></param>
        public static void Lastname(IEnumerable<Person> persons, string lastValue)
        {
            foreach (var person in persons)
            {
                if (person.Lastname == Convert.ToString(lastValue))
                {
                    Console.WriteLine("#" + person.Id);
                }
            }
        }
        /// <summary>
        /// Method edits Person information
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="lastValue"></param>
        public static void Edit(IList<Person> persons, string lastValue)
        {
            for (int i = persons.Count - 1; i >= 0; i--)
            {
                if (persons[i].Id == Convert.ToInt16(lastValue))
                {
                    Console.WriteLine("\nYou are going to update the record:");

                    var person = new Person { Id = persons[i].Id, Firstname = persons[i].Firstname, Lastname = persons[i].Lastname, BirthDate = persons[i].BirthDate };

                    Printers.PrintEditPerson(person);
                    MenuPanels.WriteInputNumberUpdateMenu();
                    DictionaryChoisPanels.EditioncommandChoose(person, persons, i);
                }
            }
        }
        /// <summary>
        /// Methods removes person record by Id
        /// </summary>
        /// <param name="persons"></param
        /// <param name="lastValue"></param>
        public static void Remove(IList<Person> persons, string lastValue)
        {
            for (int i = persons.Count - 1; i >= 0; i--)
            {
                if (persons[i].Id == Convert.ToInt16(lastValue))
                {
                    persons.RemoveAt(i);
                }
            }
            Console.WriteLine("\nRecord #{0} is removed", lastValue);
            log.Info("Person " + lastValue + " was removed");
        }
        /// <summary>
        /// Methods cleans out all inf in database
        /// </summary>
        /// <param name="persons"></param>
        public static void Purge(IList<Person> persons)
        {
            Console.WriteLine("Purge");
            persons.Clear();
            log.Info("Collection was purged");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAll data in database was purged successfully!");
            Console.ResetColor();
        }
    }
}
