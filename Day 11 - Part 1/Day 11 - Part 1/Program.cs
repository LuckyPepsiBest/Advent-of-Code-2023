using System;
using System.Collections.Generic;
using System.IO;

namespace Day_11___Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> list = new List<string>();

            List<(int, int)> galaxycoords = new List<(int, int)>();
            List<bool> nogalaxiesinthisrow = new List<bool>();//true means no galaxies
            List<bool> nogalaxiesinthiscol = new List<bool>();

            using (StreamReader sr = new StreamReader("txt.txt")) //reads file into string list: list
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());

                }
            }

            string line = list[0];

            char[,] points = new char[line.Length, list.Count]; //creatse then populates array with all points from file.

            for (int i = 0; i < line.Length; i++)
            {
                line = list[i];
                for (int j = 0; j < list.Count; j++)
                {
                    points[i, j] = line[j];
                }
            }

            int temp2 = 0;
            int temp = 0;
            line = list[0];

            for (int i = 0; i < list.Count; i++) //checks if the row has a galaxy, if not adds true to bool list, else adds false
            {
                temp = 0;
                for (int j = 0; j < line.Length; j++)
                {
                    if (points[i, j] == '#')
                    {
                        break;
                    }
                    else
                    {
                        temp++;
                    }
                }
                if (temp == line.Length)
                {
                    nogalaxiesinthisrow.Add(true);
                }
                else
                {
                    nogalaxiesinthisrow.Add(false);
                }
            }

            for (int i = 0; i < line.Length; i++) //checks if the col has a galaxy, if not adds true to bool list, else adds false
            {
                temp = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (points[j, i] == '#')
                    {
                        break;
                    }
                    else
                    {
                        temp++;
                    }
                }
                if (temp == line.Length)
                {
                    nogalaxiesinthiscol.Add(true);
                }
                else
                {
                    nogalaxiesinthiscol.Add(false);
                }
            }

            for (int i = 0; i < list.Count; i++) // Adds cords of galaxies to list: galaxy cords
            {
                for (int j = 0; j < line.Length; j++)
                {
                    if (points[i, j] == '#')
                    {
                        galaxycoords.Add((i, j));
                    }
                }
            }

            long total = 0;

            for (int i = 0; i < galaxycoords.Count; i++)
            {
                for (int j = 0; j < galaxycoords.Count; j++)
                {
                    long rowy = 0;
                    long coly = 0;
                    long spacecounter = 0;
                    rowy = Math.Abs(galaxycoords[j].Item1 - galaxycoords[i].Item1);


                    if (galaxycoords[j].Item1 > galaxycoords[i].Item1)
                    {
                        for (int k = galaxycoords[i].Item1; k < galaxycoords[j].Item1; k++)
                        {
                            if (nogalaxiesinthisrow[k])
                            {
                                spacecounter++;
                            }
                        }

                    }

                    else
                    {
                        for (int k = galaxycoords[j].Item1; k < galaxycoords[i].Item1; k++)
                        {
                            if (nogalaxiesinthisrow[k])
                            {
                                spacecounter++;
                            }
                        }

                    }


                    coly = Math.Abs(galaxycoords[j].Item2 - galaxycoords[i].Item2);

                    if (galaxycoords[j].Item2 > galaxycoords[i].Item2)
                    {
                        for (int k = galaxycoords[i].Item2; k < galaxycoords[j].Item2; k++)
                        {
                            if (nogalaxiesinthiscol[k])
                            {
                                spacecounter++;
                            }
                        }
                    }
                    else
                    {
                        for (int k = galaxycoords[j].Item2; k < galaxycoords[i].Item2; k++)
                        {
                            if (nogalaxiesinthiscol[k])
                            {
                                spacecounter++;
                            }
                        }
                    }


                    total += rowy + coly + spacecounter;
                    //check if inebetween row1 -> row2 && col1->col2 if there are any bits without a galaxy
                }
            }

            total /= 2;
            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}


