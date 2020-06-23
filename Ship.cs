using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship
{
    public class Ship
    {
        public string Name { get; set; }
        public string Port { get; set; }
        public double Tonality { get; set; }

        public Ship()
        {
            this.Name = " ";
            this.Port = " ";
            this.Tonality = 0;
        }
        public Ship(string name,string port,double tonality)
        {
            this.Name = name;
            this.Port = port;
            this.Tonality = tonality;
        }
        public Ship(string ln)
        {
            var line = ln.Split();
            this.Name = line[0].ToString();
            this.Port = line[1].ToString();
            this.Tonality = Convert.ToDouble(line[2].ToString());
        }
        public void Print()
        {
            Console.WriteLine($"Name:{Name} \t Port: {Port} \t Tonality: {Tonality}");
        }

        public override string ToString() => $"{Name} {Port} {Tonality}";

        

        public static bool ValidateElem(string line)
        {
            string[] line1 = line.Split();

            if (!validString(line1[0]) || !validString(line1[1]) || !validDigit(line1[2]))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool validString(string word)
        {
            foreach (char c in word)
                if (Char.IsNumber(c) || Char.IsSymbol(c))
                {
                    return false;
                }
            return true;
        }

        public static bool validDigit(string number)
        {
            foreach (char c in number)
                if (Char.IsLetter(c) || Char.IsSymbol(c))
                {
                    return false;
                }
            if (Convert.ToDouble(number) < 0)
            {
                return false;
            }
            return true;
        }
    }
}
