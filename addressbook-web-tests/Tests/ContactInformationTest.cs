using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation() 
        {
            int indexToVerify = 8;
            ContactData dataFromTable = app.Contacts.GetContactInformationFromTable(indexToVerify);
            ContactData dataFromEditForm = app.Contacts.GetContactInformationFromForm(indexToVerify);

            Assert.AreEqual(dataFromTable, dataFromEditForm);
            Assert.AreEqual(dataFromTable.Address, dataFromEditForm.Address);
            Assert.AreEqual(dataFromTable.AllPhones, dataFromEditForm.AllPhones);
            Assert.AreEqual(dataFromTable.AllEmails, dataFromEditForm.AllEmails);
        }

        [Test]
        public void TestContactDetails()
        {
            int indexToVerify = 8;
            ContactData dataFromTable = app.Contacts.GetContactInformationFromTable(indexToVerify);
            ContactData dataFromDetails = app.Contacts.GetContactInformationFromDetails(indexToVerify);

            Assert.AreEqual(dataFromTable, dataFromDetails);
            Assert.AreEqual(dataFromTable.Address, dataFromDetails.Address);
            Assert.AreEqual(dataFromTable.AllPhones, dataFromDetails.AllPhones);
            Assert.AreEqual(dataFromTable.AllEmails, dataFromDetails.AllEmails);

        }

    }
}
