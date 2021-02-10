using System;
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

        //TODO - change the file path to something related to your 	

        private string _StorageString = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
        private string _StoragePath;
        private string _FileName = "";
        private static int _UserID = 0;
        public StoreUserCredentials(string user)
        {
            this._FileName = $"{user}.txt";

            this._StoragePath = $"{_StorageString}/{_FileName}";
            MessageBox.Show($"Saving to: {_StoragePath}");
            MessageBox.Show($"Saving to: {_StoragePath}");
        }
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        //test
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        public string StoragePath
        {
            get
            {
                return _StoragePath;
            }
        }
        public string CreateMD5()
        {
            string toBeHash = _UserName + _Password;
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(toBeHash);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public void Store()
        {
            if (!File.Exists(_StoragePath))
            {
                string hash = CreateMD5();
                _UserID++;
                string id = $"User {_UserID} : ";
                StreamWriter registUser = new StreamWriter(_StoragePath, true);
                registUser.WriteLine($"{id}{hash}");
                MessageBox.Show("Registered!");

                registUser.Close();


            }


        }

    }
}

