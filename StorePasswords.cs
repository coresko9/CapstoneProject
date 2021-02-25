using System.IO;
using System.Windows;

namespace LoginScreen0
{
    class StorePasswords : StorageDirectory
    {
        private string _WebsiteName;
        private string _Website_UserName;
        private string _Website_Password;
        private static string _User;
        private static string _StoragePath = _StorageString;

        public StorePasswords(string user)
        {
            _User = user;
            _StoragePath = @$"{_StoragePath}\{_User}.txt";
        }
        public StorePasswords(string websiteName, string userName, string passWord)
        {
            StoreUserCredentials storeUser = new StoreUserCredentials();
            this._WebsiteName = websiteName;
            this._Website_UserName = userName;
            this._Website_Password = passWord;
            MessageBox.Show(@$"storing to : {_StoragePath}");
        }
        public void Store()
        {
            StreamWriter registUser = new StreamWriter(_StoragePath, true);

            if (!string.IsNullOrWhiteSpace(this._WebsiteName) || !string.IsNullOrWhiteSpace(this._Website_Password) || !string.IsNullOrWhiteSpace(this._Website_UserName))
            {
                if (File.Exists(_StoragePath))
                {
                    MessageBox.Show($"Saving to: {_StoragePath}");
                    registUser.WriteLine($"Website: {_WebsiteName}, User name: {_Website_UserName}, Password: {_Website_Password}");
                    MessageBox.Show("Credentials Saved!");
                    registUser.Close();
                }
                else
                {
                    MessageBox.Show("error");
                    registUser.Close();
                }
            }
            else
            {
                MessageBox.Show("Fields Cannot Be Empty");
            }
        }

    }
}
