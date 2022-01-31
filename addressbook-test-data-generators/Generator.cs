using Addressbook_web_tests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Generator
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]); 
            string fileName = args[2];
            string format = args[3];

            if (dataType == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10),
                    });
                }
                if (format == "excel")
                {
                    WriteGroupsToExcelFile(groups, fileName);
                }
                else 
                {
                    StreamWriter writer = new StreamWriter(fileName);

                    switch (format)
                    {
                        case "csv":
                            WriteGroupsToCsvFile(groups, writer);
                            break;
                        case "xml":
                            WriteGroupsToXMLFile(groups, writer);
                            break;
                        case "json":
                            WriteGroupsToJsonFile(groups, writer);
                            break;
                        default:
                            Console.Out.Write($"Unrecognized format {format}");
                            break;
                    }
                    writer.Close();
                }
            }

            else if (dataType == "contacts")
            {
                StreamWriter writer = new StreamWriter(fileName);
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(5), TestBase.GenerateRandomString(5))
                    {
                        MiddleName = TestBase.GenerateRandomString(5),
                        Address = TestBase.GenerateRandomString(5),
                        MobilePhone = TestBase.GenerateRandomString(5),
                        Nickname = TestBase.GenerateRandomString(5)
                    });
                }

                switch (format)
                {
                    case "xml":
                        WriteContactsToXmlFile(contacts, writer);
                        break;
                    case "json":
                        WriteContactsToJsonile(contacts, writer);
                        break;
                    default:
                        Console.Out.Write($"Unrecognized format {format}");
                        break;
                }
                    writer.Close();
            }
            else
            {
                Console.Out.Write($"Unrecognized dataType {dataType}");
            }
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer) 
        { 
            foreach(var group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer));
            }
        }
        static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer) 
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void WriteContactsToJsonile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }


        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            sheet.Cells[1, 1] = "test";

            int row = 1;
            foreach(GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), filename));
            wb.Close();
            app.Visible = false;
            app.Quit();
        }
    }
}
