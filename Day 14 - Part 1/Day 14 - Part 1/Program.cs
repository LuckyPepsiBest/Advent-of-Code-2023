using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14___Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
            }

            string line = list[0];
            int a = line.Length;
            int b = list.Count;

            char[,] platform = new char[a, b];

            for (int i = 0; i < b; i++) // Populates array
            {
                line = list[i];
                for (int j = 0; j < a; j++)
                {
                    platform[i, j] = line[j];
                }
            }

            for (int i = 1; i < b; i++) // move O to north
            {
                for (int j = 0; j < a; j++)
                {
                    if (i == 0) { break; }
                    if (platform[i, j] == 'O')
                    {
                        if (platform[i - 1, j] == '.')
                        {
                            platform[i - 1, j] = platform[i, j];
                            platform[i, j] = '.';
                            i--;
                            j--;
                        }
                    }

                }
            }

            /*for (int i = 0; i < b; i++) // Writes the array
            {
                for (int j = 0; j < a; j++)
                {
                    Console.Write(platform[i, j] + " "); 
                }
                Console.WriteLine();
            }*/



            int total = 0;
            int total0 = 0;

            for (int i = 0; i < line.Length; i++) // finds total
            {
                for (int j = 0; j < a; j++)
                {
                    if (platform[i, j] == 'O')
                    {
                        total0++;
                    }
                }
                total += total0 * b;
                b--;
                total0 = 0;
            }

            Console.WriteLine(total);

            Console.ReadKey();
        }

    }
}



