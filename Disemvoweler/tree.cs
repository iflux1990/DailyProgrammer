using System;
using System.Linq;

namespace Disemvoweler
{
    internal class tree
    {
        private char output = ' ';
        private char space = ' ';

        public tree()
        {
            Console.Clear();
            intro();
            buildTree(input());
            Console.ReadKey();
            new tree();
        }

        private void buildTree(string[] p)
        {
            int width = int.Parse(p[0]);
            char leaf = p[1].ToCharArray()[0];
            char trunk = p[2].ToCharArray()[0];

            for (int i = 0; i < width/2 + 1; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output = (j >= ((width/2) - i) && j <= ((width/2) + i)) ? leaf : space;
                    Console.Write(output);
                }
                Console.WriteLine("  ");
            }

            for (int i = 0; i < width; i++)
            {
                output = (i >= ((width/2) - 1) && i <= ((width/2) + 1)) ? trunk : space;
                Console.Write(output);
            }
        }


        private string[] input()
        {
            Console.WriteLine();
            Console.Write("Input: ");
            try
            {
                string[] inputStrings = Console.ReadLine().Split(' ');
                if (int.Parse(inputStrings[0])%2 != 0 && inputStrings.Length == 3)
                {
                    return inputStrings;
                }
                else
                {
                    Console.WriteLine("The \"input\" does not match the requirements, please try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught an unexpected exception: " + ex.Message);
            }
            return input();
        }

        private void intro()
        {
            Console.WriteLine("This is a small program that generates a tree with");
            Console.WriteLine("a given width on the bottom row and leaf style.");
            Console.WriteLine();
            Console.WriteLine("input: width(int) leaf trunk");
            Console.WriteLine("Example: 15 + =");
        }
    }
}