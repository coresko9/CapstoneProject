using System.IO;
using System;

namespace LoginScreen0
{
    class StorageDirectory
    {
        protected static string _FolderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
        protected static string _StorageString = Path.Combine(_FolderName,"ProjectInfo");
        public string StorageString
        {
            get
            {
                return _StorageString;
            }
        }     
        public static void CreateDirectory()
        {
            Directory.CreateDirectory(_StorageString);

        }
    }
}