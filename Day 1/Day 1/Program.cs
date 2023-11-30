using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string brackets = "";

            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while(!sr.EndOfStream)
                {
                    brackets = sr.ReadLine();
                }
            }

            int floor = 0;

            Console.WriteLine(brackets.Length);

            for (int i = 0; i < brackets.Length; i++)
            {
                switch (brackets[i])
                {
                    case '(':
                        floor += 1;
                        break;
                    case ')':
                        floor -= 1;
                        break;  
                }

                if (floor == -1)
                {
                    Console.WriteLine(i+1);
                    break;
                }
            }

            Console.WriteLine(floor);

            Console.ReadKey();
        }
    }
}
