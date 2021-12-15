using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData newData = new ContactData("Ivan", "Petrov");
            appManager.Contacts.Create(newData);
            appManager.Auth.Logout();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData newData = new ContactData("", "");
            appManager.Contacts.Create(newData);
            appManager.Auth.Logout();
        }
    }
}
