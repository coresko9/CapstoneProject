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
       
        GeneratePW pW = new GeneratePW();
        StorePasswords sP = new StorePasswords();

        public PasswordsScreen(string un)
        {
            InitializeComponent();
            
           
            ComboBox_Credentials.ItemsSource = RetrieveCredentials.WebsiteList;
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sP.Store(EnterWebsiteBox.Text.Trim(), EnterUserNameBox.Text.Trim(), EnterPasswordBox.Text.Trim());
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
        private void CopyTo_Click(object sender, RoutedEventArgs e)
        {
            EnterPasswordBox.Text = GenPasswordBox.Text;
        }
        private void ComboBox_Credentials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ComboBox_Credentials.SelectedIndex;
            Retrieve_Password.Text = RetrieveCredentials.PasswordList[index];
            Retrieve_UserName.Text = RetrieveCredentials.UserNameList[index];

        }

        private void ComboBox_Credentials_DropDownClosed(object sender, EventArgs e)
        {

        }
        private void Button_Generate_Click(object sender, RoutedEventArgs e)
        {
            ComboBox_Credentials.ItemsSource = RetrieveCredentials.WebsiteList;

        }
    }
}
