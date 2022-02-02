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
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovingContactFromGroup()
        {
            int indexGroupToRemoveFrom = 1;
            GroupData group = GroupData.GetAll()[indexGroupToRemoveFrom-1];
            List<ContactData> oldData = group.GetContacts();
            ContactData contact = GroupData.GetAll()[indexGroupToRemoveFrom-1].GetContacts().First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newData = group.GetContacts();
            oldData.Remove(contact);
            oldData.Sort();
            newData.Sort();
            Assert.AreEqual(oldData, newData);
        }
    }
}
