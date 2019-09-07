using System;
using System.Collections.Generic;
using System.Linq;

namespace AdditionConsolPlusSQLTasks
{
    public class OperationsCRUD
    {
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
            Printers.PrintEditPerson(ref person);
            Console.WriteLine("Was created successfully!\n");
        }
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
        public static void Edit(IList<Person> persons, string lastValue)
        {
            for (int i = persons.Count - 1; i >= 0; i--)
            {
                if (persons[i].Id == Convert.ToInt16(lastValue))
                {
                    Console.WriteLine("\nYou are going to update the record:");

                    var person = new Person { Id = persons[i].Id, Firstname = persons[i].Firstname, Lastname = persons[i].Lastname, BirthDate = persons[i].BirthDate };

                    Printers.PrintEditPerson(ref person);

                    MenuPanels.WriteInputNumberUpdateMenu();
                    int result = Convert.ToInt16(Console.ReadLine());
                    //int k = i;
                    switch (result)
                    {
                        case 1:
                            {
                                Console.WriteLine("Insert another firstname:");
                                string anotherFirstname = Console.ReadLine();
                                persons[i].Firstname = anotherFirstname;
                                Console.WriteLine("\nNew person info looks like:\n{0} {1} {2} {3}", persons[i].Id, persons[i].Firstname, persons[i].Lastname, persons[i].BirthDate);
                                //PrintEditPerson(ref person);
                                Console.WriteLine("and edited successfully!");
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Insert another lastname:");
                                string anotherLastname = Console.ReadLine();
                                persons[i].Lastname = anotherLastname;
                                Console.WriteLine("\nNew person info looks like:\n{0} {1} {2} {3}", persons[i].Id, persons[i].Firstname, persons[i].Lastname, persons[i].BirthDate);
                                Console.WriteLine("And edited successfully!");
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Insert another birth of date:");
                                DateTime anotherBirtdate = DateTime.Parse(Console.ReadLine());
                                persons[i].BirthDate = anotherBirtdate;
                                Console.WriteLine("\nNew person info looks like:\n{0} {1} {2} {3}", persons[i].Id, persons[i].Firstname, persons[i].Lastname, persons[i].BirthDate);
                                Console.WriteLine("And edited successfully!");
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
        public static void Purge(IList<Person> persons)
        {
            Console.WriteLine("Purge");
            persons.Clear();
            Console.WriteLine("\nAll data in database was purged successfully!");
        }
    }
}
