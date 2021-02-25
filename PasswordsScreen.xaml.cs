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
        protected static string _UserName;
        private static string _Password;
        GeneratePW pW = new GeneratePW();
        public PasswordsScreen(string filePath, string un, string pw)
        {
            InitializeComponent();
            _UserName = un;
            _Password = pw;
            StorePasswords sP = new StorePasswords(un);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StorePasswords store = new StorePasswords(EnterWebsiteBox.Text, EnterUserNameBox.Text, EnterPasswordBox.Text);
            store.Store();
        }

        private void Gen_NewPassword_Click(object sender, RoutedEventArgs e)
        {
            pW.Length = byte.Parse(SliderNum.Text);
            GenPasswordBox.Text = pW.GenPassword();
            Slider_Pw_Strength.Value = pW.Strength();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            pW.IncludeCaps = (bool)CheckBox_Caps.IsChecked;
            pW.IncludeNums =  (bool)CheckBox_Nums.IsChecked;
            pW.IncludeSymbs = (bool)CheckBox_Sym.IsChecked;
        }
    }
}
