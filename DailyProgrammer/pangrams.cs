using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class pangrams
    {
        private char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', };

        public pangrams()
        {
            Console.Clear();
            Console.WriteLine("This is \"Panagrams\"");
            Console.WriteLine();
            Console.WriteLine("Panagrams will tell you whether your input sentence contains every letter of the alphabet or not.");

            Console.WriteLine();
            Console.Write("Please write your input sentence: ");
            string input = Console.ReadLine();

            checkInput(input);
            

        }

        private void checkInput(string input)
        {
            var list = input.ToList();
            var included = new List<char>();

            foreach(var item in alphabet)
            {
                if (list.Contains(item))
                {
                    included.Add(item);
                }
            }

            Console.WriteLine();
            if (alphabet.Length == included.Count)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            Console.ReadKey();
            
        }
    }
}
