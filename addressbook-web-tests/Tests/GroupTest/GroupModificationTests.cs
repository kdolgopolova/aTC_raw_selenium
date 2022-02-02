using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData groupData = new GroupData("autocreation", "OneTwoThr", "ChetirePyatShest");
            int indexToModify = 6;

            app.Groups.AddUntilGroupIsPresent(indexToModify);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldGroupData = oldGroups[indexToModify-1];

            app.Groups.Modify(oldGroupData, groupData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
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
