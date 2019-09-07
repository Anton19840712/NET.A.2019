using System;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace AdditionConsolPlusSQLTasks
{
    /// <summary>
    /// Additional application commands that are not CRUD operations
    /// </summary>
    public class OperationsExtra
    {
        /// <summary>
        /// Counts records in database
        /// </summary>
        /// <param name="persons"></param>
        public static void Counter(ICollection<Person> persons)
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
        }
        /// <summary>
        /// Exit application
        /// </summary>
        public static void LeaveEnvironment()
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Exports database info in CSV format
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="lastValue"></param>
        public static void ExportCSV(IList<Person> persons, string lastValue)
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
        }
        /// <summary>
        /// Exports database info in XML format
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="lastValue"></param>
        public static void ExportXML(IList<Person> persons, string lastValue)
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
        }
    }
}
