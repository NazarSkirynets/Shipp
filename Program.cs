using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship
{
    class Program
    {
        static Ships<Ship> ships = new Ships<Ship>();
        static void Main(string[] args)
        {
            string fullPath = @"D:\Download\Проги\C#\Ship\Ship\Ships.txt";

            while (true)
            {
                if (File.Exists(fullPath))
                {
                    ReadFromFile(fullPath);
                    break;
                }
                Console.WriteLine("Data is incorrect Please recheck the data...");
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose your option: ");
                    Console.WriteLine("Sort - press 1");
                    Console.WriteLine("Search - press 2");
                    Console.WriteLine("Print - press 3");
                    Console.WriteLine("Exit -  press 4");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.WriteLine("Enter the name of field to sort: ");
                            ships.Sort();
                            break;
                        case 2:
                            Console.WriteLine("Enter the name of ship to search: ");
                            ships.SearchElement();
                            break;
                        case 3:
                            Console.WriteLine("The array is: ");
                            ships.Print();
                            break;
                        case 4:
                            Process.GetCurrentProcess().Kill();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid data");
                    Console.ReadKey();
                }
            }
        }

        static void ReadFromFile(string fullPath)
        {
            using (StreamReader file = new StreamReader(fullPath))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    if (Ship.ValidateElem(ln))
                    {
                        var ship = new Ship(ln);
                        ships.ships.Add(ship);
                    }
                }
                file.Close();
            }
        }
    }
}
