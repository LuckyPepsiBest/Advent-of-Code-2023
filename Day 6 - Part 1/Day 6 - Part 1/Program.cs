using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using System.Windows.Markup;

namespace Day_6___Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> time = new List<int>();
            List<int> distance = new List<int>();
            string line = "";
            string line2 = "";
            using(StreamReader sr = new StreamReader("txt.txt"))
            {
                while(!sr.EndOfStream)
                {
                    
                    line = sr.ReadLine();
                    int colon = line.IndexOf(':');
                    line2 = line.Substring(0, colon);
                    colon++;
                    line = line.Substring(colon).Trim();
                    string[] vals = line.Split(' ');
                    if (line2 == "Time")
                    {
                        for (int i = 0; i < vals.Length; i++)
                        {
                            if (vals[i] == "") ;
                            else
                            {
                                time.Add(int.Parse(vals[i].Trim()));
                            }
                        }
                    }
                    else if (line2 == "Distance")
                    {
                        for (int i = 0; i < vals.Length; i++)
                        {
                            if (vals[i] == "") ;
                            else
                            {
                                distance.Add(int.Parse(vals[i].Trim()));
                            }
                        }
                    }
                }
            }
            int total = 0;
            int next = 1;
            for (int i = 0; i < time.Count; i++)
            {
                total = 0;
                for (int j = 0; j < time[i]; j++)
                {
                    if (j * (time[i] - j) > distance[i])
                    {
                        total++;
                    }
                }
                next = total * next;
            }

            Console.WriteLine(next);
            Console.ReadLine();
        }
    }
}
