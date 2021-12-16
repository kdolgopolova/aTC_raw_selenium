using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) :
            base(manager)
        {
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper Create(ContactData data)
        {
            manager.Navigator.GoToNewContactPage();
            manager.Contacts.FillContactForm(new ContactData(data.FirstName, data.LastName));
            manager.Contacts.SubmitContactForm();
            return this;
        }

        public ContactHelper Modify(ContactData newData, int contactNumber)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(contactNumber);
            FillContactForm(newData);
            UpdateContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int a)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(a);
            RemoveContact();
            return this;
        }

        private ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper SelectContact(int a)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{a + 1}]/td")).Click();
            return this;
        }
        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContactHelper InitContactModification(int a)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{a + 1}]/td[8]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contactData)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactData.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactData.LastName);
            return this;
        }
    }
}
