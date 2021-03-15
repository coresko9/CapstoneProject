using System.IO;
using System.Windows;

namespace LoginScreen0
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   

            InitializeComponent();
            if (!Directory.Exists(StorageDirectory.StorageString))
            {
                StorageDirectory.CreateDirectory();
            }
        }
        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            BoxPassword.Text = BoxPassword.Text.Trim();
            BoxUser_Name.Text = BoxUser_Name.Text.Trim();
            if (BoxUser_Name.Text.Contains(' ') || BoxPassword.Text.Contains(' '))
            {
                MessageBox.Show("Fields cannot contain any spaces");
            }
            else
            {
                StoreUserCredentials newUser = new StoreUserCredentials(BoxUser_Name.Text, BoxPassword.Text);
                BoxPassword.Clear();
                BoxUser_Name.Clear();
            }
        }
        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string checkPath = @$"{StorageDirectory.StorageString}\{BoxUser_Name.Text}.txt";
            if (File.Exists(checkPath))
            {
                LoginVerification lv = new LoginVerification(checkPath);
                if (lv.isLogin(BoxUser_Name.Text, BoxPassword.Text))
                { 
                
                    PasswordsScreen ps = new PasswordsScreen(BoxUser_Name.Text);
                    ps.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect User Credentials\n Note:\tCase Sensitive");
                }
            }
            else
            {
                MessageBox.Show($"User name {BoxUser_Name.Text} not found.\n Note:\tCase Sensitive ");
            }
        }
    }
}