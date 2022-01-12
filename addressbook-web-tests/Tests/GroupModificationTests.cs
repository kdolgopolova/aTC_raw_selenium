using NUnit.Framework;
using System.Collections.Generic;

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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.AddUntilGroupIsPresent(indexToModify);
            app.Groups.Modify(indexToModify, group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[indexToModify].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
