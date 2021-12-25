using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData(null, "OneTwoThree", "ChetirePyatShest");
            app.Groups.Modify(1, group);
        }
    }
}
