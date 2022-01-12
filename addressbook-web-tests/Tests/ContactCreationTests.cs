using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData newData = new ContactData("Ivan", "Petrov");
            List<ContactData> oldList = app.Contacts.GetContactList();

            app.Contacts.Create(newData);
            List<ContactData> newList = app.Contacts.GetContactList();

            Assert.AreEqual(oldList.Count, newList.Count - 1);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData newData = new ContactData("", "");
            List<ContactData> oldList = app.Contacts.GetContactList();

            app.Contacts.Create(newData);
            List<ContactData> newList = app.Contacts.GetContactList();

            Assert.AreEqual(oldList.Count, newList.Count - 1);
        }
    }
}
