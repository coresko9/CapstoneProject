using System.Collections.Generic;
using System.IO;

namespace LoginScreen0
{
    class RetrieveCredentials
    {
        private static List<string> _websiteList;
        private static List<string> _userNamesList;
        private static List<string> _passwordsList;
        private static bool _firstLine;
        private static string line ;

        public static List<string> WebsiteList
        {
            get
            {
                RetrieveCreds();
                return _websiteList;
            }
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

        //PasswordsScreen.File_StoragePath
        private static void RetrieveCreds()
        {
            _firstLine = true;
            _websiteList = new List<string>();
            _userNamesList = new List<string>();
            _passwordsList = new List<string>();
            int indOfFirst = 0;
            int indOfSecond =0;
            StreamReader stream = new StreamReader(PasswordsScreen.File_StoragePath);

            while ((line = stream.ReadLine()) != null)
            {
                if (_firstLine)
                {
                    _firstLine = false;
                }
                else
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
            stream.Close();
        }

    }
}
