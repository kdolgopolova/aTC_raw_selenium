using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
       
        [Test]
        public void GroupRemovalTest()
        {
            int indexToRemove = 1;
            app.Groups.AddUntilGroupIsPresent(indexToRemove);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData groupToRemove = oldGroups[indexToRemove];

            app.Groups.Remove(groupToRemove);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            oldGroups.RemoveAt(indexToRemove);

            List<GroupData> newGroups = GroupData.GetAll();

            Assert.AreEqual(oldGroups, newGroups);
            
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, groupToRemove.Id);
            }
        }
    }
}
