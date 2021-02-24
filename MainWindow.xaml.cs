using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            if (!string.IsNullOrWhiteSpace(BoxPassword.Text) || !string.IsNullOrWhiteSpace(BoxUser_Name.Text))
            {
                newUser.Password = BoxPassword.Text;
                newUser.Store(BoxUser_Name.Text);
                BoxPassword.Clear();
                BoxUser_Name.Clear();
            }
            else
            {
                MessageBox.Show("Cannot Be Empty");
            }
        }


        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BoxPassword.Text) || !string.IsNullOrWhiteSpace(BoxUser_Name.Text))
            {


                string checkPath = @$"{defaultDirectory.StorageString}\{BoxUser_Name.Text}.txt";
                if (File.Exists(checkPath))
                {
                    LoginVerification lv = new LoginVerification(checkPath);
                    string usPw = BoxUser_Name.Text + BoxPassword.Text;
                    if (lv.isLogin(usPw))
                    {

                        PasswordsScreen ps = new PasswordsScreen(checkPath, BoxUser_Name.Text, BoxPassword.Text);
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
            else
            {
                MessageBox.Show("Cannot Be Empty");
            }
        }
    }
}