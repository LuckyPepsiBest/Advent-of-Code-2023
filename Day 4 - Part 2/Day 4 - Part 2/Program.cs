using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_4___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coppies = new int[203];
            
            for (int i = 0; i < coppies.Length; i++)
            {
                coppies[i] = 1;
            }

            List<string> winning = new List<string>();
            List<string> have = new List<string>();

            string line = "";
            int ph;

            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine(); //section of code is to remove card number
                    ph = line.IndexOf(':');
                    ph++;
                    line = line.Substring(ph);

                    string[] split = line.Split('|');
                    winning.Add(split[0]);
                    have.Add(split[1]);
                }
            }

            List<string> winnings = new List<string>(); // to store each individual value
            List<string> haves = new List<string>();
            string w = "";
            string h = "";

            double t = 0;
            double total = 0;

            string ph2 = ""; // place holders
            string ph3 = "";
            int p = 0;
            double o = 0;

            for (int i = 0; i < winning.Count; i++)
            {
                ph2 = "";
                ph3 = "";

                o = 0;
                p++;
                t = 0;
                winnings.Clear(); // to make sure the list is clear before changes on new line
                haves.Clear();

                w = winning[i]; // to split at each int
                h = have[i];

                for (int j = 0; j < w.Length; j++) // to add each individual value
                {
                    if (w[j] != ' ')
                    {
                        ph2 = ph2 + w[j];
                    }
                    else if ((w[j] == ' ') && (ph2 != ""))
                    {
                        winnings.Add(ph2);
                        ph2 = "";
                    }

                    if ((j == h.Length - 1))
                    {
                        winnings.Add(ph2);
                        ph2 = "";
                    }

                }

                for (int j = 0; j < h.Length; j++)
                {

                    if (h[j] != ' ')
                    {
                        ph3 = ph3 + h[j];
                    }
                    else if ((h[j] == ' ') && (ph3 != ""))
                    {
                        haves.Add(ph3);
                        ph3 = "";
                    }


                    if (j == h.Length - 1)
                    {
                        haves.Add(ph3);
                    }
                }


                for (int j = 0; j < winnings.Count; j++) // check if equal
                {
                    for (int m = 0; m < haves.Count; m++)
                    {
                        if (winnings[j] == haves[m])
                        {
                            t++;
                        }
                    }
                }

                for (int j = 1;  j <= t;  j++)
                {
                    coppies[i + j] += coppies[i];
                }
            }

            for (int i = 0; i < coppies.Length; i++)
            {
                Console.WriteLine(coppies[i]);
                total += coppies[i];
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
// 1994 < 