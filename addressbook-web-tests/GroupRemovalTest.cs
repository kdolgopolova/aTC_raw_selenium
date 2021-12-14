using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
       
        [Test]
        public void TheGroupRemovalTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();
            Logout();
        }
    }
}
