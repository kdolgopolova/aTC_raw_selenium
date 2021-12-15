using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
       
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Groups.Remove(1);
        }
    }
}
