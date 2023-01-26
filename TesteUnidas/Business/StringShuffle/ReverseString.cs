﻿using TesteUnidas.Business.StringShuffle.Interface;

namespace TesteUnidas.Business.StringShuffle
{
    internal class ReverseString : IReverseString
    {
        public string Reverse(string splitedText)
        {
            //Inverte a string
            
            return new string(splitedText.Reverse().ToArray());
        }
    }
}