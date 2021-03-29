using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace LoginScreen0
{
    class RetrieveCredentials
    {
        private static List<string> _websiteList;
        private static List<string> _userNamesList;
        private static List<string> _passwordsList;
        private static string line;

        public static List<string> WebsiteList
        {
            get
            {
                RetrieveCreds();
                return _websiteList;
            }
            
        }
        public void RemoveAtIndex(int index)
        {
            List<string> tempWeb = new List<string>();
            List<string> tempUn = new List<string>();
            List<string> tempPw = new List<string>();
            for (int i = 0; i < UserNameList.Count; i++)
            {
                tempUn.Add(UserNameList[i]);
                tempPw.Add(PasswordList[i]);
                tempWeb.Add(WebsiteList[i]);
            }
            tempUn.RemoveAt(index);
            tempWeb.RemoveAt(index);
            tempPw.RemoveAt(index);

            
            UpdateCreds(tempWeb, tempUn, tempPw); 
        }
        public static List<string> UserNameList
        {
            get
            {
                return _userNamesList;
            }
        }
        public static List<string> PasswordList
        {
            get
            {
                return _passwordsList;
            }
        }
        private void UpdateCreds(List<string> webList, List<string> userList,List<string> passwList)
        {
            using (FileStream fs = File.Create(UserProperties.UserStorageFilePath))
            {
            }
            using (StreamWriter streamWriter1 = new StreamWriter(UserProperties.UserStorageFilePath))
            {
                for (int i = 0; i < webList.Count; i++)
                {
                    
                    string line = $"{webList[i]} {userList[i]} {passwList[i]}\n";
                   
                    streamWriter1.WriteLine(line);
                }
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
        private static void RetrieveCreds()
        {

            _websiteList = new List<string>();
            _userNamesList = new List<string>();
            _passwordsList = new List<string>();
            int indOfFirst = 0;
            int indOfSecond = 0;

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
            using (StreamReader stream = new StreamReader(UserProperties.UserStorageFilePath))
            {
                while ((line = stream.ReadLine()) != null)
                {
                    line = line.Trim();
                    indOfFirst = line.IndexOf(" ");
                    indOfSecond = line.LastIndexOf(" ");
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        _websiteList.Add(line.Substring(0, indOfFirst + 1));
                        _userNamesList.Add(line.Substring(indOfFirst, indOfSecond - indOfFirst));
                        _passwordsList.Add(line.Substring(indOfSecond, line.Length - indOfSecond));
                    }
                }
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
