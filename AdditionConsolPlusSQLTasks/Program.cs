using System;
using System.Collections.Generic;
using System.Linq;

namespace AdditionConsolPlusSQLTasks
{   
    class Program
    {
         static void Main(string[] args)
        {
            MenuPanels.WriteInputGreeeting();

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

                MenuPanels.WriteInputLine();
                MenuPanels.WriteInputCommandMainMenu();

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

                    bool boolResult = ActionTypes.listcommands.Any(o => o.StartsWith(resultCommand));

                    if (true)
                    {
                        switch (resultCommand)
                        {
                            case "list":
                                {
                                    Printers.PrintPersons(persons);
                                    break;
                                }
                            case "list id":
                                {
                                    Printers.PrintWholeId(persons);
                                    break;
                                }
                            case "stat":
                                {
                                    OperationsExtra.Counter(persons);
                                    break;
                                }
                            case "firstname":
                                {
                                    OperationsCRUD.Firstname(persons, lastValue);
                                    break;
                                }
                            case "lastname":
                                {
                                    OperationsCRUD.Lastname(persons, lastValue);
                                    break;
                                }
                            case "create":
                                {
                                    OperationsCRUD.Create(persons);
                                    break;
                                }
                            case "edit":
                                {
                                    OperationsCRUD.Edit(persons, lastValue);
                                    break;
                                }
                            case "remove":
                                {
                                    OperationsCRUD.Remove(persons, lastValue);
                                    break;
                                }
                            case "purge":
                                {
                                    OperationsCRUD.Purge(persons);
                                    break;
                                }
                            case "export xml":
                                {
                                    OperationsExtra.ExportXML(persons, lastValue);
                                    break;
                                }
                            case "export csv":
                                {
                                    OperationsExtra.ExportCSV(persons, lastValue);
                                    break;
                                }
                            case "exit":
                                {
                                    OperationsExtra.LeaveEnvironment();
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


