namespace LoginScreen0
{
    abstract class UserProperties
    {
        private static string _userStorageFilePath;
        private static string _hash;
        private static string _key;

        public static string UserStorageFilePath
        {
            get
            {
                return _userStorageFilePath;
            }
            set
            {
                _userStorageFilePath = value;
            }
        }
        public static string Hash
        {
            get
            {
                return _hash;
            }
            set
            {
                _hash = value;
            }
        }
        public static string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

    }
}

