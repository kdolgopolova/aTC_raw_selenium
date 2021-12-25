using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
       
        [Test]
        public void GroupRemovalTest()
        {
            int indexToRemove = 3;
            app.Groups.AddUntilGroupIsPresent(indexToRemove);
            app.Groups.Remove(indexToRemove);
        }
    }
}
