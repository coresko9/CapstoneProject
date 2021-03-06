﻿using System;
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
            ComboBox_Credentials.ItemsSource = RetrieveCredentials.WebsiteList;
            

        }

        private void ComboBox_Credentials_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBox_Credentials.SelectedIndex > 0)
            {
                int index = ComboBox_Credentials.SelectedIndex;

                ComboBox_Credentials.ItemsSource = RetrieveCredentials.WebsiteList;
                Retrieve_Password.Text = RetrieveCredentials.PasswordList[index].Trim();
                Retrieve_UserName.Text = RetrieveCredentials.UserNameList[index].Trim();
            }
        }
        private void Button_Generate_Click(object sender, RoutedEventArgs e)
        {
            ComboBox_Credentials.ItemsSource = RetrieveCredentials.WebsiteList;
        }
        private void Button_DeleteCreds_Click(object sender, RoutedEventArgs e)
        {
           
            int index = ComboBox_Credentials.SelectedIndex;
            if (index <0)
            {
                MessageBox.Show("Nothing To Delete");
            }
            else
            {
                RetrieveCredentials rem = new RetrieveCredentials();
                rem.RemoveAtIndex(index);
                ComboBox_Credentials.ItemsSource = RetrieveCredentials.WebsiteList;
                if (RetrieveCredentials.WebsiteList.Count != 0)
                {
                    ComboBox_Credentials.SelectedIndex = 0;
                    Retrieve_Password.Text = RetrieveCredentials.PasswordList[0].Trim();
                    Retrieve_UserName.Text = RetrieveCredentials.UserNameList[0].Trim();
                }
                else
                {
                    Retrieve_Password.Text = "";
                    Retrieve_UserName.Text = "";
                }
            }
        }
    }
}
