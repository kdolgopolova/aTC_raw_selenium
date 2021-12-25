using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Management.Instrumentation;
using System.Text;
using System.Threading;

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
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

         ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public LoginHelper Auth { get => loginHelper; set => loginHelper = value; }
        public NavigationHelper Navigator { get => navigationHelper; set => navigationHelper = value; }
        public GroupHelper Groups { get => groupHelper; set => groupHelper = value; }
        public ContactHelper Contacts { get => contactHelper; set => contactHelper = value; }
        public IWebDriver Driver { get => driver; set => driver = value; }
    }
}
