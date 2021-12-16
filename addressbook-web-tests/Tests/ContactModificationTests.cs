using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Aaa", "Saaaav");
            appManager.Contacts.Modify(newData,1);
        }
    }
}
