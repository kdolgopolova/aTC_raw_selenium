using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class LogInTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AccountData accountData = new AccountData("admin", "secret");
            app.Auth.Logout();

            app.Auth.Login(accountData);

            Assert.IsTrue(app.Auth.IsLoggedIn(accountData));

        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            AccountData accountData = new AccountData("admin", "superSecret");
            app.Auth.Logout();

            app.Auth.Login(accountData);

            Assert.IsFalse(app.Auth.IsLoggedIn(accountData));

        }
    }
}
