using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
       
        [Test]
        public void TheGroupRemovalTest()
        {
            appManager.Navigator.GoToHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Groups
                .SelectGroup(1)
                .RemoveGroup()
                .ReturnToGroupsPage();
            appManager.Auth.Logout();
        }
    }
}
