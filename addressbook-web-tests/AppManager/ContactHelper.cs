using OpenQA.Selenium;
using System.Collections.Generic;

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
            manager.Contacts.FillContactForm(new ContactData(data.LastName, data.FirstName));
            manager.Contacts.SubmitContactForm();
            return this;
        }

        public ContactHelper Modify(int contactNumber, ContactData newData)
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

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{index + 1}]/td")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contactList = new List<ContactData>();
            manager.Navigator.GoToHomePage();

            ICollection<IWebElement> webContactElements = driver.FindElements(By.CssSelector("tr[name='entry']"));

            foreach (var element in webContactElements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                IWebElement lastName = cells[1];
                IWebElement firstName = cells[2];
                contactList.Add(new ContactData(lastName.Text, firstName.Text));
            }

            return contactList;
        }
        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));
            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{index + 1}]/td[8]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("lastname"), contactData.LastName);
            return this;
        }

        public void AddUntilContactIsPresent(int index)
        {
            while (!IsElementPresent(By.XPath($"//table[@id='maintable']/tbody/tr[{index + 1}]/td")))
            {
                Create(new ContactData("Automatic", "Creation"));
                manager.Navigator.GoToHomePage();
            }
        }
    }
}
