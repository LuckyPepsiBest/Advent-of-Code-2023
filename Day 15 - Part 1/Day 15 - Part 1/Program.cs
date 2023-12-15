using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15___Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "";

            using(StreamReader sr = new StreamReader("txt.txt"))
            {
                while(!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                }
            }

            string[] steps = str.Split(',');

            int total = 0;
            int current = 0;

            for (int i = 0; i < steps.Length; i++)  //HASH algorithm
            {
                current = 0;
                for (int j = 0; j < steps[i].Length; j++)
                {
                    current += (char)steps[i][j];
                    current *= 17;
                    current = current % 256;
                }
                total += current;
            }

            Console.WriteLine(total);

            Console.ReadKey();
        }
    }
}
