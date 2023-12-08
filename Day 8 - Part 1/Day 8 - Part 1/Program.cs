using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Day_8___Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> vals = new List<string>();

            using(StreamReader sr  = new StreamReader("test.txt"))
            {
                while(!sr.EndOfStream)
                {
                    vals.Add(sr.ReadLine());
                }
            }

            string inst = vals[0]; // short for instructions
            List<string> nodes = new List<string>();
            List<string> newnode = new List<string>();
            List<string> starts = new List<string>();

            for (int i = 2; i < vals.Count; i++)
            {
                string[] split = vals[i].Split('=');
                nodes.Add(split[0].Trim());
                newnode.Add(split[1].Trim());
            }

            int total = 0;
            int truetotal = 0;

            int m = 0;
            int store = 0;

            string current = "AAA";

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

                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i] == current)
                    {
                        string temp = newnode[i];
                        temp = temp.Substring(1, temp.Length - 2);
                        string[] split = temp.Split(',');
                        current = split[store].Trim();
                        break;
                    }
                }

                if (current == "ZZZ")
                {
                    break;
                }

                m++;
            }

            Console.WriteLine(total);

            Console.ReadKey();
        }
    }
}
