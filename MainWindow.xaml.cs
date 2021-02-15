using System.Windows;
using System.IO;


namespace LoginScreen0
{
    public partial class MainWindow : Window
    {
        StorageDirectory defaultDirectory = new StorageDirectory();
        StoreUserCredentials newUser = new StoreUserCredentials();

        public MainWindow()
        {       
            InitializeComponent();  
            if (!Directory.Exists(defaultDirectory.StorageString))
            {
                StorageDirectory.CreateDirectory();
            }
        }
        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            newUser.Password = BoxPassword.Text;
            newUser.Store(BoxUser_Name.Text);
            BoxPassword.Clear();
            BoxUser_Name.Clear();
        }


        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string checkPath = @$"{defaultDirectory.StorageString}\{BoxUser_Name.Text}.txt";
            if (File.Exists(checkPath))
            {
                LoginVerification lv = new LoginVerification(checkPath);
                string usPw = BoxUser_Name.Text + BoxPassword.Text;
                if (lv.isLogin(usPw))
                {

                    PasswordsScreen ps = new PasswordsScreen(checkPath,BoxUser_Name.Text,BoxPassword.Text);
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