namespace addressbook_web_tests
{
    class Figure
    {
        private bool isColoured = false;

        public bool IsColoured
        {
            get
            {
                return isColoured;
            }

            set
            {
                isColoured = value;
            }
        }
    }
}
