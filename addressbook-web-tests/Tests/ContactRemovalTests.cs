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
            int indexToRemove = 7;
            app.Contacts.AddUntilContactIsPresent(indexToRemove);
            List <ContactData> oldList = app.Contacts.GetContactList();

            app.Contacts.Remove(indexToRemove);
            oldList.RemoveAt(indexToRemove - 1);

            List<ContactData> newList = app.Contacts.GetContactList();
            Assert.AreEqual(oldList, newList);

        }
    }
}
