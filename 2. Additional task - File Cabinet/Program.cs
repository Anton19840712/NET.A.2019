using FileCabinet;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp1
{
    /// <summary>
    /// Initial class of application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Method implements split logic for incoming commands
        /// Enables to redirect implementaion of commands in next operation methods using switch operator
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {


            MenuPanels.WriteInputGreeeting();

            while (true)
            {
                MenuPanels.WriteInputLine();
                MenuPanels.WriteInputCommandMainMenu();

                string[] commandsList = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);

                foreach (string stringElement in commandsList)
                {
                    string resultCommand = OperationsSplit.SplitClean(stringElement).Replace("find ", "");
                    List<string> resultElements = resultCommand.Split(' ').Where(c => c != string.Empty).ToList();
                    var lastValue = resultElements.Last();

                    if (resultElements.Count() == 2 && lastValue != "csv" && lastValue != "xml" || resultElements.Count() == 3)
                    {
                        string[] arr = resultCommand.Trim().Split(null);
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
                                    PrintMethods.PrintPersons(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "list id":
                                {
                                    PrintMethods.PrintWholeId(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "stat":
                                {
                                    EXTRAactions.Counter(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "firstname":
                                {
                                    CRUDactions.Firstname(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "lastname":
                                {
                                    CRUDactions.Lastname(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "create":
                                {
                                    CRUDactions.Create(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "edit":
                                {
                                    CRUDactions.Edit(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "remove":
                                {
                                    CRUDactions.Remove(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "purge":
                                {
                                    CRUDactions.Purge(PersonCollections.AlluserDatas);
                                    break;
                                }
                            case "export xml":
                                {
                                    EXTRAactions.ExportXML(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "export csv":
                                {
                                    EXTRAactions.ExportCSV(PersonCollections.AlluserDatas, lastValue);
                                    break;
                                }
                            case "import xml":
                                {
                                    EXTRAactions.ImportXML();
                                    break;
                                }
                            case "import csv":
                                {
                                    EXTRAactions.ImportCSV();
                                    break;
                                }
                            case "exit":
                                {
                                    EXTRAactions.LeaveEnvironment();
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

