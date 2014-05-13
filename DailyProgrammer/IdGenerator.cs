using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DailyProgrammer;

namespace Disemvoweler
{
    class IdGenerator
    {
        class Identity
        {
            public readonly string Name;
            public readonly string Middlename;
            public readonly string Lastname;
            public readonly string Address;
            public readonly string City;
            public readonly string DateOfBirth;

            public Identity(string name, string middlename, string lastname, string address, string city, string dateOfBirth)
            {
                Name = name;
                Middlename = middlename;
                Lastname = lastname;
                Address = address;
                City = city;
                DateOfBirth = dateOfBirth;
            }

        }

        private List<Identity> output = new List<Identity>();
        Random rnd = new Random();
        private string[] femaleNames = null;
        private string[] maleNames = null;
        private string[] names = null;

        private string[] middleNames =
        {
            "A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J.", "K.", "L.", "M.",
            "N.", "O.", "P.", "Q."
        };

        private string[] lastNames = null;
        private string[] adresses = null;
        private string[] cities = null;

        public IdGenerator()
        {
            Intro();
            generateNameArrays();
            GenerateIds(input());
            Print(output);
        }

        private void Intro()
        {
            Console.Clear();
            Console.WriteLine("This is Id-Generator");
            Console.WriteLine("Id-Generator will generate random identities,");
            Console.WriteLine("based on the files in the..\\data\\ folder.");
            Console.WriteLine("Input: amount age gender");
            Console.WriteLine("Example: 1 18 male");
            Console.WriteLine("Or just: 1; if you want random age and random gender.");
        }

        private void generateNameArrays()
        {
            try
            {
                maleNames = File.ReadAllLines(@"~\..\..\..\data\names.txt")[0].Split(';');
                femaleNames = File.ReadAllLines(@"~\..\..\..\data\names.txt")[1].Split(';');

                names = new string[maleNames.Length + femaleNames.Length];
                maleNames.CopyTo(names, 0);
                femaleNames.CopyTo(names, maleNames.Length);

                lastNames = File.ReadAllText(@"~\..\..\..\data\lastnames.txt").Split(';');
                adresses = File.ReadAllText(@"~\..\..\..\data\adresses.txt").Split(';');
                cities = File.ReadAllText(@"~\..\..\..\data\cities.txt").Split(';');
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Trying to generate arrays again.");
                Console.ReadKey();
                generateNameArrays();
            }
        }

        private void GenerateIds(string[] p)
        {
            string name = "";
            string gender = null;
            int amount = int.Parse(p[0]);
            int age = 0;
            string dateOfBirth;

            if (p.Length == 2)
            {
                age = int.Parse(p[1]);
            }
            else if (p.Length == 3)
            {
                age = int.Parse(p[1]);
                gender = (p[2]);
            }

            for (int i = 0; i < amount; i++)
            {
                
                if (gender == "male")
                {
                    name = maleNames[rnd.Next(0, maleNames.Length)];
                }
                else if (gender == "female")
                {
                    name = femaleNames[rnd.Next(0, femaleNames.Length)];
                }
                else
                {
                    name = names[rnd.Next(0, names.Length)];
                }

                string middleName = middleNames[rnd.Next(0, middleNames.Length)];
                string lastName = lastNames[rnd.Next(0, lastNames.Length)];
                string address = adresses[rnd.Next(0, adresses.Length)] + " " + rnd.Next(1,999);
                string city = cities[rnd.Next(0, cities.Length)];
                if (age != 0)
                {
                    dateOfBirth = rnd.Next(1, 31) + "-" + rnd.Next(1, 12) + "-" + (System.DateTime.Now.Year - age);
                }
                else
                    dateOfBirth = rnd.Next(1, 31) + "-" + rnd.Next(1, 12) + "-" + rnd.Next(1960, System.DateTime.Now.Year);

                output.Add(new Identity(name,middleName,lastName,address, city, dateOfBirth));
                
            }
            
        }

        private string[] input()
        {
            string inputString = Console.ReadLine();
            
            if (inputString == "quit")
                new MainMenu();
            try
            {
                return inputString.Split(' ');
            }
            catch (Exception ex)
            {
                Console.WriteLine("You need atleast 1 parameter (amount)" + ex.Message);
            }
            return input();
        }

        private void Print(List<Identity> output)
        {
            Console.Clear();
            foreach (Identity i in output)
            {
                Console.WriteLine(i.Name + " " + i.Middlename + " " + i.Lastname);
                Console.WriteLine(i.Address + ", " + i.City);
                Console.WriteLine(i.DateOfBirth);
                Console.WriteLine();
            }
            Console.ReadKey();
            new MainMenu();
        }
    }
}
