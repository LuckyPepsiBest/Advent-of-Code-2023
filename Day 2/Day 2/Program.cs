using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Schema;

namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> values = new List<string>();
            List<int> blue = new List<int>();
            List<int> green = new List<int>();
            List<int> red = new List<int>();
            List<int> added = new List<int>();

            int red2 = 0;
            int blue2 = 0;
            int green2 = 0;
            int red3 = -1;
            int blue3 = -1;
            int green3 = -1;
            string line = "";
            string val = "";
            int split = 0;
            int l = 0;
            string nLine = "";
            bool complete = false;
            int total = 0;

            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while(!sr.EndOfStream)
                {
                    red3 = 0;
                    blue3 = 0;
                    green3 = 0;
                    complete = false;            
                    line = sr.ReadLine();

                    split = line.IndexOf(':');
                    split++;
                    line = line.Substring(split);

                    string[] cubes = line.Split(';');

                    for (int i = 0; i < cubes.Length; i++)
                    {
                        red2 = 0;
                        blue2 = 0;
                        green2 = 0;
                        nLine = cubes[i];
                        string[] tfinal = nLine.Split(',');
                        
                        for (int j = 0; j < tfinal.Length; j++)
                        {

                            int ph = tfinal[j].Length;
                            tfinal[j] = tfinal[j].Substring(0, ph);

                            val = tfinal[j].Trim();

                            string[] final = val.Split(' ');

                            
                            switch (final[1].Trim())
                            {
                                case "red":
                                    red2 = int.Parse(final[0]);
                                    break;
                                case "blue":
                                    blue2 = int.Parse(final[0]);
                                    break;
                                case "green":
                                    green2 = int.Parse(final[0]);
                                    break;
                            }
                            
                        }

                        if (red2 > red3)
                        {
                            red3 = red2;
                        }
                        if (blue2 > blue3)
                        {
                            blue3 = blue2;
                        }
                        if (green2 > green3)
                        {
                            green3 = green2;
                        }

                        
                    }

                    total += red3 * blue3 * green3;
                    Console.WriteLine(red3 + "         " + blue3 + "         " + green3);
                    Console.WriteLine(total);
                    

                }
            }


            Console.WriteLine();
            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
