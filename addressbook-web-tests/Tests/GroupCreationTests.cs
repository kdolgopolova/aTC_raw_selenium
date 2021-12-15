using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.Navigator.GoToHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Navigator.GoToGroupsPage();
            appManager.Groups
                .CreateNewGroup()
                .FillGroupForm(new GroupData("abc", "123", "cde"))
                .SubmitGroupForm()
                .ReturnToGroupsPage();
        }
    }
}
