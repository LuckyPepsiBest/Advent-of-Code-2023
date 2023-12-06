using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using System.Windows.Markup;
using System.Security.Cryptography;

namespace Day_6___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<long> time = new List<long>();
            List<long> distance = new List<long>();
            string line = "";
            string line2 = "";
            string time2 = "";
            string distance2 = "";
            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while (!sr.EndOfStream)
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
                                time2 = time2 + vals[i];
                            }
                        }
                        time.Add(long.Parse(time2));
                    }
                    else if (line2 == "Distance")
                    {
                        for (int i = 0; i < vals.Length; i++)
                        {
                            if (vals[i] == "") ;
                            else
                            {
                                distance2 = distance2 + vals[i];
                            }
                        };
                        distance.Add(long.Parse(distance2));
                    }
                }
            }
            long total = 0;
            long ph = 0;

            for (int j = 0; j < time[0]; j++)
            {
                ph = j * (time[0] - j);
                if (ph > distance[0])
                {
                    total++;
                }
            }


            Console.WriteLine(total);
            Console.ReadLine();
        }
    }
}
