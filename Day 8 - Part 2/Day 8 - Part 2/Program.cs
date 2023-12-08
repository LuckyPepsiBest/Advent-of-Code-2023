using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Day_8___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> vals = new List<string>();

            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while (!sr.EndOfStream)
                {
                    vals.Add(sr.ReadLine());
                }
            }

            string inst = vals[0]; // short for instructions
            List<string> nodes = new List<string>();
            List<string> newnode = new List<string>();
            List<string> starts = new List<string>();
            List<long> totals = new List<long>();


            for (int i = 2; i < vals.Count; i++)
            {
                string[] split = vals[i].Split('=');
                nodes.Add(split[0].Trim());
                newnode.Add(split[1].Trim());
            }

            int total = 0;
            long truetotal = 1;

            int m = 0;
            int store = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Substring(2) == "A")
                {
                    starts.Add(nodes[i]);
                }
            }

            for (int i = 0; i < starts.Count; i++)
            {
                string current = starts[i];
                total = 0;
                m = 0;
                while (true)
                {
                    total++;

                    if (m == inst.Length)
                    {
                        m = 0;
                    }

                    switch (inst[m])
                    {
                        case 'L':
                            store = 0;
                            break;
                        case 'R':
                            store = 1;
                            break;
                    }

                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (nodes[j] == current)
                        {
                            string temp = newnode[j];
                            temp = temp.Substring(1, temp.Length - 2);
                            string[] split = temp.Split(',');
                            current = split[store].Trim();
                            break;
                        }
                    }

                    if (current.Substring(2) == "Z")
                    {
                        totals.Add(total);
                        break;
                    }

                    m++;
                }
            }

            for (int i = 0; i < totals.Count; i++)
            {
                truetotal = lcm(truetotal, totals[i]);
            }

            Console.WriteLine(truetotal);

            Console.ReadKey();
        }

        static long lcm(long a, long b)
        {
            (a, b) = a > b ? (a, b) : (b, a);

            for (long i = 1; i < b; i++)
            {
                if (a * i % b is 0)
                {
                    return i * a;
                }
            }
            return a * b;
        }
    }
}