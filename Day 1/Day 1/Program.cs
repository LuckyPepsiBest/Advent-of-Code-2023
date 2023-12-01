using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string[] numerals = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] ints = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
            }

            int total = 0;


            for (int i = 0; i < list.Count; i++)
            {

                List<int> fsv = new List<int>();
                List<int> fbv = new List<int>();


                int c3 = -1;
                int c2 = 10;
                int c1 = 10;

                int c3s = -1;
                int c2s = 1000;


                string ph = "";
                string ph2 = "";
                string ph3 = "";
                string line = list[i];
                for (int j = 0; j < line.Length; j++)
                {
                    char letter = line[j];
                    int num = (int)letter;
                    if (num > 47 && num < 58)
                    {
                        ph2 = "";
                        ph2 = ph2 + letter;
                        c1 = j;
                        break;
                    }
                }

                for (int j = 0; j < numerals.Length; j++)
                {

                    if (line.Contains(numerals[j]))
                    {
                        fsv.Add(j + 1);
                        fbv.Add(line.IndexOf(numerals[j]));


                        fsv.Add(j + 1);
                        fbv.Add(line.LastIndexOf(numerals[j]));

                    }

                }


                for (int j = 0; j < fbv.Count; j++)
                {
                    if (fbv[j] < c2s)
                    {
                        c2s = fbv[j];
                        c2 = fsv[j];
                    }

                    if (fbv[j] > c3s)
                    {
                        
                        c3s = fbv[j];
                        c3 = fsv[j];

                    }
                }




                if ((c1 < c2s) || (c2s == 1000))
                {
                    ph = ph + ph2;
                }
                else
                {

                    ph = ph + c2.ToString();
                }

                c1 = 0;
                ph2 = "";
                ph3 = "";



                for (int k = line.Length - 1; k >= 0; k--)
                {

                    char l2 = line[k];
                    int n2 = (int)l2;
                    if (n2 > 47 && n2 < 58)
                    {
                        ph3 = "";
                        ph3 = ph3 + l2;
                        c1 = k;
                        break;
                    }
                }


                if ((c1 > c3s) || (c3s == -1))
                {
                    ph = ph + ph3;
                }
                else
                {
                    
                    ph = ph + c3.ToString();

                }

                Console.WriteLine((i+1) + ") " + ph);
                total += int.Parse(ph);
                ph = "";

               
            }

            Console.WriteLine(total);
            Console.ReadKey();
        }
    }

}

