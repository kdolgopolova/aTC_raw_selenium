using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandonContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), (GenerateRandomString(10))));
            }
            return contacts;
        }

        [Test, TestCaseSource("RandonContactDataProvider")]
        public void ContactCreationTest(ContactData newData)
        {
            List<ContactData> oldList = app.Contacts.GetContactList();

            app.Contacts.Create(newData);

            Assert.AreEqual(oldList.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newList = app.Contacts.GetContactList();
            oldList.Add(newData);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
