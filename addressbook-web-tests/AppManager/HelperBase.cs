using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
            
        }
    }
}