using System;

namespace LoginScreen0
{
    public class GeneratePW 
    {
        private int _Length;
        private bool _IncludeCaps;
        private bool _IncludeSymbs;
        private bool _IncludeNums;
        private static string _Passwordalphabet = "abcdefghijklmnopqrstuvwxyz";
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

        public int Strength()
        {
            int strength = 10;
            strength *= (_Length / 4);
            if (_IncludeCaps) strength *= 3;
            if (_IncludeNums) strength *= 2;
            if (_IncludeSymbs) strength *= 3;

            if (strength > 100)
            {
                 return strength = 100;
            }
            else
            {
                return strength;
            }
        }
        public string GenPassword()
        {
            string dynamicAlphabet;
            char[] password = new char[_Length];
            Random random = new Random();
            if (_IncludeCaps && _IncludeSymbs && _IncludeNums)
            {
                dynamicAlphabet = $@"{_Passwordalphabet}{_alpha_Symbols}{_alpha_UpperCase}{_alpha_Numerics}";
            }
            else if (_IncludeCaps && _IncludeSymbs )
            {
                dynamicAlphabet = $@"{_Passwordalphabet}{_alpha_Symbols}{_alpha_UpperCase}";
            }
            else if (_IncludeSymbs && _IncludeNums)
            {
                dynamicAlphabet = $@"{_Passwordalphabet}{_alpha_Symbols}{_alpha_Numerics}";
            }
            else if (_IncludeCaps && _IncludeNums)
            {
                dynamicAlphabet = $@"{_Passwordalphabet}{_alpha_UpperCase}{_alpha_Numerics}";
            }
            else if (_IncludeNums)
            {
                dynamicAlphabet = $@"{_Passwordalphabet}{_alpha_Numerics}";
            }
            else if (_IncludeCaps )
            {
                dynamicAlphabet = $@"{_Passwordalphabet}{_alpha_UpperCase}";
            }
            else if (_IncludeSymbs )
            {
                dynamicAlphabet = $@"{_Passwordalphabet}{_alpha_Symbols}";
            }
            else
            {
                dynamicAlphabet = _Passwordalphabet;
            }
           
            for (int i = 0; i < this._Length; i++)
            {
                password[i] = dynamicAlphabet[random.Next(0, dynamicAlphabet.Length)];
            }
            string assembledPW = new string(password);
            return assembledPW;
        }
    }
}
