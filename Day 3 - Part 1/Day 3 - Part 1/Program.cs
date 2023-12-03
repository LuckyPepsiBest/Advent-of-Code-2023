using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_3___Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            using(StreamReader sr = new StreamReader("txt.txt"))
            {
                while(!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
            }

            int total = 0;
            string num = "";
            int m = 1;
            int n = 1;

            for (int i = 0; i < list.Count; i++)
            {
                string line = list[i];

                for (int j = 0; j < line.Length; j++)
                {

                    if ("1234567890.".Contains(line[j])) ;

                    else
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
                        if(num != "")
                        {
                            Console.WriteLine(num);
                            total += int.Parse(num);
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
                            Console.WriteLine(num);
                            total += int.Parse(num);
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
                            Console.WriteLine(num);
                            total += int.Parse(num);
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
                            Console.WriteLine(num);
                            total += int.Parse(num);
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
                            Console.WriteLine(num);
                            total += int.Parse(num);
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
                            Console.WriteLine(num);
                            total += int.Parse(num);
                        }

                        m = 1;
                        num = "";

                    }
                }
            }

            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
