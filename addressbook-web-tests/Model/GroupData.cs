using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Addressbook_web_tests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string name;
        private string header;
        private string footer;
        private string id;

        public GroupData(string name)
        {
            this.name = name;
        }

        public GroupData() { }
 
        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }

        public bool Equals(GroupData group)
        {
            if (group is null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, group))
            {
                return true;
            }
            return Name == group.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {Name}\nFooter: {Footer}\nHeader: {Header}";
        }

        public int CompareTo(GroupData other)
        {
            if (other is null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        [Column(Name = "group_name")]
        public string Name { get => name; set => name = value; }

        [Column(Name = "group_header")]
        public string Header { get => header; set => header = value; }

        [Column(Name = "group_footer")]
        public string Footer { get => footer; set => footer = value; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get => id; set => id = value; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            };
        }
        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == this.Id && p.ContactId == c.Id)
                        select c).Distinct().ToList();
            };
        }
    }
}
