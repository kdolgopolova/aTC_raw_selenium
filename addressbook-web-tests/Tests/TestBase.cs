using NUnit.Framework;
using OpenQA.Selenium;
using System.Text;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager appManager;

        [SetUp]
        public void SetupTest()
        {
            appManager = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Stop();
        }

    }
}
