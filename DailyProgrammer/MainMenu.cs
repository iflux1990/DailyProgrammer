using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disemvoweler;

namespace DailyProgrammer
{
    class MainMenu
    {
        private static string[] commands = {"help", "disemvowel", "quit", "panagrams", "torn", "rpsls", "xmas-tree", "arithmatic", "diceroll", "idgen", "matrix"};

        public MainMenu()
        {
            Console.Clear();
            InsertCommand();
        }

        private static void DoCommand(string command)
        {
            switch (command.ToLower())
            {
                case "disemvowel":
                    new Disemvoweler();
                    break;
                case "help":
                    PrintHelp();
                    break;
                case "panagrams":
                    new pangrams();
                    break;
                case "torn":
                    new Torn();
                    break;
                case "rpsls":
                    new Rpsls();
                    break;
                case "xmas-tree":
                    new tree();
                    break;
                case "arithmatic":
                    new Arithmatic();
                    break;
                case "diceroll":
                    new dice();
                    break;
                case "idgen":
                    new IdGenerator();
                    break;
                case "matrix":
                    new Matrix();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    InvalidCommand(command);
                    break;
            }
        }

        public static void InsertCommand()
        {
            Console.WriteLine("Which command would you like to run?");
            string input = Console.ReadLine();
            DoCommand(input);
        }


        private static void InvalidCommand(string command)
        {
            Console.WriteLine();
            Console.WriteLine("the command \"" + command + "\" does not exist");
            Console.WriteLine("Try \"Help\" if you want a list of commands");
            Console.WriteLine();
            InsertCommand();


        }

        private static void PrintHelp()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine(commands[i]);
            }
            Console.WriteLine();
            InsertCommand();
        }
    }
}
