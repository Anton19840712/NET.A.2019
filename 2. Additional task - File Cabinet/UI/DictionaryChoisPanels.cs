using System;
using System.Collections.Generic;

namespace FileCabinet
{
    /// <summary>
    /// Logic to identify and choose command equivalently inserted value
    /// </summary>
    public class DictionaryChoisPanels
    {
        /// <summary>
        /// Enables to choose command from a listcommand and to implement action accordingly
        /// </summary>
        /// <param name="lastValue"></param>
        /// <param name="resultCommand"></param>
        public static void Maincommandchoose(string lastValue, string resultCommand)
        {
            Dictionary<string, Action> dict = new Dictionary<string, Action>
            {
                ["list"] = () => Printers.PrintPersons(PersonCollections.AlluserDatas),
                ["list id"] = () => Printers.PrintWholeId(PersonCollections.AlluserDatas),
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

        /// <summary>
        /// Method to choose action to change fname, lname or datebirth
        /// according to the input value
        /// </summary>
        /// <param name="person"></param>
        /// <param name="persons"></param>
        /// <param name="i"></param>
        public static void EditioncommandChoose(Person person, IList<Person> persons, int i)
        {
            string result = Console.ReadLine();

            if (result == "1" || result == "2" || result == "3")
            {
                Dictionary<string, Action> dict = new Dictionary<string, Action>
                {
                    ["1"] = () => Editors.AddFirstName(person, persons, i),
                    ["2"] = () => Editors.AddLastName(person, persons, i),
                    ["3"] = () => Editors.AddBirthDate(person, persons, i),
                };

                if (dict.TryGetValue(result, out Action act))
                    act();
            }
        }
    }
}
