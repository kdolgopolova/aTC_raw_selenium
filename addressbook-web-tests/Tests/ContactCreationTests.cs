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
            ContactData newData = new ContactData("Maksimov", "Maksim");
            List<ContactData> oldList = app.Contacts.GetContactList();

            app.Contacts.Create(newData);
            List<ContactData> newList = app.Contacts.GetContactList();
            oldList.Add(newData);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData newData = new ContactData("", "");
            List<ContactData> oldList = app.Contacts.GetContactList();

            app.Contacts.Create(newData);
            List<ContactData> newList = app.Contacts.GetContactList();
            oldList.Add(newData);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
