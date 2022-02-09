using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Addressbook_web_tests
{
    [TestFixture]
    public class AddingContactToGroupsTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groupList = GroupData.GetAll();
            List<ContactData> contactList = ContactData.GetAll();
            ContactData newContactData = new ContactData("AddedTo", $"AddingToGroup{R.Next(0,100)}");
            GroupData newGroupData = new GroupData("Automatic Creation");

            // Checks if groups & contacts exist at all
            if (groupList.Count == 0)
            {
                app.Groups.Create(newGroupData);

                if (contactList.Count == 0)
                {
                    app.Contacts.Create(newContactData);
                }
            }
            if (contactList.Count == 0)
            {
                app.Contacts.Create(newContactData);
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldData = group.GetContacts();

            if (oldData.SequenceEqual(ContactData.GetAll()))
            {
                app.Contacts.Create(newContactData);
            }

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
