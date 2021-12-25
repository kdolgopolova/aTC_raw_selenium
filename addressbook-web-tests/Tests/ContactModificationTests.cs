using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Aaa", "Saaaav");
            int indexToModify = 6;
            app.Contacts.AddUntilContactIsPresent(indexToModify);
            app.Contacts.Modify(indexToModify, newData);
        }
    }
}
