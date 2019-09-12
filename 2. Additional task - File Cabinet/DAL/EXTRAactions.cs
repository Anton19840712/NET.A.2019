using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using CsvHelper;
using System.Windows.Forms;
using FileCabinet;

namespace FileCabinet
{
    /// <summary>
    /// Additional application commands that are not CRUD operations
    /// </summary>
    public class EXTRAactions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            log.Info("Count operation");
        }
        /// <summary>
        /// Exit application
        /// </summary>
        public static void LeaveEnvironment()
        {
            log.Info("Application exit");
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
            log.Info("Info csv exported");
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
            log.Info("Info xml exported");
            Console.WriteLine("\nFile xml by path {0} was created successfully!", path);
        }
        /// <summary>
        /// Imports from XML to Console
        /// </summary>
        public static void ImportXML()
        {
            string filename = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open CSV File";
            dialog.Filter = "XML Files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filename = dialog.FileName;

                if (File.Exists(filename))
                {
                    Readers.ReaderXml(filename);
                }
            }
            log.Info("Info xml imported");
        }
        /// <summary>
        /// Imports from csv to Console
        /// </summary>
        public static void ImportCSV()
        {
            try
            {
                string filename = "";
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Open CSV File";
                dialog.Filter = "CSV Files (*.csv)|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filename = dialog.FileName;

                    if (File.Exists(filename))
                    {
                        Readers.ReaderCsv(filename);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
            log.Info("Info csv imported");
        }
    }
}
