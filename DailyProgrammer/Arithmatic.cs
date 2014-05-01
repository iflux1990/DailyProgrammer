using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer
{
    class Arithmatic
    {
        private int guess;
        private int answer;

        public Arithmatic()
        {
            Intro();
            printProblem();
            checkAnswer(Input());
        }

        private void Intro()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("This is Arithmatic");
            Console.WriteLine("This program will keep creating basic arithmatic problems");
            Console.WriteLine("You can get back to the menu with \"q\" or \"Q\"");
        }

        private void printProblem()
        {
            Random rnd = new Random();
            int n1 = rnd.Next(1, 10);
            int n2 = rnd.Next(1, 10);
            int n3 = rnd.Next(1, 10);
            int n4 = rnd.Next(1, 10);
            char[] math = {'+', '-', '*'};

            string ops1 = math[rnd.Next(0, 2)].ToString();
            string ops2 = math[rnd.Next(0, 2)].ToString();
            string ops3 = math[rnd.Next(0, 2)].ToString();


            Console.WriteLine(">" + n1 + " " + ops1 + " " + n2 + " " + ops2  + " " + n3 + " " + ops3 + " " + n4);
            int temp = 0;

            if (ops1 == "+") {temp = n1 + n2;}
            else if (ops1 == "-") {temp = n1 - n2;}
            else if (ops1 == "*") {temp = n1 * n2;}

            if (ops2 == "+") {temp = temp + n3;}
            else if (ops2 == "-") { temp = temp - n3; }
            else if (ops2 == "*") { temp = temp * n3; }

            if (ops3 == "+") { answer = temp + n4; }
            else if (ops3 == "-") { answer = temp - n4; }
            else if (ops3 == "*") { answer = temp * n4; }
        }

        private void checkAnswer(int p)
        {
            if (p == answer)
            {
                Console.WriteLine(">Correct!");
                printProblem();
                checkAnswer(Input());
            }
            
            else
            {
                Console.WriteLine(">wrong, sorry. try again?");
                checkAnswer(Input());
            }
        }

        private int Input()
        {
            string input = Console.ReadLine();
            if (input == "q" || input == "Q")
                new MainMenu();

            try
            {
                guess = int.Parse(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }
            
            return guess;
        }
    }
}
