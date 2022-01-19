using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static Random r = new Random();

        public static string GenerateRandomString(int maxLength)
        {
            int length = Convert.ToInt32(r.NextDouble() * maxLength);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(Convert.ToChar(32 + Convert.ToInt32(r.NextDouble() * 223)));
            }
            return sb.ToString();
        }


        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
