using System;

namespace LoginScreen0
{
    public class GeneratePW 
    {
        private int _Length;
        private bool _IncludeCaps;
        private bool _IncludeSymbs;
        private bool _IncludeNums;
        private string _Passwordalphabet = "abcdefghijklmnopqrstuvwxyz";
        private static string _alpha_UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string _alpha_Symbols = "!#$%&'()*+,-./:;<=>?@[]^_`{|}~";
        private static string _alpha_Numerics = "1234567890";

        public int Length
        {
            get
                { return _Length; }
            set
                { _Length = value; }
        }
        public bool IncludeCaps
        {
            get
                { return _IncludeCaps; }

            set
                { _IncludeCaps = value; }
        }
        public bool IncludeSymbs
        {
            get
                { return _IncludeSymbs; }
            set
                { _IncludeSymbs = value; }
           
        }
        public bool IncludeNums
        {
            get
                { return _IncludeNums; }
            set
                { _IncludeNums = value; }                       
        }
        public string Password
        {
            get 
                { return GenPassword(); }
            
        }
        public string GenPassword()
        {
            char[] password = new char[_Length];
            Random random = new Random();

            this._Passwordalphabet = (_IncludeCaps) ? $@"{_Passwordalphabet}{_alpha_UpperCase}" : _Passwordalphabet;
            this._Passwordalphabet = (_IncludeSymbs) ? $@"{_Passwordalphabet}{_alpha_Symbols}" : _Passwordalphabet;
            this._Passwordalphabet = (_IncludeNums) ? $@"{_Passwordalphabet}{_alpha_Numerics}" : _Passwordalphabet;
            for (int i = 0; i < this._Length; i++)
            {
                password[i] = _Passwordalphabet[random.Next(0, _Passwordalphabet.Length)];

        
            }
            string assembledPW = new string(password);
            return assembledPW;
        
        }
    }
}
