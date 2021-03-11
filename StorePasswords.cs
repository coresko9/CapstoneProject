using System.IO;
using System.Windows;

namespace LoginScreen0
{
    class StorePasswords
    {
        public void Store(string websiteName, string userName, string passWord)
        {
            StreamWriter registUser = new StreamWriter(PasswordsScreen.File_StoragePath, true);
            if (string.IsNullOrWhiteSpace(websiteName) || websiteName.Contains(' ') ||
                string.IsNullOrWhiteSpace(userName) || userName.Contains(' ') ||
                string.IsNullOrWhiteSpace(passWord) || passWord.Contains(' '))
            {
                MessageBox.Show("Fields Cannot Be Empty or Contain a space");

            }
            else
            {
                if (File.Exists(PasswordsScreen.File_StoragePath))
                {

                    MessageBox.Show($"Saving to: {PasswordsScreen.File_StoragePath}");
                    registUser.WriteLine($"{websiteName} {userName} {passWord}");
                    MessageBox.Show("Credentials Saved!");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            registUser.Close();
        }
    }
}
