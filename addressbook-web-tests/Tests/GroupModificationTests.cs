using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("autocreation", "OneTwoThr", "ChetirePyatShest");
            int indexToModify = 6;

            app.Groups.AddUntilGroupIsPresent(indexToModify);
            app.Groups.Modify(indexToModify, group);
        }
    }
}
