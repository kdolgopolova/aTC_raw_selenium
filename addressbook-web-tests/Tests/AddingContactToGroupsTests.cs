using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
namespace Addressbook_web_tests
{
    [TestFixture]
    public class AddingContactToGroupsTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup() 
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldData = group.GetContacts();
            ContactData contacts = ContactData.GetAll().Except(oldData).First();

            app.Contacts.AddContactToGroup(contacts, group);

            List<ContactData> newData = group.GetContacts();
            oldData.Add(contacts);
            oldData.Sort();
            newData.Sort();
            Assert.AreEqual(oldData, newData);
        }
    }
}
