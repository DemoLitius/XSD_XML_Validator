using System;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ConsoleApplication2
{
    class Program
    {
        private static string FilePath = @"C:\Users\Demo\Documents\Visual Studio 2015\Projects\XSD_XML_Validator\ConsoleApplication2\"; //  hardcoded path
        private static string XSDFile = "XSD_File.xsd";
        private static string XMLFile = "BookStore.xml";

        static void Main(string[] args)
        {
            Console.WriteLine("Validating XML file: \""+XMLFile+"\" against XSD file: \""+XSDFile+"\".\n");

            XmlSchemaSet XSD = new XmlSchemaSet();
            XSD.Add("", FilePath+XSDFile);

            XDocument XML = XDocument.Load(FilePath+XMLFile);

            bool ErrorOccurence = false;

            XML.Validate(XSD, (s,e)=>
            {
                Console.WriteLine("ERROR WAS FOUND HERE:\n"+s.ToString()+"\nERROR MESSAGE:\n"+e.Message+"END OF MESSAGE.\n");
                ErrorOccurence = true;
            });

            if (ErrorOccurence)
                Console.WriteLine("Validation Failed.");
            else
                Console.WriteLine("Validation Succeeded.");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
