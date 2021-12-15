using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("234", "qwe", "456");
            appManager.Groups.Modify(1, group);
            appManager.Auth.Logout();
        }
    }
}
