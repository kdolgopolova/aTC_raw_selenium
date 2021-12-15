using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        protected string baseURL;

        private LoginHelper loginHelper;
        private NavigationHelper navigationHelper;
        private GroupHelper groupHelper;
        private ContactHelper contactHelper;
        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper Auth { get => loginHelper; set => loginHelper = value; }
        public NavigationHelper Navigator { get => navigationHelper; set => navigationHelper = value; }
        public GroupHelper Groups { get => groupHelper; set => groupHelper = value; }
        public ContactHelper Contacts { get => contactHelper; set => contactHelper = value; }
        public IWebDriver Driver { get => driver; set => driver = value; }
    }
}
