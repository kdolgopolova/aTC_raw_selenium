using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace Addressbook_web_tests
{
    [TestFixture]
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovingContactFromGroup()
        {
            List<GroupData> groupList = GroupData.GetAll();
            List<ContactData> contactList = ContactData.GetAll();
            ContactData newContactData = new ContactData("AddedTo", $"AddingToGroup{R.Next(0, 100)}");
            GroupData newGroupData = new GroupData("Automatic Creation");

            // Checks if groups & contacts exist at all
            if (groupList.Count == 0)
            {
                app.Groups.Create(newGroupData);

                if (contactList.Count == 0)
                {
                    app.Contacts.Create(newContactData);
                    GroupData tempGroup = GroupData.GetAll()[0];
                    List<ContactData> tempOldData = tempGroup.GetContacts();
                    ContactData tempContact = ContactData.GetAll().Except(tempOldData).First();
                    app.Contacts.AddContactToGroup(tempContact, tempGroup);
                }
            }
            else 
            {
                if (contactList.Count == 0)
                {
                    app.Contacts.Create(newContactData);
                }

                GroupData tempGroup = GroupData.GetAll()[0];
                List<ContactData> tempOldData = tempGroup.GetContacts();

                // Checks if no Contacts are added to the group
                if (tempOldData.Count == 0)
                {
                    ContactData tempContact = ContactData.GetAll().Except(tempOldData).First();
                    app.Contacts.AddContactToGroup(tempContact, tempGroup);
                }
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldData = group.GetContacts();
            ContactData contact = GroupData.GetAll()[0].GetContacts().First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newData = group.GetContacts();
            oldData.Remove(contact);
            oldData.Sort();
            newData.Sort();

            Assert.AreEqual(oldData, newData);
        }
    }
}
