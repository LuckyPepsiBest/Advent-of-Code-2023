using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_3___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<int> gearrat = new List<int>();

            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
            }

            int total = 0;
            string num = "";
            int m = 1;
            

            for (int i = 0; i < list.Count; i++)
            {
                int n = 1;
                gearrat.Clear();
                string line = list[i];

                for (int j = 0; j < line.Length; j++)
                {
                     n = 1;
                    gearrat.Clear();

                    if ("*".Contains(line[j]))  // only runs if the symbol is star
                    {

                        for (int k = j; k >= 0; k--) // checking if number on left
                        {
                            if ("1234567890".Contains(line[k]))
                            {
                                num = num.PadLeft(m, line[k]);
                                m++;
                            }
                            else if (".".Contains(line[k]))
                            {
                                break;
                            }
                        }
                        if (num != "")
                        {
                            gearrat.Add(int.Parse(num));
                        }

                        m = 1;
                        num = "";

                        for (int k = j; k < line.Length; k++) // checking if number on right
                        {
                            if ("1234567890".Contains(line[k]))
                            {
                                num = num + line[k];
                                m++;
                            }
                            else if (".".Contains(line[k]))
                            {
                                break;
                            }
                        }

                        if (num != "")
                        {
                            gearrat.Add(int.Parse(num));
                        }

                        m = 1;
                        num = "";

                        // checking numbers above --------------------------------

                        string line2 = list[i - 1];

                        if (line2[j] != '.')  // adds number above
                        {
                            num = num + line2[j];
                            m++;
                        }

                        for (int k = j + 1; k < line.Length; k++) // right numbers above exluding 1 above
                        {
                            if ("1234567890".Contains(line2[k]))
                            {
                                num = num + line2[k];
                                m++;
                            }
                            else if (".".Contains(line2[k]))
                            {
                                break;
                            }
                        }

                        if ((line2[j] == '.') && (num != ""))
                        {
                            gearrat.Add(int.Parse(num));
                            m = 1;
                            num = "";
                        }



                        for (int k = j - 1; k >= 0; k--) // right numbers above excluding 1 above
                        {
                            if ("1234567890".Contains(line2[k]))
                            {
                                num = num.PadLeft(m, line2[k]);
                                m++;
                            }
                            else if (".".Contains(line2[k]))
                            {
                                break;
                            }
                        }

                        if (num != "")
                        {
                            gearrat.Add(int.Parse(num));
                        }

                        m = 1;
                        num = "";

                        // checking numbers below --------------------------------

                        string line3 = list[i + 1];

                        if (line3[j] != '.')  // adds number below
                        {
                            num = num + line3[j];
                            m++;
                        }

                        for (int k = j + 1; k < line.Length; k++) // right numbers below exluding 1 below
                        {
                            if ("1234567890".Contains(line3[k]))
                            {
                                num = num + line3[k];
                                m++;
                            }
                            else if (".".Contains(line3[k]))
                            {
                                break;
                            }
                        }

                        if ((line3[j] == '.') && (num != ""))
                        {
                            gearrat.Add(int.Parse(num));
                            m = 1;
                            num = "";
                        }

                        for (int k = j - 1; k >= 0; k--) // right numbers below excluding 1 below
                        {
                            if ("1234567890".Contains(line3[k]))
                            {
                                num = num.PadLeft(m, line3[k]);
                                m++;
                            }
                            else if (".".Contains(line3[k]))
                            {
                                break;
                            }
                        }

                        if (num != "")
                        {
                            gearrat.Add(int.Parse(num));
                        }

                        m = 1;
                        num = "";

                    }
                    if (gearrat.Count == 2) // makes sure theres exactly 2 part numbers then multiplies together then adds.
                    {
                        foreach (int a in gearrat)
                        {
                            n = n * a;
                        }
                        total += n;
                        n = 1;
                        gearrat.Clear();
                        

                    }
                }
                
            }

            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
