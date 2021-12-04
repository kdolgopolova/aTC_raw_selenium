namespace addressbook_web_tests
{
    class AccountData
    {

        private string username;
        private string password;

        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
    }
}
