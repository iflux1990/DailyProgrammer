using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class dice
    {


        Random rnd = new Random();

        public dice()
        {
            Intro();
            readInput();
        }

        private void rollTheDice(int sides, int rolls)
        {
            for (int i = 0; i < rolls; i++)
            {
                Console.Write(rnd.Next(1, sides) + " ");
                
            }
            Console.WriteLine();
            Console.WriteLine("Roll a new dice? (y/n)");
            if (Console.ReadLine() == "y")
            {
                readInput();
            }
            new MainMenu();
            
        }

        private void readInput()
        {
            int sides = 0;
            int rolls = 0;

            Console.Write("Input: ");
            string input = Console.ReadLine().Trim();

            if (input == "q" && input == "quit")
            {
                new MainMenu();
            }

            try
            {
                string[] temp = input.Split('d');
                rolls = int.Parse(temp[0]);
                sides = int.Parse(temp[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                readInput();
            }
            
            rollTheDice(sides, rolls);
        }

        private void Intro()
        {
            Console.Clear();
            Console.WriteLine("This is a magic Dice");
            Console.WriteLine("it will do any amount of rolls");
            Console.WriteLine("the dice can have any number of sides");
            Console.WriteLine("This dice uses the \"NdM\" denomination know from Dungeons and Dragons");
            Console.WriteLine("Example input: 2d20");
            Console.WriteLine("Output: 6 17");
        }


    }
}
