using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int indexToRemove = 4;
            app.Contacts.AddUntilContactIsPresent(indexToRemove);

            List <ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData contactToRemove = oldContacts[indexToRemove];

            app.Contacts.Remove(indexToRemove);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            oldContacts.RemoveAt(indexToRemove);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, contactToRemove.Id);
            }
        }
    }
}
