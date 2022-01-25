using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        private List<GroupData> groupCache = null;

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

        public int GetGroupCount()
        {
            manager.Navigator.GoToGroupsPage(); 
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();

                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

                foreach (var element in elements)
                {
                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else 
                    {
                        groupCache[i].Name = parts[i - shift].Trim();
                    }
                }
                
            }

            return new List<GroupData>(groupCache);
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
            groupCache = null;
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
            groupCache = null;
            driver.FindElement(By.CssSelector("div.msgbox"));
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
            groupCache = null;
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
