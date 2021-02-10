using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace LoginScreen0
{
    public partial class MainWindow : Window
    {
        StoreUserCredentials user1 = new StoreUserCredentials("user1");
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            user1.UserName = BoxUser_Name.Text;
            user1.Password = BoxPassword.Text;
            user1.Store();

            BoxPassword.Clear();
            BoxUser_Name.Clear();
        }


        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            LoginVerification lv = new LoginVerification(user1.StoragePath);
            string usPw = BoxUser_Name.Text + BoxPassword.Text;
            usPw = CreateMD5(usPw);
            lv.Login(usPw);

        }
        public string CreateMD5(string usPw)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(usPw);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

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