using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation() 
        {
            int indexToVerify = 1;
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
            int indexToVerify = 0;
            ContactData dataFromEditForm = app.Contacts.GetContactInformationFromForm(indexToVerify);
            string dataFromDetails = app.Contacts.GetContactInformationFromDetails(indexToVerify);


            CollectionAssert.AreEqual(dataFromEditForm.AllData, dataFromDetails);

        }

    }
}
