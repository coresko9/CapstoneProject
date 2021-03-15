using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace LoginScreen0
{
    class StoreUserCredentials
    {
        private string _UserName;
        private string _Password;
        private string _FileName = "";
        private string _UserStoragePath;
        private string _Salt;
        private string _Hash;
        private int _HashLoopIterations;
        public StoreUserCredentials(string userName, string passWord)
        {
            if (FitsSizeCriteria(userName,passWord))
            {
                this._UserName = userName;
                this._Password = passWord;
                _HashLoopIterations = userName.Length * 50;
                _Salt = GenSalt();
                _Hash = CreateSHA512();
                _Hash = HashLoop();
                Store();
            }
            else
            {
                MessageBox.Show("User name needs to be at least 6 characters\nPassword needs to be at least 8 characters");
            }
        }
        public StoreUserCredentials(string userName, string passWord, bool isLoggingIn)
        {
                this._UserName = userName;
                this._Password = passWord;
                _HashLoopIterations = userName.Length * 50;
                _Salt = GenSalt();
                _Hash = CreateSHA512();
                _Hash = HashLoop();
        }
        public string Hash
        {
            get
            {
                return _Hash;
            }
        }
        public string UserStoragePath
        {
            get
            {
                return _UserStoragePath;
            }
        }
        private bool FitsSizeCriteria(string userName, string passWord)
        {
            if (userName.Length >5 && passWord.Length >7)
            {
                return true;
            }
            return false;
        }
        public string HashLoop()
        {
            for (int i = 0; i < _HashLoopIterations; i++)
            {
                _Hash = CreateSHA512(_Hash);
            }
            return _Hash;
        }
        private string GenSalt()
        {
         
            return $"{_Password}$$%1VtB0_--{_UserName}".Substring((_UserName.Length)/2,(($"{_UserName}{_Password}".Length)/2)+_Password.Length/2);
        }
        private string CreateSHA512(string hash = null)
        {
            using (SHA512 sHA512 = SHA512.Create())
            {
                byte[] inputBytes = hash == null ?  Encoding.ASCII.GetBytes($"{ _UserName}{_Password}{_Salt}") :  Encoding.ASCII.GetBytes($"{hash}{_Salt}");
                byte[] hashBytes = sHA512.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        private void Store()
        {
            this._FileName = @$"{_UserName}.txt";
            this._UserStoragePath = @$"{StorageDirectory.StorageString}\{_FileName}";
            
            if (File.Exists(_UserStoragePath))
            {
                MessageBox.Show("User name already taken...");
            }
            else
            {
                MessageBox.Show($"Saving to: {this._UserStoragePath}");
                using (StreamWriter registUser = new StreamWriter(this._UserStoragePath))
                {
                    registUser.WriteLine($"{_Hash}");
                    MessageBox.Show("Registered!");
                    registUser.Close();
                }
            }
           
        }
    }
}

