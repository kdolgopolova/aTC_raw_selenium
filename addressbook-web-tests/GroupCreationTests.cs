using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            CreateNewGroup();
            FillGroupForm(new GroupData("abc", "123", "cde"));
            SubmitGroupForm();
            ReturnToGroupsPage();
        }
    }
}
