using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Ship
{
    class Ships<T> where T : Ship
    {
        public List<T> ships = new List<T>();
        public string filename { get; set; }
        public void Print()
        {
            foreach (var ship in ships)
            {
                ship.Print();
            }
        }
        public void Sort()
        {
            try
            {
                string sortBy = Console.ReadLine();
                ships = ships.OrderBy(r => r.GetType().GetProperty(sortBy).GetValue(r, null)).ToList();
                Print();
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter existing field!");
            }
        }

        public void SearchElement()
        {
            string key = Console.ReadLine();
            foreach (var ship in ships)
            {
                if (ship.Name.ToString().ToLower().Contains(key.ToLower()))
                {
                    Console.WriteLine(ship);
                }
            }
        }
    }
}
