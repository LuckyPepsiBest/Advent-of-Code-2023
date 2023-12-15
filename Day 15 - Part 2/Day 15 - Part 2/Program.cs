using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "";

            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                }
            }

            List<(string label, int strength)>[] boxes = new List<(string label, int strength)>[256];

            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new List<(string label, int strength)>();
            }



            string[] steps = str.Split(',');

            int total = 0;
            int current = 0;


            for (int i = 0; i < steps.Length; i++) //HASH algorithm
            {
                bool check = true;
                current = 0;
                str = "";
                for (int j = 0; j < steps[i].Length; j++)
                {
                    if (steps[i][j] == '=')
                    {
                        if (boxes[current] == null) { check = true; }
                        else
                        {
                            for (int k = 0; k < boxes[current].Count; k++)
                            {
                                if (boxes[current][k].label == str)
                                {
                                    check = false;
                                    boxes[current][k] = (str, int.Parse(steps[i][j + 1].ToString()));
                                    break;
                                }
                            }
                        }

                        if (check)
                        {
                            boxes[current].Add((str, int.Parse(steps[i][j + 1].ToString())));
                        }
                    }
                    else if (steps[i][j] == '-')
                    {
                        for (int k = 0; k < boxes[current].Count; k++)
                        {
                            if (boxes[current][k].label == str)
                            {
                                boxes[current].Remove(boxes[current][k]);
                                break;
                            }
                        }
                    }
                    else
                    {
                        current += (char)steps[i][j];
                        current *= 17;
                        current = current % 256;
                        str = str + (char)steps[i][j];
                    }


                }
            }

            for (int i = 0; i < boxes.Length; i++)
            {
                for (int j = 0; j < boxes[i].Count; j++)
                {
                    total += (1 + i) * (1 + j) * boxes[i][j].strength;
                }
            }

            Console.WriteLine(total);

            Console.ReadKey();
        }
    }
}
