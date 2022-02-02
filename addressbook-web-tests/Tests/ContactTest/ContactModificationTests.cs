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
            ContactData contactData = new ContactData("Automatically", "Changed");
            int indexToModify = 1;

            app.Contacts.AddUntilContactIsPresent(indexToModify);

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContactData = oldContacts[indexToModify - 1];

            app.Contacts.Modify(indexToModify, contactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[indexToModify - 1].FirstName = contactData.FirstName;
            oldContacts[indexToModify - 1].LastName = contactData.LastName;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual($"{contactData.LastName} {contactData.FirstName}", $"{contact.LastName} {contact.FirstName}");
                }
            }
        }
    }
}
