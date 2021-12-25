using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {

        private readonly string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) :
            base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == "http://localhost/addressbook/group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoToHomePage()
        {
            if (driver.Url == "http://localhost/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
