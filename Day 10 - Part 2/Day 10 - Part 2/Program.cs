using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Day_10___Part_2
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

            List<string> points = new List<string>();

            string line = list[0];
            int a = line.Length;
            int b = list.Count;
            char[,] map = new char[a, b];

            for (int i = 0; i < list.Count; i++)
            {
                line = list[i];
                for (int j = 0; j < line.Length; j++)
                {
                    map[j, i] = line[j];
                }
            }

            line = list[0];
            int n = 0;
            int m = 0;
            int oldn = 0;
            int oldm = 0;
            int olda = 0;
            int oldb = 0;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < line.Length; j++)
                {
                    if (map[j, i] == 'S')
                    {
                        a = j;
                        b = i;
                        n = j;
                        m = i;

                        //Console.WriteLine("S = " + j + i);
                    }
                }
            }
            map[a, b] = '|'; // Manually input what your S represents here.
            switch (map[a, b])
            {
                case '|':
                    oldb = b;
                    olda = a;
                    oldm = m;
                    oldn = n;
                    b++;
                    m--;
                    break;
                case '-':
                    oldb = b;
                    olda = a;
                    oldm = m;
                    oldn = n;
                    a++;
                    n--;
                    break;
                case 'L':
                    oldb = b;
                    olda = a;
                    oldm = m;
                    oldn = n;
                    b--;
                    n++;
                    break;
                case 'J':
                    oldb = b;
                    olda = a;
                    oldm = m;
                    oldn = n;
                    b--;
                    n--;
                    break;
                case '7':
                    oldb = b;
                    olda = a;
                    oldm = m;
                    oldn = n;
                    b++;
                    n--;
                    break;
                case 'F':
                    oldb = b;
                    olda = a;
                    oldm = m;
                    oldn = n;
                    b++;
                    n++;
                    break;

            }

            map[olda, oldb] = '#';
            map[oldn, oldm] = '#';

            points.Add(olda.ToString() + " " + oldb.ToString());
            points.Add(oldn.ToString() + " " + oldm.ToString());


            while (true)
            {
                nextPipe(map, ref a, ref b, ref olda, ref oldb);
                nextPipe(map, ref n, ref m, ref oldn, ref oldm);

                map[olda, oldb] = '#';
                map[oldn, oldm] = '#';


                if (oldn == olda && oldm == oldb)
                {
                    points.Add(olda.ToString() + " " + oldb.ToString());
                    break;
                }

                points.Add(olda.ToString() + " " + oldb.ToString());
                points.Add(oldn.ToString() + " " + oldm.ToString());
            }
            /*for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < line.Length; j++)
                {
                    Console.Write(map[j, i] + " ");
                }
                Console.WriteLine();
            }*/

            int moves = 0;
            bool flip = false;

            for (int i = 0; i < list.Count; i++)
            {
                flip = false;
                line = list[i];
                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];
                    if (points.Contains((j + " " + i).ToString()))
                    {
                        if ("S".Contains(c))
                        {
                            c = '|'; // Manually change to what S should be.
                        }
                        if ("|7F".Contains(c))
                        {
                            flip = !flip;
                        }
                    }
                    else
                    {
                        if (flip)
                        {
                            moves++;
                        }
                    }


                }
            }

            Console.WriteLine(moves);
            Console.ReadKey();
        }

        static void nextPipe(char[,] map, ref int a, ref int b, ref int olda, ref int oldb)
        {
            /*if (a == 31 && b == 25)
            {
                Console.WriteLine("");
            }
            */
            switch (map[a, b])
            {
                case '|':
                    if ((b + 1) == oldb)
                    {
                        oldb = b;
                        olda = a;
                        b--;
                    }
                    else if ((b - 1) == oldb)
                    {
                        oldb = b;
                        olda = a;
                        b++;
                    }
                    break;
                case '-':
                    if ((a - 1) == olda)
                    {
                        oldb = b;
                        olda = a;
                        a++;
                    }
                    else if ((a + 1) == olda)
                    {
                        oldb = b;
                        olda = a;
                        a--;
                    }
                    break;
                case 'L':
                    if ((b - 1) == oldb && a == olda)
                    {
                        oldb = b;
                        olda = a;
                        a++;
                    }
                    else if ((a + 1) == olda && b == oldb)
                    {
                        oldb = b;
                        olda = a;
                        b--;
                    }
                    break;
                case 'J':
                    if ((b - 1) == oldb && a == olda)
                    {
                        oldb = b;
                        olda = a;
                        a--;
                    }
                    else if ((a - 1) == olda && b == oldb)
                    {
                        oldb = b;
                        olda = a;
                        b--;
                    }
                    break;
                case '7':
                    if ((a - 1) == olda && b == oldb)
                    {
                        oldb = b;
                        olda = a;
                        b++;
                    }
                    else if ((b + 1) == oldb && a == olda)
                    {
                        oldb = b;
                        olda = a;
                        a--;
                    }
                    break;
                case 'F':
                    if ((a + 1) == olda && b == oldb)
                    {
                        oldb = b;
                        olda = a;
                        b++;
                    }
                    else if ((b + 1) == oldb && a == olda)
                    {
                        oldb = b;
                        olda = a;
                        a++;
                    }
                    break;

            }
        }
    }
}





