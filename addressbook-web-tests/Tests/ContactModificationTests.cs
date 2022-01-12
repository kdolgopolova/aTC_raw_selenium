using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Changed", "Automatically");
            int indexToModify = 4;
            app.Contacts.AddUntilContactIsPresent(indexToModify);

            List<ContactData> oldList = app.Contacts.GetContactList();

            app.Contacts.Modify(indexToModify, newData);

            List<ContactData> newList = app.Contacts.GetContactList();
            oldList[indexToModify-1].FirstName = newData.FirstName;
            oldList[indexToModify-1].LastName = newData.LastName;
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }
}
