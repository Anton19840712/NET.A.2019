using System;
using System.Collections.Generic;
using System.Linq;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace FileCabinet
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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [STAThread]
        static void Main(string[] args)
        {
            log.Info("Application was started!");
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
                        Dictionary<string, Action> dict = new Dictionary<string, Action>
                        {
                            ["list"] = () => PrintMethods.PrintPersons(PersonCollections.AlluserDatas),
                            ["list id"] = () => PrintMethods.PrintWholeId(PersonCollections.AlluserDatas),
                            ["firstname"] = () => CRUDactions.Firstname(PersonCollections.AlluserDatas, lastValue),
                            ["lastname"] = () => CRUDactions.Lastname(PersonCollections.AlluserDatas, lastValue),
                            ["create"] = () => CRUDactions.Create(PersonCollections.AlluserDatas),
                            ["edit"] = () => CRUDactions.Edit(PersonCollections.AlluserDatas, lastValue),
                            ["remove"] = () => CRUDactions.Remove(PersonCollections.AlluserDatas, lastValue),
                            ["purge"] = () => CRUDactions.Purge(PersonCollections.AlluserDatas),
                            ["export xml"] = () => EXTRAactions.ExportXML(PersonCollections.AlluserDatas, lastValue),
                            ["export csv"] = () => EXTRAactions.ExportCSV(PersonCollections.AlluserDatas, lastValue),
                            ["import xml"] = () => EXTRAactions.ImportXML(),
                            ["import csv"] = () => EXTRAactions.ImportCSV(),
                            ["exit"] = () => EXTRAactions.LeaveEnvironment(),
                            ["stat"] = () => EXTRAactions.Counter(PersonCollections.AlluserDatas),
                        };

                        if (dict.TryGetValue(resultCommand, out Action act))
                            act();
                    }
                }
            }
        }
    }
}

