using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) :
            base(manager)
        {

        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            CreateNewGroup();
            FillGroupForm(group);
            SubmitGroupForm();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();

            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> webGroupElements = driver.FindElements(By.CssSelector("span.group"));

            foreach (var element in webGroupElements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;
        }

        internal GroupHelper Modify(int a, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(a);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Remove(int a)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(a);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SubmitGroupForm()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.Name);
            Type(By.Name("group_header"), groupData.Header);
            Type(By.Name("group_footer"), groupData.Footer);
            return this;
        }

        public GroupHelper CreateNewGroup()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath($"//div[@id='content']/form/span[{index + 1}]/input")).Click();
            return this;
        }
        
        public void AddUntilGroupIsPresent(int index)
        {
            while (!IsElementPresent(By.XPath($"//div[@id='content']/form/span[{index + 1}]/input")))
            {
                Create(new GroupData(""));
            }
        }
    }
}
