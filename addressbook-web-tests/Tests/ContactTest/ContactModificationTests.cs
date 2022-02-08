using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Automatically", "Changed");
            int indexToModify = 1;

            app.Contacts.AddUntilContactIsPresent(indexToModify);

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContactData = oldContacts[indexToModify - 1];

            app.Contacts.Modify(oldContactData, newContactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[indexToModify - 1].FirstName = newContactData.FirstName;
            oldContacts[indexToModify - 1].LastName = newContactData.LastName;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual($"{newContactData.LastName} {newContactData.FirstName}", $"{contact.LastName} {contact.FirstName}");
                }
            }
        }
    }
}
