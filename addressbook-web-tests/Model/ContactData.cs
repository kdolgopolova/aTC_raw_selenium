using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Linq;

namespace Addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string fullName;
        private string allData;
        private string fullNameNicknameBlock;
        private string titleCompanyAdddrBlock;
        private string phonesBlock;
        private string emailHomePageBlock;
        private string bdayAnniversaryBlock;
        private string secondaryBlock;

        public ContactData(string lastName, string firstName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public ContactData()
        {
        }

        public ContactData(string firstName, string middleName, string lastName, string company)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Company = company;
        }

        public ContactData(string lastName, string firstName, string middleName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }
        public string ADay { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string GetAge(string day, string month, string year, string fieldName)
        {
            if (day == null) return null;
            int userMonth;
            int Age;

            switch (month)
            {
                case "January":
                    userMonth = 1;
                    break;

                case "February":
                    userMonth = 2;
                    break;

                case "March":
                    userMonth = 3;
                    break;

                case "April":
                    userMonth = 4;
                    break;

                case "May":
                    userMonth = 5;
                    break;

                case "June":
                    userMonth = 6;
                    break;

                case "July":
                    userMonth = 7;
                    break;

                case "August":
                    userMonth = 8;
                    break;

                case "September":
                    userMonth = 9;
                    break;

                case "October":
                    userMonth = 10;
                    break;

                case "November":
                    userMonth = 11;
                    break;

                case "December":
                    userMonth = 12;
                    break;

                default:
                    userMonth = 0;
                    break;
            }

            if (year != "")
            {
                if ((DateTime.Now.Month >= userMonth) && (DateTime.Now.Day >= Int32.Parse(day)))
                    Age = DateTime.Now.Year - Int32.Parse(year);
                else
                    Age = DateTime.Now.Year - Int32.Parse(year) - 1;
            }
            else Age = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != "")
                {
                    return fieldName + FullDate + " (" + Age + ")";
                }
                else
                {
                    return fieldName + FullDate;
                }
            }
            else return "";
        }
        public string GetAnniversary(string day, string month, string year, string fieldName)
        {
            if (day == null) return null;
            int Anniversary;
            if (year != "")
                Anniversary = DateTime.Now.Year - Int32.Parse(year);
            else
                Anniversary = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != null && year != "")
                {
                    return fieldName + FullDate + " (" + Anniversary + ")";
                }
                else
                {
                    return fieldName + FullDate;
                }
            }
            else return "";
        }

        public string AllData
        {
            get
            {
                string fullNameBlock = FullNameNicknameblock;
                string titleBlock = TitleCompAddrBlock;
                string phoneBlock = PhonesBlock;
                string emailBlock = EmailHomepageBlock;
                string dateBlock = BirthAnnivBlock;
                string secondaryBlock = SecondaryBlock;
                string allDetails2 = "";



                if (allData != null)
                {
                    return allData = "";
                }
                else
                {
                    if (fullNameBlock != "")
                    {
                        allDetails2 = fullNameBlock;
                    }
                    if (titleBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNabove(titleBlock);
                        }
                        else
                        {
                            allDetails2 = titleBlock;
                        }
                    }
                    if (phoneBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(phoneBlock);
                        }
                        else
                        {
                            allDetails2 = phoneBlock;
                        }
                    }
                    if (emailBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(emailBlock);
                        }
                        else
                        {
                            allDetails2 = emailBlock;
                        }
                    }
                    if (dateBlock != null && dateBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(dateBlock);
                        }
                        else
                        {
                            allDetails2 = dateBlock;
                        }
                    }
                    else
                        if (secondaryBlock != "" && secondaryBlock != "P:")
                    {
                        allDetails2 += "\r\n";

                    }
                    if (secondaryBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(secondaryBlock);
                        }
                        else
                        {
                            allDetails2 = secondaryBlock;
                        }
                    }
                }
                return allDetails2.Trim();
            }
            set
            {
                allData = value;
            }
        }

        public string FullNameNicknameblock
        {
            get
            {
                if (fullNameNicknameBlock != null)
                {
                    return fullNameNicknameBlock;
                }
                else
                {
                    if (ReturnFullName(FirstName.Trim(), MiddleName.Trim(), LastName.Trim()) != "")
                    {
                        if (Nickname != "")
                        {
                            return (ReturnFullName(FirstName.Trim(), MiddleName.Trim(), LastName.Trim()) + "\r\n" + Nickname.Trim());
                        }
                        else
                        {
                            return ReturnFullName(FirstName.Trim(), MiddleName.Trim(), LastName.Trim());
                        }
                    }
                    else
                        return (ReturnDetailwithoutRN(Nickname));
                }
            }
            set
            {
                fullNameNicknameBlock = value;
            }
        }

        public string TitleCompAddrBlock
        {
            get
            {
                string titleCompAddrBlock = "";
                if (Title != null && Title != "")
                {
                    titleCompAddrBlock = Title.Trim();
                }
                if (Company != null && Company != "")
                {
                    if (titleCompAddrBlock != null && titleCompAddrBlock != "")
                    {
                        titleCompAddrBlock += "\r\n" + Company.Trim();
                    }
                    else
                    {
                        titleCompAddrBlock = Company.Trim();
                    }
                }
                if (Address != null && Address != "")
                {
                    if (titleCompAddrBlock != null && titleCompAddrBlock != "")
                    {
                        titleCompAddrBlock += "\r\n" + Address.Trim();
                    }
                    else
                    {
                        titleCompAddrBlock = Address.Trim();
                    }
                }
                return titleCompAddrBlock;
            }
            set
            {
                titleCompanyAdddrBlock = value;
            }
        }

        public string PhonesBlock
        {
            get
            {
                string phonesBlock = "";

                if (HomePhone != null && HomePhone != "")
                {
                    phonesBlock = ("H: " + HomePhone.Trim()).Trim();
                }
                if (MobilePhone != null && MobilePhone != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("M: " + MobilePhone.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("M: " + MobilePhone.Trim()).Trim();
                    }
                }
                if (WorkPhone != null && WorkPhone != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("W: " + WorkPhone.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("W: " + WorkPhone.Trim()).Trim();
                    }
                }
                if (Fax != null && Fax != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("F: " + Fax.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("F: " + Fax.Trim()).Trim();
                    }
                }
                return phonesBlock;
            }
            set
            {
                phonesBlock = value;
            }
        }

        public string EmailHomepageBlock
        {
            get
            {
                string emailHomepageBlock = "";

                if (Email != null && Email != "")
                {
                    emailHomepageBlock = Email;
                }
                if (Email2 != null && Email2 != "")
                {
                    if (emailHomepageBlock != null && emailHomepageBlock != "")
                    {
                        emailHomepageBlock = emailHomepageBlock.Trim() + "\r\n" + Email2.Trim();
                    }
                    else
                    {
                        emailHomepageBlock = Email2;
                    }
                }
                if (Email3 != null && Email3 != "")
                {
                    if (emailHomepageBlock != null && emailHomepageBlock != "")
                    {
                        emailHomepageBlock = emailHomepageBlock + "\r\n" + Email3.Trim();
                    }
                    else
                    {
                        emailHomepageBlock = Email3;
                    }
                }
                if (Homepage != null && Homepage != "")
                {
                    if (emailHomepageBlock != null && emailHomepageBlock != "")
                    {
                        emailHomepageBlock = emailHomepageBlock + "\r\n" + "Homepage:\r\n" + Homepage.Trim();
                    }
                    else
                    {
                        emailHomepageBlock = "Homepage:\r\n" + Homepage.Trim();
                    }
                }
                return emailHomepageBlock;
            }
            set
            {
                emailHomePageBlock = value;
            }
        }

        public string BirthAnnivBlock
        {
            get
            {
                string bithString = GetAge(BDay, BMonth, BYear, "Birthday ");
                string annivString = GetAnniversary(ADay, AMonth, AYear, "Anniversary ");
                string birthAnnivBlock = "";

                if (bithString != null && bithString != "")
                {
                    birthAnnivBlock = bithString.Trim();
                }
                if (annivString != null && annivString != "")
                {
                    if (birthAnnivBlock != null && birthAnnivBlock != "")
                    {
                        birthAnnivBlock += "\r\n" + annivString.Trim();
                    }
                    else
                    {
                        birthAnnivBlock = annivString.Trim();
                    }
                }
                return birthAnnivBlock;
            }
            set
            {
                bdayAnniversaryBlock = value;
            }
        }

        public string SecondaryBlock
        {
            get
            {
                if (Address2 == null) return null;
                string secondaryBlock = "";
                if (Address2.Trim() != null && Address2.Trim() != "")
                {
                    secondaryBlock = Address2.Trim();
                }
                if (Phone2 != null && Phone2 != "")
                {
                    if (secondaryBlock != null && secondaryBlock != "")
                    {
                        secondaryBlock += "\r\n\r\n" + ("P: " + Phone2.Trim()).Trim();
                    }
                    else
                    {
                        secondaryBlock = "\r\n" + ("P: " + Phone2.Trim()).Trim();
                    }
                }
                if (Notes.Trim() != null && Notes.Trim() != "")
                {
                    if (secondaryBlock != null && secondaryBlock != "")
                    {
                        secondaryBlock += "\r\n\r\n" + Notes.Trim();
                    }
                    else
                    {
                        secondaryBlock = Notes.Trim();
                    }
                }
                return secondaryBlock;
            }
            set
            {
                secondaryBlock = value;
            }

        }

        public string ReturnDetailwithRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }

        public string ReturnDetailwithoutRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text;
        }

        public string ReturnDetailwithRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n" + text;
        }

        public string ReturnDetailwithRNRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n\r\n" + text;
        }

        public string ReturnFullName(string name, string middlename, string lastname)
        {
            string FullName = "";
            if (name != null && name != "")
            {
                FullName = name;
            }
            if (middlename != null && middlename != "")
            {
                if (FullName != "")
                {
                    FullName += " " + middlename;
                }
                else
                {
                    FullName = middlename;
                }
            }
            if (lastname != null && lastname != "")
            {
                if (FullName != "")
                {
                    FullName += " " + lastname;
                }
                else
                {
                    FullName = lastname;
                }
            }

            return FullName;
        }


        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }

            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3)).Trim();
                }
            }

            set
            {
                allEmails = value;
            }
        }

        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return fullName;
                }
                else
                {
                    return Regex.Replace($"{FirstName} {MiddleName} {LastName}", @"\s+", "");
                }
            }

            set
            {
                fullName = value;
            }
        }

        private string CleanUp(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, "[ -()]", "") + "\r\n";
        }

        private string CleanUpEmails(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return data + "\r\n";
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
            return FirstName == contact.FirstName & LastName == contact.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return $"Last Name: {LastName}, First Name: {FirstName}";
        }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }
            string expected = $"{LastName} {FirstName}";
            string actual = $"{other.LastName} {other.FirstName}";
            return expected.CompareTo(actual);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            };
        }
    }
}
