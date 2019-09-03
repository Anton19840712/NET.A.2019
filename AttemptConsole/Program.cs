using CsvHelper;
using AttemptConsole;
using AttemptConsole.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Labaowrk
{
  
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

   
        static void Main(string[] args)
        {
            Menu.WriteInputGreeeting();
            Menu.WriteInputLine();
            Menu.WriteInputCommandMainMenu();

            while (true)
            {
                string command = null;

                Menu.WriteInputLine();
                Menu.WriteInputCommandMainMenu();

                command = Console.ReadLine();
                string[] commandsList = command.Split(", ");// у нас есть сейчас список команд, введенных в консоль
               
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
                            //                case "list":
                            //                    {
                            //                        Console.WriteLine("The whole list of persons\n");
                            //                        PrintPersons(persons);
                            //                        break;
                            //                    }
                            //                case "list id":
                            //                    {
                            //                        Console.WriteLine("The whole list of Id:\n");
                            //                        PrintWholeId(persons);
                            //                        break;
                            //                    }
                            //                case "stat":
                            //                    {
                            //                        var item = persons.Count();
                            //                        if (item > 1)
                            //                        {
                            //                            Console.WriteLine("\n{0} records", item);
                            //                        }
                            //                        else
                            //                        {
                            //                            Console.WriteLine("\n{0} record", item);
                            //                        }
                            //                        break;
                            //                    }

                            //                case "firstname":

                            //                    {
                            //                        foreach (var person in persons)
                            //                        {
                            //                            if (person.Firstname == Convert.ToString(lastValue))
                            //                            {
                            //                                Console.WriteLine("#" + person.Id);
                            //                            }
                            //                        }
                            //                        break;
                            //                    }

                            //                case "lastname":
                            //                    {
                            //                        foreach (var person in persons)
                            //                        {
                            //                            if (person.Lastname == Convert.ToString(lastValue))
                            //                            {
                            //                                Console.WriteLine("#" + person.Id);
                            //                            }
                            //                        }
                            //                        break;
                            //                    }
                            //                case "create":
                            //                    {
                            //                        var identis = (from t in persons select t.Id).Last() + 1;
                            //                        Person person = new Person();
                            //                        GetPersons(person, identis);
                            //                        persons.Add(new Person
                            //                        {
                            //                            Id = person.Id,
                            //                            Firstname = person.Firstname,
                            //                            Lastname = person.Lastname,
                            //                            BirthDate = person.BirthDate,
                            //                        });
                            //                        Console.WriteLine("Record like: \n");
                            //                        PrintEditPerson(ref person);
                            //                        Console.WriteLine("Was created successfully!\n");
                            //                        break;
                            //                    }
                            //                case "edit":
                            //                    {

                            //                        for (int i = persons.Count - 1; i >= 0; i--)
                            //                        {
                            //                            if (persons[i].Id == Convert.ToInt16(lastValue))
                            //                            {
                            //                                Console.WriteLine("\nYou are going to update the record:");

                            //                                var person = new Person { Id = persons[i].Id, Firstname = persons[i].Firstname, Lastname = persons[i].Lastname, BirthDate = persons[i].BirthDate };

                            //                                PrintEditPerson(ref person);

                            //                                Menu.WriteInputNumberUpdateMenu();
                            //                                int result = Convert.ToInt16(Console.ReadLine());
                            //                                //int k = i;
                            //                                switch (result)
                            //                                {
                            //                                    case 1:
                            //                                        {
                            //                                            Console.WriteLine("Insert another firstname:");
                            //                                            string anotherFirstname = Console.ReadLine();
                            //                                            persons[i].Firstname = anotherFirstname;
                            //                                            Console.WriteLine("\nNew person info looks like:\n{0} {1} {2} {3}", persons[i].Id, persons[i].Firstname, persons[i].Lastname, persons[i].BirthDate);
                            //                                            //PrintEditPerson(ref person);
                            //                                            Console.WriteLine("and edited successfully!");
                            //                                            break;
                            //                                        }
                            //                                    case 2:
                            //                                        {
                            //                                            Console.WriteLine("Insert another lastname:");
                            //                                            string anotherLastname = Console.ReadLine();
                            //                                            persons[i].Lastname = anotherLastname;
                            //                                            Console.WriteLine("\nNew person info looks like:\n {0} {1} {2} {3}", persons[i].Id, persons[i].Firstname, persons[i].Lastname, persons[i].BirthDate);
                            //                                            Console.WriteLine("And edited successfully!");
                            //                                            break;
                            //                                        }
                            //                                    case 3:
                            //                                        {
                            //                                            Console.WriteLine("Insert another birth of date:");
                            //                                            DateTime anotherBirtdate = DateTime.Parse(Console.ReadLine());
                            //                                            persons[i].BirthDate = anotherBirtdate;
                            //                                            Console.WriteLine("\nNew person info looks like:\n {0} {1} {2} {3}", persons[i].Id, persons[i].Firstname, persons[i].Lastname, persons[i].BirthDate);
                            //                                            Console.WriteLine("And edited successfully!");
                            //                                            break;
                            //                                        }
                            //                                    default:
                            //                                        {
                            //                                            Console.WriteLine("There is no such case, insert case number, please:");
                            //                                            break;
                            //                                        }
                            //                                }
                            //                                break;
                            //                            }
                            //                        }
                            //                        break;
                            //                    }
                            //                case "remove":
                            //                    {

                            //                        for (int i = persons.Count - 1; i >= 0; i--)
                            //                        {
                            //                            if (persons[i].Id == Convert.ToInt16(lastValue))
                            //                            {
                            //                                persons.RemoveAt(i);
                            //                            }
                            //                        }

                            //                        Console.WriteLine("\nRecord #{0} is removed", lastValue);
                            //                        break;
                            //                    }
                            //                case "purge":
                            //                    {
                            //                        Console.WriteLine("Purge");
                            //                        persons.Clear();
                            //                        Console.WriteLine("\nAll data in database was purged successfully!");
                            //                        break;
                            //                    }
                            //                case "export xml":
                            //                    {
                            //                        string resultValue;

                            //                        if (lastValue == "xml")
                            //                        {
                            //                            resultValue = "DefaultFileName";
                            //                        }

                            //                        else
                            //                        {
                            //                            resultValue = lastValue.Substring(0, lastValue.Length - 3);

                            //                        }

                            //                        string path = @"C:\\datafiles\"+ resultValue + ".xml";
                            //                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                            //                        StreamWriter sw = new StreamWriter(path);
                            //                        xmlSerializer.Serialize(sw, persons);
                            //                        sw.Close();

                            //                        Console.WriteLine("\nFile xml by path {0} was created successfully!", path);
                            //                        break;
                            //                    }
                            //                case "export csv":
                            //                    {

                            //                        string resultValue;

                            //                        if (lastValue == "csv")
                            //                        {
                            //                            resultValue = "DefaultFileName";
                            //                        }

                            //                        else
                            //                        {
                            //                            resultValue = lastValue.Substring(0, lastValue.Length - 3);

                            //                        }

                            //                        string path = @"C:\\datafiles\" + resultValue + ".csv";
                            //                        using (StreamWriter streamReader = new StreamWriter(path))
                            //                        {
                            //                            using (CsvWriter csvReader = new CsvWriter(streamReader))
                            //                            {
                            //                                csvReader.Configuration.Delimiter = ",";
                            //                                csvReader.WriteRecords(persons);
                            //                            }
                            //                        }
                            //                        Console.WriteLine("\nFile csv by path {0} was created successfully!", path);
                            //                        break;
                            //                    }
                            case "exit":
                                {
                                    FileRepository.Exit();
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


