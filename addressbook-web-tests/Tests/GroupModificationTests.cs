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
            GroupData groupData = new GroupData("autocreation", "OneTwoThr", "ChetirePyatShest");
            int indexToModify = 6;

            app.Groups.AddUntilGroupIsPresent(indexToModify);
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldGroupData = oldGroups[indexToModify];

            app.Groups.Modify(indexToModify, groupData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[indexToModify].Name = groupData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (var group in newGroups)
            {
                if (group.Id == oldGroupData.Id)
                {
                    Assert.AreEqual(groupData.Name, group.Name);
                }
            }
        }
    }
}
