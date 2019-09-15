using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace FileCabinet
{
    /// <summary>
    /// Presents methods to read csv and xml files
    /// </summary>
    class Readers
    {
        /// <summary>
        /// Reads csv
        /// </summary>
        /// <param name="filename"></param>
        public static void ReaderCsv(string filename)
        {
            string line;
            StreamReader file = null;
            try
            {
                file = new StreamReader(filename);
                IList<Person> person = new List<Person>();
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    string[] superLine = line.Split(',');

                    var element = new Person();

                    element.Id = int.Parse(superLine[0]);
                    element.FirstName = superLine[1];
                    element.LastName = superLine[2];
                    element.BirthDate = DateTime.Parse(superLine[3]);

                    person.Add(element);
                }

                PersonCollections.AlluserDatas = person;
                Printers.PrintImported(person);
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }
        /// <summary>
        /// Reads xml
        /// </summary>
        /// <param name="filename"></param>
        public static void ReaderXml(string filename)
        {
            string xml = File.ReadAllText(filename);
            List<Person> person = new List<Person>();
            var serializer = new XmlSerializer(person.GetType());

            using (TextReader reader = new StringReader(xml))
            {
                person = (List<Person>)serializer.Deserialize(reader);
            }
            PersonCollections.AlluserDatas = person;
            Printers.PrintImported(person);
        }
    }
}
