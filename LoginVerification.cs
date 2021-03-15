using System.IO;
using System.Linq;
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
        public bool isLogin(string username, string password)
        {
            StoreUserCredentials checkAccount = new StoreUserCredentials(username,password, true);
            using (StreamReader stream = new StreamReader(_CheckPath))
            {

                string fileContent = stream.ReadToEnd();
                stream.Close();
                if (fileContent.Contains(checkAccount.Hash))
                {
                    MessageBox.Show("Login Successful");
                    UserProperties.Hash = checkAccount.Hash;
                    UserProperties.UserStorageFilePath = this._CheckPath;
                    UserProperties.Key = EncryptDecrypt.CreateKey(UserProperties.Hash);
                    return true;
                }
                return false;

            }
            
        }
    }
}
