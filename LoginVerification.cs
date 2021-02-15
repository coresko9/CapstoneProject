using System.IO;
using System.Security.Cryptography;
using System.Text;
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
        public bool isLogin(string usPw)
        {
            usPw = CreateSHA512(usPw);
            string textInfo = File.ReadAllText(_CheckPath);
            if (textInfo.Contains(usPw))
            {
                MessageBox.Show("Login Successful");
                return true;
            }

            return false;

        }
        public string CreateSHA512(string usPw)
        {
            using (SHA512 sHA512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(usPw);
                byte[] hashBytes = sHA512.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }

    }
}
