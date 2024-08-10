using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Random_Values_Generation
{
    public class Constances
    {
        public Constances()
        {
            CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            SmallLetters = "abcdefghijklmnopqrstuvwxyz";
            Numbers = "0123456789";
            Symbols = "!@#$%^&*()-_=+[]{}|;:,.<>/?";
        }

        public string CapitalLetters { get; }
        public string SmallLetters { get; }
        public string Numbers { get; }
        public string Symbols { get; }
    }
}