using AdditionConsolPlusSQLTasks.DAL;
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
        /// Method implements split logic for incoming commands
        /// Enables to redirect implementaion of commands in next operation methods using switch operator
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MenuPanels.WriteInputGreeeting();

            while (true)
            {
                MenuPanels.WriteInputLine();
                MenuPanels.WriteInputCommandMainMenu();

                string[] commandsList = Console.ReadLine().Split(", ");

                foreach (string stringElement in commandsList)
                {
                    string resultCommand = OperationsSplit.SplitClean(stringElement).Replace("find ", "");
                    List<string> resultElements = resultCommand.Split(' ').Where(c => c != string.Empty).ToList();
                    var lastValue = resultElements.Last();

                    if (resultElements.Count() == 2 && lastValue != "csv" && lastValue != "xml" || resultElements.Count() == 3)
                    {
                        string[] arr = resultCommand.Trim().Split(null);//
                        arr = arr.Where((o, i) => i != arr.Length - 1).ToArray();
                        resultCommand = string.Join(" ", arr);
                    }

                    bool boolResult = ActionTypes.listcommands.Any(o => o.StartsWith(resultCommand));

                    if (true)
                    {
                        switch (resultCommand)
                        {
                            case "list":
                                {
                                    Printers.PrintPersons(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "list id":
                                {
                                    Printers.PrintWholeId(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "stat":
                                {
                                    OperationsExtra.Counter(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "firstname":
                                {
                                    OperationsCRUD.Firstname(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "lastname":
                                {
                                    OperationsCRUD.Lastname(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "create":
                                {
                                    OperationsCRUD.Create(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "edit":
                                {
                                    OperationsCRUD.Edit(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "remove":
                                {
                                    OperationsCRUD.Remove(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "purge":
                                {
                                    OperationsCRUD.Purge(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "export xml":
                                {
                                    OperationsExtra.ExportXML(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "export csv":
                                {
                                    OperationsExtra.ExportCSV(PersonCollections.AlluserDatas, lastValue);
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