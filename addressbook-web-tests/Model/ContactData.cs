using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string company;
        private string id;

        public ContactData(string lastName, string firstName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public ContactData(string firstName, string middleName, string lastName, string company)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.company = company;
        }

        public bool Equals(ContactData contact)
        {
            if (contact is null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, contact))
            {
                return true;
            }
            return firstName == contact.firstName & lastName == contact.lastName;
        }

        public override int GetHashCode()
        {
            return firstName.GetHashCode();
        }

        public override string ToString()
        {
            return $"Last Name: {lastName}, First Name: {firstName}";
        }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }
            string expected = $"{lastName} {firstName}";
            string actual = $"{other.lastName} {other.firstName}";
            return expected.CompareTo(actual);
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Company { get => company; set => company = value; }
        public string Id { get => id; set => id = value; }
    }
}
