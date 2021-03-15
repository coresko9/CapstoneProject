using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace LoginScreen0
{
    class StorePasswords
    {
        public void Store(string websiteName, string userName, string passWord)
        {


            if (string.IsNullOrWhiteSpace(websiteName) || websiteName.Contains(' ') ||
                string.IsNullOrWhiteSpace(userName) || userName.Contains(' ') ||
                string.IsNullOrWhiteSpace(passWord) || passWord.Contains(' '))
            {
                MessageBox.Show("Fields Cannot Be Empty or Contain a space");

            }
            else
            {
                List<string> content = new List<string>();
                
                using (StreamReader streamReader = new StreamReader(UserProperties.UserStorageFilePath))
                {
                    content = streamReader.ReadToEnd().Split('\n', StringSplitOptions.None).ToList();
                }

                List<string> copyContent = new List<string>();

                string allContent = "";

                for (int i = 0; i < content.Count(); i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    else
                    {
                        copyContent.Add(content[i]);

                    }
                }

                allContent = String.Join('\n', copyContent);

                using (StreamWriter stream = new StreamWriter(UserProperties.UserStorageFilePath))
                {
                    stream.WriteLine(allContent);
                }

                EncryptDecrypt decrypt = new EncryptDecrypt(UserProperties.Key);

                using (StreamWriter stream2 = new StreamWriter(UserProperties.UserStorageFilePath))
                {
                    stream2.WriteLine(decrypt.DecryptString());
                }

                using (StreamWriter registUser = new StreamWriter(UserProperties.UserStorageFilePath, true))
                {
                    if (File.Exists(UserProperties.UserStorageFilePath))
                    {

                        MessageBox.Show($"Saving to: {UserProperties.UserStorageFilePath}");
                        registUser.WriteLine($"{websiteName} {userName} {passWord}");
                        MessageBox.Show("Credentials Saved!");
                    }
                    registUser.Close();
                }
                EncryptDecrypt encrypt = new EncryptDecrypt(UserProperties.Key);

                using (StreamWriter streamWriter = new StreamWriter(UserProperties.UserStorageFilePath))
                {
                    streamWriter.WriteLine(encrypt.EncryptString());
                }

                List<string> content2 = new List<string>();
                using (StreamReader streamReader = new StreamReader(UserProperties.UserStorageFilePath))
                {
                    content2 = streamReader.ReadToEnd().Split('\n', StringSplitOptions.None).ToList();
                }

                List<string> copyContent2 = new List<string>();

                string allContent2 = "";

                for (int i = -1; i < content2.Count(); i++)
                {
                    if (i == -1)
                    {
                        copyContent2.Add(UserProperties.Hash);
                    }
                    else
                    {
                        copyContent2.Add(content2[i]);

                    }
                }

                allContent2 = String.Join('\n', copyContent2);

                using (StreamWriter stream = new StreamWriter(UserProperties.UserStorageFilePath))
                {
                    stream.WriteLine(allContent2);

                }
            }
        }
    }
}
