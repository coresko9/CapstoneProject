using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace LoginScreen0
{
    class StoreUserCredentials : StorageDirectory
    {
        private string _UserName;
        private string _Password;
        private string _FileName = "";
        private string _UserStoragePath;

        public StoreUserCredentials()
        {

        }       
        public string UserStoragePath
        {
            get
            {
                return _UserStoragePath;
            }

        }
        public string CreateSHA512()
        {
            string toBeHash = _UserName + _Password;
            using (SHA512 sHA512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(toBeHash);
                byte[] hashBytes = sHA512.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public void Store(string userName,string passWord)
        {
            if (!string.IsNullOrWhiteSpace(userName) || !string.IsNullOrWhiteSpace(passWord))
            {
                this._UserName = userName;
                this._Password = passWord;
                this._FileName = @$"\{_UserName}.txt";
                this._UserStoragePath = $"{StorageDirectory._StorageString}{_FileName}";

                if (File.Exists(_UserStoragePath))
                {
                    MessageBox.Show("User name already taken...");
                }
                else
                {
                    MessageBox.Show($"Saving to: {this._UserStoragePath}");
                    string hash = CreateSHA512();
                    StreamWriter registUser = new StreamWriter(this._UserStoragePath);
                    registUser.WriteLine($"{hash}");
                    MessageBox.Show("Registered!");

                    registUser.Close();

                }
            }
            else { MessageBox.Show("No Fields Can Be Empty"); }
        }
    }
}

