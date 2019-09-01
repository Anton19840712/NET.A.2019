using System;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
namespace AdditionConsolPlusSQLTasks
{

    [XmlRoot("person")]
    public class Person
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("Firstname")]
        public string Firstname { get; set; }

        [XmlElement("Lastname")]
        public string Lastname { get; set; }

        [XmlElement("BirthDate")]
        public DateTime BirthDate { get; set; }
    }
    class Program
    {
        internal static void PrintPersons(IEnumerable<Person> persons)
        {
            var table = new ConsoleTable("Id", "First name", "Last name", "Date of birth");
            foreach (var person in persons)
            {
                table.AddRow("#" + person.Id, person.Firstname, person.Lastname, person.BirthDate.ToString("ddd, dd MMMM yyyy"));
            }
            table.Write();
        }
        internal static void PrintEditPerson(ref Person person)
        {
            var table = new ConsoleTable("Id", "First name", "Last name", "Date of birth");
            table.AddRow("#" + person.Id, person.Firstname, person.Lastname, person.BirthDate.ToString("ddd, dd MMMM yyyy"));
            table.Write();
        }

        internal static void PrintSpecialPersons(ref Person person)
        {
            var table = new ConsoleTable("Id", "First name", "Last name", "Date of birth");
            table.AddRow("#" + person.Id, person.Firstname, person.Lastname, person.BirthDate.ToString("ddd, dd MMMM yyyy"));
            table.Write();
        }
        internal static void PrintOnePerson(ref Person person)
        {
            var table = new ConsoleTable("Id");
            table.AddRow("#" + person.Id);
            table.Write();
        }

        internal static void PrintWholeId(IEnumerable<Person> persons)
        {
            var table = new ConsoleTable("Id");
            foreach (var person in persons)
            {
                table.AddRow("#" + person.Id);
            }
            table.Write();
        }
        internal static void PrintWholeFirstNames(IEnumerable<Person> persons)
        {
            var table = new ConsoleTable("FirstNames");
            foreach (var person in persons)
            {
                table.AddRow(person.Firstname);
            }
            table.Write();
        }
        internal static void PrintWholeLastNames(IEnumerable<Person> persons)
        {
            var table = new ConsoleTable("LastNames");
            foreach (var person in persons)
            {
                table.AddRow(person.Lastname);
            }
            table.Write();

        }
        internal static void WriteInputGreeeting()
        {
            Console.WriteLine("WELCOME TO CATALOG EXPRESS\n         SYSTEM");
            Console.WriteLine("Choose your command to continue");
        }

        internal static void WriteInputLine()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(new string('.', 32));
            Console.ResetColor();
            Console.WriteLine();
        }
        internal static void WriteInputCommandMainMenu()
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

        public static string[] listcommands = new string[14]
        {
            "list id",
            "firstname",
            "lastname",
            "list",
            "stat",
            "find firstname ",
            "find lastname",
            "create",
            "edit",
            "remove",
            "purge",
            "export xml",
            "export csv",
            "exit"
        };
        internal static object GetPersons(object obj, int identis)
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

        internal static void WriteInputNumberUpdateMenu()
        {
            Console.WriteLine("\nInput the number of the field you want to change\n");
            Console.WriteLine("1 - Change firstname");
            Console.WriteLine("2 - Change lastname");
            Console.WriteLine("3 - Change date of birth");
        }

        static void Main(string[] args)
        {
            WriteInputGreeeting();

            IList<Person> persons = new List<Person>()
            {
                new Person(){ Id=1, Firstname="Bill", Lastname = "Bax", BirthDate = DateTime.Parse("10-10-2014")},
                new Person(){ Id=2, Firstname="Steve", Lastname = "Bethoven", BirthDate = DateTime.Parse("10-10-2015")},
                new Person(){ Id=3, Firstname="Ramzan", Lastname = "Ivanov", BirthDate = DateTime.Parse("12-10-2014")},
                new Person(){ Id=4, Firstname = "Anton", Lastname = "Ivanov", BirthDate = DateTime.Parse("10-12-2032")},
                new Person(){ Id=5, Firstname = "Anton", Lastname = "Petrov", BirthDate = DateTime.Parse("10-12-2032")}
            };

            while (true)
            {
                string command = null;

                WriteInputLine();
                WriteInputCommandMainMenu();

                command = Console.ReadLine();
                string[] commandsList = command.Split(", ");// у нас есть сейчас список команд, введенных в консоль
                //if (commandsList.Contains("list id", "firstname", "lastname"))
                //{

                //}
                foreach (string stringElement in commandsList)
                {

                    string preResultCommand = new string((from c in stringElement
                                                          where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                                          select c).ToArray()); // чистим команды от лишних вещей, чтобы далее было удобнее обрабатывать


                    string resultCommand = (preResultCommand.Replace("find ", ""));
                    List<string> resultElements = resultCommand.Split(' ').Where(c => c != string.Empty).ToList();//Рассплитил на элементы
                    List<string> fieldsElements = new List<string> { "list id", "firstname", "lastname" };
                    List<string> intersection = new List<string>(resultElements.Intersect(fieldsElements));

                    if (intersection.Any())
                    {

                    }

                    var lastValue = resultElements.Last();//works, взял последний элемент

                    if (resultElements.Count() == 2 && lastValue != "csv" && lastValue != "xml")
                    {
                        string[] arr = resultCommand.Trim().Split(null);//
                        arr = arr.Where((o, i) => i != arr.Length - 1).ToArray();
                        resultCommand = string.Join(" ", arr);// склеил в комманду
                    }

                    if (resultElements.Count() == 3)
                    {
                        string[] array = resultCommand.Trim().Split(null);//
                        array = array.Where((o, i) => i != array.Length - 1).ToArray();
                        resultCommand = string.Join(" ", array);// склеил в комманду
                    }

                    bool boolResult = listcommands.Any(o => o.StartsWith(resultCommand));

                    if (true)
                    {

                        switch (resultCommand)
                        {
                            case "list":
                                {
                                    Console.WriteLine("The whole list of persons\n");
                                    PrintPersons(persons);
                                    break;
                                }
                            case "list id":
                                {
                                    Console.WriteLine("The whole list of Id:\n");
                                    PrintWholeId(persons);
                                    break;
                                }
                            case "stat":
                                {
                                    var item = persons.Count();
                                    if (item > 1)
                                    {
                                        Console.WriteLine("\n{0} records", item);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n{0} record", item);
                                    }
                                    break;
                                }

                            case "firstname":

                                {
                                    foreach (var person in persons)
                                    {
                                        if (person.Firstname == Convert.ToString(lastValue))
                                        {
                                            Console.WriteLine("#" + person.Id);
                                        }
                                    }
                                    break;
                                }

                            case "lastname":
                                {
                                    foreach (var person in persons)
                                    {
                                        if (person.Lastname == Convert.ToString(lastValue))
                                        {
                                            Console.WriteLine("#" + person.Id);
                                        }
                                    }
                                    break;
                                }
                            case "create":
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
                                    PrintEditPerson(ref person);
                                    Console.WriteLine("Was created successfully!\n");
                                    break;
                                }
                            case "edit":
                                {

                                    for (int i = persons.Count - 1; i >= 0; i--)
                                    {
                                        if (persons[i].Id == Convert.ToInt16(lastValue))
                                        {
                                            Console.WriteLine("\nYou are going to update the record:");

                                            var person = new Person { Id = persons[i].Id, Firstname = persons[i].Firstname, Lastname = persons[i].Lastname, BirthDate = persons[i].BirthDate };

                                            PrintEditPerson(ref person);

                                            WriteInputNumberUpdateMenu();
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
                                                        Console.WriteLine("\nNew person info looks like:\n {0} {1} {2} {3}", persons[i].Id, persons[i].Firstname, persons[i].Lastname, persons[i].BirthDate);
                                                        Console.WriteLine("And edited successfully!");
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.WriteLine("Insert another birth of date:");
                                                        DateTime anotherBirtdate = DateTime.Parse(Console.ReadLine());
                                                        persons[i].BirthDate = anotherBirtdate;
                                                        Console.WriteLine("\nNew person info looks like:\n {0} {1} {2} {3}", persons[i].Id, persons[i].Firstname, persons[i].Lastname, persons[i].BirthDate);
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
                                    break;
                                }
                            case "remove":
                                {

                                    for (int i = persons.Count - 1; i >= 0; i--)
                                    {
                                        if (persons[i].Id == Convert.ToInt16(lastValue))
                                        {
                                            persons.RemoveAt(i);
                                        }
                                    }

                                    Console.WriteLine("\nRecord #{0} is removed", lastValue);
                                    break;
                                }
                            case "purge":
                                {
                                    Console.WriteLine("Purge");
                                    persons.Clear();
                                    Console.WriteLine("\nAll data in database was purged successfully!");
                                    break;
                                }
                            case "export xml":
                                {
                                    string resultValue;

                                    if (lastValue == "xml")
                                    {
                                        resultValue = "DefaultFileName";
                                    }

                                    else
                                    {
                                        resultValue = lastValue.Substring(0, lastValue.Length - 3);

                                    }

                                    string path = @"C:\\datafiles\" + resultValue + ".xml";
                                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                                    StreamWriter sw = new StreamWriter(path);
                                    xmlSerializer.Serialize(sw, persons);
                                    sw.Close();

                                    Console.WriteLine("\nFile xml by path {0} was created successfully!", path);
                                    break;
                                }
                            case "export csv":
                                {

                                    string resultValue;

                                    if (lastValue == "csv")
                                    {
                                        resultValue = "DefaultFileName";
                                    }

                                    else
                                    {
                                        resultValue = lastValue.Substring(0, lastValue.Length - 3);

                                    }

                                    string path = @"C:\\datafiles\" + resultValue + ".csv";
                                    using (StreamWriter streamReader = new StreamWriter(path))
                                    {
                                        using (CsvWriter csvReader = new CsvWriter(streamReader))
                                        {
                                            csvReader.Configuration.Delimiter = ",";
                                            csvReader.WriteRecords(persons);
                                        }
                                    }
                                    Console.WriteLine("\nFile csv by path {0} was created successfully!", path);
                                    break;
                                }
                            case "exit":
                                {
                                    Environment.Exit(0);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}


