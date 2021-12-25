using NUnit.Framework;

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
            app.Contacts.Remove(indexToRemove);
        }
    }
}
