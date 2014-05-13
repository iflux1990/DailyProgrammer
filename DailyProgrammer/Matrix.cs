using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace Disemvoweler
{
    internal class Matrix
    {
        private readonly List<int[]> arrayList = new List<int[]>();
        private readonly Random rnd = new Random();
        private System.Timers.Timer aTimer = new System.Timers.Timer(20000);
        private int HEIGHT = 90;
        private int LENGTH = 59;
        private bool notDone = true;

        public Matrix()
        {
            //PrintIntro();
            GenerateArrays();
            printMatrix();
            //manipulateMatrix();
        }

        private void manipulateMatrix()
        {
            throw new NotImplementedException();
        }

        private void printMatrix()
        {
            while (notDone)
            {
                for (int j = 0; j < arrayList.Count; j++)
                {
                    for (int i = 0; i < LENGTH; i++)
                    {
                        Console.Write(arrayList[j][i] + " ");
                    }
                    Console.WriteLine();
                }
                GenerateArrays();
                aTimer.Elapsed += (sender, args) => printMatrix(); 
            }
            
        }

        private void GenerateArrays()
        {
            for (int j = 0; j < HEIGHT; j++)
            {
                var row = new int[LENGTH];
                for (int i = 0; i < LENGTH; i++)
                {
                    row[i] = rnd.Next(10, 99);
                }
                arrayList.Add(row);
            }
        }
    }
}