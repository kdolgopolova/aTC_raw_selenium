using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.Navigator.GoToHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Navigator.GoToNewContactPage();
            appManager.Contacts.FillContactForm(new ContactData("Ksenia", "Dolgopolova"));
            appManager.Contacts.SubmitContactForm();
            appManager.Auth.Logout();
        }
    }
}
