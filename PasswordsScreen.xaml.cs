using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoginScreen0
{
    /// <summary>
    /// Interaction logic for PasswordsScreen.xaml
    /// </summary>
    public partial class PasswordsScreen : Window
    {
        private string _UserName;
        private string _Password;
        public PasswordsScreen(string filePath, string un, string pw)
        {
            this._UserName = un;
            this._Password = pw;
        }
        public PasswordsScreen()
        {
            InitializeComponent();
        }

    }
}
