using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class Disemvoweler
    {
        private char[] vowels = { 'a', 'e', 'i', 'o', 'u' ,' '};

        public Disemvoweler()
        {
            Console.Clear();
            Console.WriteLine("Disemvoweler has started");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Please write your input sentence: ");

            string input = Console.ReadLine();
            DisemVOWEL(input);
        }

        private void DisemVOWEL(string input)
        {
            var list = input.ToList();
            var removedVowels = new List<object>();


            try
            {
                foreach (var item in input.ToList())
                {
                    for (int i = 0; i < vowels.Length; i++)
                    {
                        if (item == vowels[i])
                        {
                            removedVowels.Add(item);
                            list.Remove(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Sentence was succesfully disemvoweled");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Output:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Removed vowels:");
            for (int i = 0; i < removedVowels.Count; i++)
            {
                Console.Write(removedVowels[i]);
            }
            Console.WriteLine();
           
        }

    }
}
