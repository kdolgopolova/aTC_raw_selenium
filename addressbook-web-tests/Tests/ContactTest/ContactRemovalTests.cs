using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int indexToRemove = 1;
            app.Contacts.AddUntilContactIsPresent(indexToRemove);

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData contactToRemove = oldContacts[indexToRemove-1];

            app.Contacts.Remove(contactToRemove);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            oldContacts.Remove(contactToRemove);

            List<ContactData> newContacts = ContactData.GetAll();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, contactToRemove.Id);
            }
        }
    }
}
