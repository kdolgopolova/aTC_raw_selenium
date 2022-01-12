using System;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>
    {
        private string name;
        private string header;
        private string footer;

        public GroupData(string name)
        {
            this.name = name;
        }

        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }

        public bool Equals(GroupData group)
        {
            if (Object.ReferenceEquals(group, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, group))
            {
                return true;
            }
            return Name == group.Name;
        }

        public new int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public string Name { get => name; set => name = value; }
        public string Header { get => header; set => header = value; }
        public string Footer { get => footer; set => footer = value; }
    }


}
