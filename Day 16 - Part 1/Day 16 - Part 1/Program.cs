using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_16___Part_1
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

            int total = 0;

            string line = list[0];
            int a = line.Length;
            int b = list.Count;

            bool useless = false;

            char[,] mirrosandempty = new char[a, b];
            bool[,] energised = new bool[a, b];

            for (int i = 0; i < list.Count; i++)
            {
                line = list[i];
                for (int j = 0; j < line.Length; j++)
                {
                    mirrosandempty[i, j] = line[j];
                    energised[i, j] = false;
                }
            }

            energised[0, 0] = true;

            List<(int, int, char)> pointanddirect = new List<(int, int, char)>();
            pointanddirect.Add((0, 0, 'r'));

            List<(int, int)> cordsofreflection = new List<(int, int)>();
            cordsofreflection.Add((0, 0));
            List<(int, int)> oldcordsofreflection = new List<(int, int)>();
            oldcordsofreflection.Add((0, 0));

            while (cordsofreflection.Count > 0)
            {
                for (int i = 0; i < cordsofreflection.Count; i++)
                {
                    useless = check(cordsofreflection[i], cordsofreflection, mirrosandempty, energised, oldcordsofreflection[i], oldcordsofreflection, ref i, a, b, pointanddirect);
                }
            }

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (energised[i, j])
                    {
                        if (mirrosandempty[i, j] == '.')
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write(mirrosandempty[i, j]);
                        }

                        total++;
                    }
                    else
                    {
                        Console.Write(mirrosandempty[i, j]);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine(total);
            Console.ReadKey();
        }

        static bool check((int, int) point, List<(int, int)> cordsofreflection, char[,] mirrorsandspace, bool[,] energised, (int, int) oldpoint, List<(int, int)> oldcordsofreflection, ref int z, int a, int b, List<(int, int, char)> pointanddirect)
        {
            (int, int) tempformath1 = point;
            (int, int) tempformath2 = point;
            (int, int) tempformath3 = point;
            (int, int) tempformath4 = point;

            if (!(point.Item1 >= 0 && point.Item1 < a && point.Item2 >= 0 && point.Item2 < b))
            {
                cordsofreflection.RemoveAt(z);
                oldcordsofreflection.RemoveAt(z);
                z--;
                return false;
            }

            switch (mirrorsandspace[point.Item1, point.Item2])
            {
                case '|':
                    tempformath1 = (tempformath1.Item1, tempformath1.Item2 - 1);
                    tempformath2 = (tempformath2.Item1, tempformath2.Item2 + 1);
                    tempformath3 = (tempformath3.Item1 - 1, tempformath3.Item2);
                    tempformath4 = (tempformath4.Item1 + 1, tempformath4.Item2);
                    if (tempformath1 == oldpoint || tempformath2 == oldpoint && !pointanddirect.Contains((point.Item1, point.Item2, 'u')) && !pointanddirect.Contains((point.Item1, point.Item2, 'd')))
                    {
                        oldcordsofreflection[z] = point;
                        oldcordsofreflection.Add(point);
                        cordsofreflection[z] = tempformath4;
                        cordsofreflection.Add(tempformath3);
                        pointanddirect.Add((point.Item1, point.Item2, 'u'));
                        pointanddirect.Add((point.Item1, point.Item2, 'd'));
                    }
                    else if (pointanddirect.Contains((point.Item1, point.Item2, 'u')) || pointanddirect.Contains((point.Item1, point.Item2, 'd')))
                    {
                        cordsofreflection.RemoveAt(z);
                        oldcordsofreflection.RemoveAt(z);
                        z--;
                    }
                    else
                    {
                        if (tempformath3 == oldpoint && !pointanddirect.Contains((point.Item1, point.Item2, 'd')))
                        {
                            cordsofreflection[z] = tempformath4;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'd'));
                        }
                        else if (tempformath4 == oldpoint && !pointanddirect.Contains((point.Item1, point.Item2, 'u')))
                        {
                            cordsofreflection[z] = tempformath3;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'u'));
                        }
                    }
                    break;

                case '-':
                    tempformath1 = (tempformath1.Item1, tempformath1.Item2 - 1);
                    tempformath2 = (tempformath2.Item1, tempformath2.Item2 + 1);
                    tempformath3 = (tempformath3.Item1 - 1, tempformath3.Item2);
                    tempformath4 = (tempformath4.Item1 + 1, tempformath4.Item2);
                    if (tempformath3 == oldpoint || tempformath4 == oldpoint && !pointanddirect.Contains((point.Item1, point.Item2, 'l')) && !pointanddirect.Contains((point.Item1, point.Item2, 'r')))
                    {
                        oldcordsofreflection[z] = point;
                        oldcordsofreflection.Add(point);
                        cordsofreflection[z] = tempformath2;
                        cordsofreflection.Add(tempformath1);
                        pointanddirect.Add((point.Item1, point.Item2, 'l'));
                        pointanddirect.Add((point.Item1, point.Item2, 'r'));
                    }
                    else if (pointanddirect.Contains((point.Item1, point.Item2, 'l')) || pointanddirect.Contains((point.Item1, point.Item2, 'r')))
                    {
                        cordsofreflection.RemoveAt(z);
                        oldcordsofreflection.RemoveAt(z);
                        z--;
                    }
                    else
                    {
                        if (tempformath1 == oldpoint && !pointanddirect.Contains((point.Item1, point.Item2, 'r')))
                        {
                            cordsofreflection[z] = tempformath2;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'r'));
                        }
                        else if (tempformath2 == oldpoint && !pointanddirect.Contains((point.Item1, point.Item2, 'l')))
                        {
                            cordsofreflection[z] = tempformath1;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'l'));
                        }
                    }
                    break;

                case '/':
                    tempformath1 = (tempformath1.Item1, tempformath1.Item2 - 1);
                    tempformath2 = (tempformath2.Item1, tempformath2.Item2 + 1);
                    tempformath3 = (tempformath3.Item1 - 1, tempformath3.Item2);
                    tempformath4 = (tempformath4.Item1 + 1, tempformath4.Item2);

                    if (oldpoint == tempformath1)
                    {
                        if (pointanddirect.Contains((point.Item1, point.Item2, 'u')))
                        {
                            cordsofreflection.RemoveAt(z);
                            oldcordsofreflection.RemoveAt(z);
                            z--;
                        }
                        else
                        {
                            cordsofreflection[z] = tempformath3;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'u'));
                        }
                    }
                    else if (oldpoint == tempformath2)
                    {
                        if (pointanddirect.Contains((point.Item1, point.Item2, 'd')))
                        {
                            cordsofreflection.RemoveAt(z);
                            oldcordsofreflection.RemoveAt(z);
                            z--;
                        }
                        else
                        {
                            cordsofreflection[z] = tempformath4;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'd'));
                        }
                    }
                    else if (oldpoint == tempformath3)
                    {
                        if (pointanddirect.Contains((point.Item1, point.Item2, 'l')))
                        {
                            cordsofreflection.RemoveAt(z);
                            oldcordsofreflection.RemoveAt(z);
                            z--;
                        }
                        else
                        {
                            cordsofreflection[z] = tempformath1;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'l'));
                        }
                    }
                    else if (oldpoint == tempformath4)
                    {
                        if (pointanddirect.Contains((point.Item1, point.Item2, 'r')))
                        {
                            cordsofreflection.RemoveAt(z);
                            oldcordsofreflection.RemoveAt(z);
                            z--;
                        }
                        else
                        {
                            cordsofreflection[z] = tempformath2;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'r'));
                        }
                    }

                    break;


                case '\\':
                    tempformath1 = (tempformath1.Item1, tempformath1.Item2 - 1);
                    tempformath2 = (tempformath2.Item1, tempformath2.Item2 + 1);
                    tempformath3 = (tempformath3.Item1 - 1, tempformath3.Item2);
                    tempformath4 = (tempformath4.Item1 + 1, tempformath4.Item2);

                    if (point == (0, 0))
                    {
                        cordsofreflection[z] = (1, 0);
                        oldcordsofreflection[z] = point;
                        pointanddirect.Add((1, 0, 'd'));
                    }

                    else if (oldpoint == tempformath1)
                    {
                        if (pointanddirect.Contains((point.Item1, point.Item2, 'd')))
                        {
                            cordsofreflection.RemoveAt(z);
                            oldcordsofreflection.RemoveAt(z);
                            z--;
                        }
                        else
                        {
                            cordsofreflection[z] = tempformath4;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'd'));
                        }
                    }
                    else if (oldpoint == tempformath2)
                    {
                        if (pointanddirect.Contains((point.Item1, point.Item2, 'u')))
                        {
                            cordsofreflection.RemoveAt(z);
                            oldcordsofreflection.RemoveAt(z);
                            z--;
                        }
                        else
                        {
                            cordsofreflection[z] = tempformath3;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'u'));
                        }
                    }
                    else if (oldpoint == tempformath3)
                    {
                        if (pointanddirect.Contains((point.Item1, point.Item2, 'r')))
                        {
                            cordsofreflection.RemoveAt(z);
                            oldcordsofreflection.RemoveAt(z);
                            z--;
                        }
                        else
                        {
                            cordsofreflection[z] = tempformath2;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'r'));
                        }
                    }
                    else if (oldpoint == tempformath4)
                    {
                        if (pointanddirect.Contains((point.Item1, point.Item2, 'l')))
                        {
                            cordsofreflection.RemoveAt(z);
                            oldcordsofreflection.RemoveAt(z);
                            z--;
                        }
                        else
                        {
                            cordsofreflection[z] = tempformath1;
                            oldcordsofreflection[z] = point;
                            pointanddirect.Add((point.Item1, point.Item2, 'l'));
                        }
                    }
                    break;


                case '.':
                    /*if (point == (0, 0))
                    {
                        cordsofreflection[z] = (0, 1);
                        oldcordsofreflection[z] = point;
                        pointanddirect.Add((0, 1, 'l'));
                    }*/
                    if (point.Item1 - oldpoint.Item1 != 0)
                    {
                        if (point.Item1 - oldpoint.Item1 == 1)
                        {
                            if (pointanddirect.Contains((point.Item1, point.Item2, 'r')))
                            {
                                cordsofreflection.RemoveAt(z);
                                oldcordsofreflection.RemoveAt(z);
                                z--;
                            }
                            else
                            {
                                cordsofreflection[z] = (point.Item1 + 1, point.Item2);
                                oldcordsofreflection[z] = point;
                                pointanddirect.Add((point.Item1, point.Item2, 'r'));
                            }
                        }
                        else if (point.Item1 - oldpoint.Item1 == -1)
                        {
                            if (pointanddirect.Contains((point.Item1, point.Item2, 'l')))
                            {
                                cordsofreflection.RemoveAt(z);
                                oldcordsofreflection.RemoveAt(z);
                                z--;
                            }
                            else
                            {
                                cordsofreflection[z] = (point.Item1 - 1, point.Item2);
                                oldcordsofreflection[z] = point;
                                pointanddirect.Add((point.Item1, point.Item2, 'l'));
                            }
                        }
                    }


                    else if (point.Item2 - oldpoint.Item2 != 0)
                    {
                        if (point.Item2 - oldpoint.Item2 == 1)
                        {
                            if (pointanddirect.Contains((point.Item1, point.Item2, 'u')))
                            {
                                cordsofreflection.RemoveAt(z);
                                oldcordsofreflection.RemoveAt(z);
                                z--;
                            }
                            else
                            {
                                cordsofreflection[z] = (point.Item1, point.Item2 + 1);
                                oldcordsofreflection[z] = point;
                                pointanddirect.Add((point.Item1, point.Item2, 'u'));
                            }
                        }
                        else if (point.Item2 - oldpoint.Item2 == -1)
                        {
                            if (pointanddirect.Contains((point.Item1, point.Item2, 'd')))
                            {
                                cordsofreflection.RemoveAt(z);
                                oldcordsofreflection.RemoveAt(z);
                                z--;
                            }
                            else
                            {
                                cordsofreflection[z] = (point.Item1, point.Item2 - 1);
                                oldcordsofreflection[z] = point;
                                pointanddirect.Add((point.Item1, point.Item2, 'd'));
                            }
                        }
                    }
                    break;
                    //case '#':
                    cordsofreflection.RemoveAt(z);
                    oldcordsofreflection.RemoveAt(z);
                    return false;

            }


            energised[point.Item1, point.Item2] = true;
            energised[oldpoint.Item1, oldpoint.Item2] = true;
            //mirrorsandspace[point.Item1, point.Item2] = '#';
            return false;
        }
    }
}
//< 2523