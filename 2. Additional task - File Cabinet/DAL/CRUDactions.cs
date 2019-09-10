using System;
using System.Collections.Generic;
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
        public static object GetPersons(object obj, int identis)
        {
            var person = obj as Person;

            Console.WriteLine("Insert the first name of person");
            string firstname = Console.ReadLine();

            Console.WriteLine("Insert the last name");
            string lastname = Console.ReadLine();

            Console.WriteLine("Insert the date of birth");
            System.DateTime birthdate = Convert.ToDateTime(Console.ReadLine());

            person.Id = identis;
            person.Firstname = firstname;
            person.Lastname = lastname;
            person.BirthDate = birthdate;
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
            Console.WriteLine("Record like: \n");
            PrintMethods.PrintEditPerson(person);
            Console.WriteLine("Was created successfully!\n");
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

                    PrintMethods.PrintEditPerson(person);

                    MenuPanels.WriteInputNumberUpdateMenu();
                    int result = Convert.ToInt16(Console.ReadLine());
                    switch (result)
                    {
                        case 1:
                            {
                                Console.WriteLine("Insert another firstname:");
                                string anotherFirstname = Console.ReadLine();
                                persons[i].Firstname = anotherFirstname;
                                person.Firstname = anotherFirstname;
                                MenuPanels.WriteResultOfEditions();
                                PrintMethods.PrintEditPerson(person);
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Insert another lastname:");
                                string anotherLastname = Console.ReadLine();
                                persons[i].Lastname = anotherLastname;
                                person.Lastname = anotherLastname;
                                MenuPanels.WriteResultOfEditions();
                                PrintMethods.PrintEditPerson(person);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Insert another birth of date:");
                                DateTime anotherBirtdate = DateTime.Parse(Console.ReadLine());
                                persons[i].BirthDate = anotherBirtdate;
                                person.BirthDate = anotherBirtdate;
                                MenuPanels.WriteResultOfEditions();
                                PrintMethods.PrintEditPerson(person);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("There is no such case, insert case number, please:");
                                break;
                            }
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// Methods removes person record by Id
        /// </summary>
        /// <param name="persons"></param>
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
        }
        /// <summary>
        /// Methods cleans out all inf in database
        /// </summary>
        /// <param name="persons"></param>
        public static void Purge(IList<Person> persons)
        {
            Console.WriteLine("Purge");
            persons.Clear();
            Console.WriteLine("\nAll data in database was purged successfully!");
        }
    }
}
