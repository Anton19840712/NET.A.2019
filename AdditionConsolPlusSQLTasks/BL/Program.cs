using System;
using System.Collections.Generic;
using System.Linq;

namespace AdditionConsolPlusSQLTasks
{
    /// <summary>
    /// Initial class of application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method contains Ilist of initial records of catalog database.
        /// Consists of an entry point of application
        /// Implements split logic for incoming commands
        /// Enables to redirect implementaion of commands in next operation methods using switch operator
        /// </summary>
        /// <param name="args"></param>
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
                MenuPanels.WriteInputLine();
                MenuPanels.WriteInputCommandMainMenu();

                string[] commandsList = Console.ReadLine().Split(", ");// у нас есть сейчас список команд, введенных в консоль

                foreach (string stringElement in commandsList)
                {
                    string resultCommand = OperationsSplit.SplitClean(stringElement).Replace("find ", "");
                    List<string> resultElements = resultCommand.Split(' ').Where(c => c != string.Empty).ToList();//Рассплитил на элементы
                    var lastValue = resultElements.Last();//works, взял последний элемент

                    if (resultElements.Count() == 2 && lastValue != "csv" && lastValue != "xml" || resultElements.Count() == 3)
                    {
                        string[] arr = resultCommand.Trim().Split(null);//
                        arr = arr.Where((o, i) => i != arr.Length - 1).ToArray();
                        resultCommand = string.Join(" ", arr);// склеил в комманду
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


