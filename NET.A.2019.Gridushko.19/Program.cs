using System;
using System.Xml.Linq;
using System.Xml.Schema;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace NET.A._2019.Gridushko._19
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", @"C:\Users\User\source\repos\NET.A.2019\NET.A.2019.Gridushko.19\URL.xsd");

            XDocument doc = XDocument.Load(@"C:\Users\User\source\repos\NET.A.2019\NET.A.2019.Gridushko.19\Data.xml");

            bool validationErrors = false;

            doc.Validate(schema, (s, e) =>
                {
                    Console.WriteLine(e.Message);
                    validationErrors = true;
                });

            if (validationErrors)
            {
                log.Info("Validation failed!");
                Console.WriteLine("Validation failed");
            }
            else
            {
                Console.WriteLine("Validation Succeeded");
            }
        }
    }
}
