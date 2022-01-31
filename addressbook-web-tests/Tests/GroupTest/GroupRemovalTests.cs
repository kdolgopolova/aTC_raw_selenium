using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
       
        [Test]
        public void GroupRemovalTest()
        {
            int indexToRemove = 7;
            app.Groups.AddUntilGroupIsPresent(indexToRemove);

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData groupToRemove = oldGroups[indexToRemove];

            app.Groups.Remove(indexToRemove);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            oldGroups.RemoveAt(indexToRemove);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            Assert.AreEqual(oldGroups, newGroups);
            
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, groupToRemove.Id);
            }
        }
    }
}
