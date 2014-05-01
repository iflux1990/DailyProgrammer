using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer
{
    class Rpsls
    {
        private string[] attackStrings = {"rock", "paper", "scissors", "lizard", "spock"};
        private string inputString;
        private string aiChoice;
        private string winner;
        private static int totalWins;
        private static int totalGames;

        public Rpsls()
        {
            intro();
            aiChoice = randomize();
            checkInput(input().Trim());
            printWinner();
            Console.WriteLine();
            Console.ReadKey();
            new Rpsls();
        }

        private void printWinner()
        {
            Console.WriteLine("Its \"" + inputString + "\" against \"" + aiChoice + "\"");
            Console.WriteLine();
            if (winner == "YOU")
            {
                Console.WriteLine("Congratulations, you won the game this time.");
                totalWins++;
                totalGames++;
            }
            else if (winner == "TIE")
            {
                Console.WriteLine("Tied, try again");
                aiChoice = "";
                winner = "";
                totalGames++;
            }
            else
            {
                Console.WriteLine("Sorry, man. you lost");
                totalGames++;
            }
        }

        private string randomize()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 4);
            return attackStrings[value];
        }

        private void checkInput(string s)
        {
            if (aiChoice == s)
            {
                winner = "TIE";
            }
            else if (s == "rock" && aiChoice == "scissors")
                winner = "YOU";
            else if (s == "rock" && aiChoice == "lizard")
                winner = "YOU";
            else if (s == "paper" && aiChoice == "rock")
                winner = "YOU";
            else if (s == "paper" && aiChoice == "spock")
                winner = "YOU";
            else if (s == "scissors" && aiChoice == "paper")
                winner = "YOU";
            else if (s == "scissors" && aiChoice == "lizard")
                winner = "YOU";
            else if (s == "lizard" && aiChoice == "paper")
                winner = "YOU";
            else if (s == "lizard" && aiChoice == "spock")
                winner = "YOU";
            else if (s == "spock" && aiChoice == "rock")
                winner = "YOU";
            else if (s == "spock" && aiChoice == "scissors")
                winner = "YOU";
            else
            {
                winner = "AI";
            }
        }

        private string input()
        {
            Console.Write("Please write your attack style: ");
            inputString = Console.ReadLine();
            if (inputString == "automate")
                DoAutomate();
            else if (attackStrings.Contains(inputString))
                return inputString;
            else if (inputString == "quit")
                new MainMenu();
            else if (inputString == "history")
                printHistory();
            Console.Write("Your input has to match one of the attacks: ");
            foreach (var s in attackStrings)
            {
                Console.Write("\"" + s + "\" ");
            }
            Console.WriteLine();
            input();
            return "scissors";
        }

        private void printHistory()
        {
            Console.Clear();
            Console.WriteLine("You have won: " + totalWins + " out of " + totalGames + " so far.");
            Console.ReadKey();
            new Rpsls();
        }

        private void DoAutomate()
        {
            int wins = 0;
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                checkInput(attackStrings[rnd.Next(0, 4)]);
                if (winner == "YOU")
                {
                    wins++;
                }
            }
            Console.WriteLine("You won: " + wins + " of 100 games");
            Console.ReadKey();
            Console.Clear();
            
        }

        private void intro()
        {
            Console.Clear();
            Console.WriteLine("This is a game \"Rock, Paper, Scissors, Lizard, Spock\" from the popular tv series \"The big bang Theory\"");
            Console.WriteLine("The objective here, is to beat the AI");
            Console.WriteLine("Good luck with that!");
            Console.WriteLine();

        }
    }
}
