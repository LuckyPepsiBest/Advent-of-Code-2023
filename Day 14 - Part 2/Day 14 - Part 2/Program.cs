using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day_14___Part_2
{
    internal class Program
    {
        static Dictionary<string, int> dictionary = new Dictionary<string, int>();
        static bool temp = false;
        static int main = 0;
        static int non = 0;
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

            for (int i = 0; i <= 1000000000; i++)
            {
                cycles(ref platform, a, b, i);
                if (temp) { break; }
            }

            /*for (int i = 0; i < b; i++) // Writes the array
            {
                for (int j = 0; j < a; j++)
                {
                    Console.Write(platform[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();*/

            int c = (1000000000 - main - 1) % (main - non);


            for (int i = 0; i < c; i++)
            {
                cycles(ref platform, a, b, i);
            }

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

        static void cycles(ref char[,] platform, int a, int b, int index)
        {

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

            for (int i = 0; i < b; i++) // move O to west
            {
                for (int j = 1; j < a; j++)
                {
                    if (j <= 0) { break; }
                    if (i < 0) { break; }
                    if (platform[i, j] == 'O')
                    {
                        if (platform[i, j - 1] == '.')
                        {
                            platform[i, j - 1] = 'O';
                            platform[i, j] = '.';
                            j--;
                            i--;
                        }
                    }

                }
            }

            for (int i = b - 1; i >= 0; i--) // move O to south
            {
                for (int j = 0; j < a; j++)
                {
                    if (i == b - 1) { break; }
                    if (platform[i, j] == 'O')
                    {
                        if (platform[i + 1, j] == '.')
                        {
                            platform[i + 1, j] = platform[i, j];
                            platform[i, j] = '.';
                            i++;
                            j--;
                        }
                    }

                }
            }

            for (int i = 0; i < b; i++) // move O to east
            {
                for (int j = 0; j < a; j++)
                {
                    if (j == a - 1 || i < 0) { break; }
                    if (platform[i, j] == 'O')
                    {
                        if (platform[i, j + 1] == '.')
                        {
                            platform[i, j + 1] = platform[i, j];
                            platform[i, j] = '.';
                            j--;
                            i--;
                        }
                    }

                }
            };
            string gridthing = "";

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    gridthing = gridthing + platform[i, j];
                }
            }

            if (!dictionary.ContainsKey(gridthing))
            {
                dictionary.Add(gridthing, index);
            }
            else
            {
                non = dictionary[gridthing];
                temp = true;
                main = index;

            }
        }
    }
}


//< 96063