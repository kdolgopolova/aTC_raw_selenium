using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData newData = new ContactData("Ivan", "Petrov");
            app.Contacts.Create(newData);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData newData = new ContactData("", "");
            app.Contacts.Create(newData);
        }
    }
}
