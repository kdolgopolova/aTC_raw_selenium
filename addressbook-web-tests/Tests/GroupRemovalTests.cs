using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
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

            app.Groups.Remove(indexToRemove);
            oldGroups.RemoveAt(indexToRemove);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups, newGroups);
  
        }
    }
}
