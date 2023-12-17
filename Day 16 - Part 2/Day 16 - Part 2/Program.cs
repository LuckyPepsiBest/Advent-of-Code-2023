using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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

            List<int> stores = new List<int>();

            List<(int, int, char)> pointanddirect = new List<(int, int, char)>();
            pointanddirect.Add((0, 0, 'r'));

            List<(int, int)> cordsofreflection = new List<(int, int)>();
            cordsofreflection.Add((0, 0));
            List<(int, int)> oldcordsofreflection = new List<(int, int)>();
            oldcordsofreflection.Add((0, 0));

            int length = 2 * a + 2 * b;

            List<(int, int)> pointsforchecking = new List<(int, int)>();
            List<(int, int)> pointsforcheckingcomefrom = new List<(int, int)>();

            int m = 0;

            for (int i = 0; i < list[0].Length; i++)
            {
                pointsforchecking.Add((0, i));
                pointsforcheckingcomefrom.Add((-1, i));
            }
            for (int i = 0; i < list[0].Length; i++)
            {
                pointsforchecking.Add((list.Count - 1, i));
                pointsforcheckingcomefrom.Add((list.Count, i));
            }

            for (int i = 0; i < list.Count; i++)
            {
                pointsforchecking.Add((i, 0));
                pointsforcheckingcomefrom.Add((i , -1));
            }
            for (int i = 0; i < list.Count; i++)
            {
                pointsforchecking.Add((i, line.Length - 1));
                pointsforcheckingcomefrom.Add((i, line.Length));
            }

            char direction = 'r';

            for (int n = 0; n < length; n++)
            {
                total = 0;
                pointanddirect.Clear();
                cordsofreflection.Clear();
                oldcordsofreflection.Clear();

                cordsofreflection.Add((pointsforchecking[m].Item1, pointsforchecking[m].Item2));
                oldcordsofreflection.Add((pointsforcheckingcomefrom[m].Item1, pointsforcheckingcomefrom[m].Item2));
                direction = directionchoice(pointsforchecking[m], pointsforcheckingcomefrom[m]);
                pointanddirect.Add((pointsforcheckingcomefrom[m].Item1, pointsforcheckingcomefrom[m].Item2, direction));

                for (int i = 0; i < list.Count; i++)
                {
                    line = list[i];
                    for (int j = 0; j < line.Length; j++)
                    {
                        mirrosandempty[i, j] = line[j];
                        energised[i, j] = false;
                    }
                }

                while (cordsofreflection.Count > 0)
                {
                    for (int i = 0; i < cordsofreflection.Count; i++)
                    {
                        useless = check(cordsofreflection[i], cordsofreflection, mirrosandempty, energised, oldcordsofreflection[i], oldcordsofreflection, ref i, a, b, pointanddirect);
                    }
                }

                for (int i = 0; i < b; i++)
                {
                    for (int j = 0; j < a; j++)
                    {
                        if (energised[i, j])
                        {
                            total++;
                        }
                    }

                }
                stores.Add(total);
                m++;

            }

            total = stores[0];

            for (int i = 0; i < stores.Count; i++)
            {
                if (stores[i] > total)
                {
                    total = stores[i];
                }
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

                    if (oldpoint == tempformath1)
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
                    if (oldpoint.Item1 - point.Item1 != 0)
                    {
                        if (oldpoint.Item1 - point.Item1 == -1)
                        {
                            if (pointanddirect.Contains((point.Item1, point.Item2, 'u')))
                            {
                                cordsofreflection.RemoveAt(z);
                                oldcordsofreflection.RemoveAt(z);
                                z--;
                            }
                            else
                            {
                                cordsofreflection[z] = (point.Item1 + 1, point.Item2);
                                oldcordsofreflection[z] = point;
                                pointanddirect.Add((point.Item1, point.Item2, 'u'));
                            }
                        }
                        else if (oldpoint.Item1 - point.Item1 == 1)
                        {
                            if (pointanddirect.Contains((point.Item1, point.Item2, 'd')))
                            {
                                cordsofreflection.RemoveAt(z);
                                oldcordsofreflection.RemoveAt(z);
                                z--;
                            }
                            else
                            {
                                cordsofreflection[z] = (point.Item1 - 1, point.Item2);
                                oldcordsofreflection[z] = point;
                                pointanddirect.Add((point.Item1, point.Item2, 'd'));
                            }
                        }
                    }


                    else if (oldpoint.Item2 - point.Item2 != 0)
                    {
                        if (oldpoint.Item2 - point.Item2 == -1)
                        {
                            if (pointanddirect.Contains((point.Item1, point.Item2, 'r')))
                            {
                                cordsofreflection.RemoveAt(z);
                                oldcordsofreflection.RemoveAt(z);
                                z--;
                            }
                            else
                            {
                                cordsofreflection[z] = (point.Item1, point.Item2 + 1);
                                oldcordsofreflection[z] = point;
                                pointanddirect.Add((point.Item1, point.Item2, 'r'));
                            }
                        }
                        else if (oldpoint.Item2 - point.Item2 == 1)
                        {
                            if (pointanddirect.Contains((point.Item1, point.Item2, 'l')))
                            {
                                cordsofreflection.RemoveAt(z);
                                oldcordsofreflection.RemoveAt(z);
                                z--;
                            }
                            else
                            {
                                cordsofreflection[z] = (point.Item1, point.Item2 - 1);
                                oldcordsofreflection[z] = point;
                                pointanddirect.Add((point.Item1, point.Item2, 'l'));
                            }
                        }
                    }
                    break;
            }

            energised[point.Item1, point.Item2] = true;

            //mirrorsandspace[point.Item1, point.Item2] = '#';
            return false;
        }

        static char directionchoice((int, int) cordsofreflection, (int, int) oldcordsofreflection) // these names are wrong but i dont wanna fix
        {
            char direction = 'r';
            if (cordsofreflection.Item1 - oldcordsofreflection.Item1 != 0)
            {
                if (cordsofreflection.Item1 - oldcordsofreflection.Item1 == -1)
                {
                    direction = 'u';
                }
                else if (cordsofreflection.Item1 - oldcordsofreflection.Item1 == 1)
                {
                    direction = 'd';
                }
            }

            else if (cordsofreflection.Item2 - oldcordsofreflection.Item2 != 0)
            {
                if (cordsofreflection.Item2 - oldcordsofreflection.Item2 == -1)
                {
                    direction = 'r';
                }
                else if (cordsofreflection.Item2 - oldcordsofreflection.Item2 == 1)
                {
                    direction = 'l';
                }
            }

            return direction;
        }
    }
}