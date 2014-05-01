using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer
{
    class Torn
    {
        int start = 1000;
        int end = 9999;

        public Torn()
        {
            Console.Clear();
            intro();
            calc();
            Console.ReadKey();
            new MainMenu();
        }

        private void calc()
        {

            var listOfTornNumbers = new List<int>();
            for (int i = start; i < end; i++)
            {
                int firsthalf = int.Parse(i.ToString().Substring(0, 2));
                int lasthalf = int.Parse(i.ToString().Substring(2, 2));
                int sum = firsthalf+lasthalf;

                if(sum*sum == i)
                {
                    listOfTornNumbers.Add(i);
                }
            }
            foreach (var n in listOfTornNumbers)
            {               
			    char[] digits = n.ToString().ToCharArray();			    
                if(digits.Distinct().Count() < 4)
                {
                    continue;
                }
                Console.WriteLine(n);
            }
        }

        private void intro()
        {
            Console.WriteLine("This is \"The Torn Numbers\"");
            Console.WriteLine("This list of numbers who can be split in the middle, ");
            Console.WriteLine("added together and multiplied for the original sum again.");
            Console.WriteLine();
            Console.WriteLine("This list is limited to 4 digit numbers.");
            Console.WriteLine();
            
        }
    
    }
}
