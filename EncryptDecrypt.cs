using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LoginScreen0
{
    class EncryptDecrypt
    {
        private string _key;
        private string _text;
        private string _fileLocation;

        public EncryptDecrypt(string key)
        {
            _key = key;
            _fileLocation = UserProperties.UserStorageFilePath;
            using (StreamReader streamReader = new StreamReader(_fileLocation))
            {
                _text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }
        public static string CreateKey(string hash)
        {
            using (MD5 mD5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(hash);
                byte[] hashBytes = mD5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public string EncryptString()
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(_text);
                        }
                        array = memoryStream.ToArray();
                        
                    }
                }
            }
            return Convert.ToBase64String(array);
        }
        public string DecryptString()
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(_text);
            
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {

                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

    }

}


