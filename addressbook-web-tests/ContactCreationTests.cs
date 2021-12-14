﻿using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToNewContactPage();
            FillContactForm(new ContactData("Ksenia", "Dolgopolova"));
            SubmitContactForm();
            Logout();
        }
    }
}
