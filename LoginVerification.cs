using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;

namespace LoginScreen0
{
    class LoginVerification
    {
        private string _CheckPath;
        public LoginVerification(string path)
        {
            _CheckPath = path;
        }
        public void Login(string usPw)
        {
            string textInfo = File.ReadAllText(_CheckPath);
            if (textInfo.Contains(usPw))
            {
                MessageBox.Show("Login Successful");
            }
            else
            {
                MessageBox.Show("you need to register for an account first");
            }
        }
    }
}

