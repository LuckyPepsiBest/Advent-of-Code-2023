using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day_9___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool alldone = false;


            List<string> AllValueStored = new List<string>();

            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while (!sr.EndOfStream)
                {
                    AllValueStored.Add(sr.ReadLine());
                }
            }

            List<List<int>> listOLists = new List<List<int>>();

            List<int> total = new List<int>();

            List<int> IntsGoingInLists = new List<int>();
            List<int> temp = new List<int>();
            List<int> temp1 = new List<int>();
            List<int> temp2 = new List<int>();
            List<int> temp3 = new List<int>();
            List<int> temp4 = new List<int>();
            List<int> temp5 = new List<int>();
            List<int> temp6 = new List<int>();
            List<int> temp7 = new List<int>();
            List<int> temp8 = new List<int>();
            List<int> temp9 = new List<int>();
            List<int> temp10 = new List<int>();
            List<int> temp11 = new List<int>();
            List<int> temp12 = new List<int>();
            List<int> temp13 = new List<int>();
            List<int> temp14 = new List<int>();
            List<int> temp15 = new List<int>();
            List<int> temp16 = new List<int>();
            List<int> temp17 = new List<int>();
            List<int> temp18 = new List<int>();
            List<int> temp19 = new List<int>();
            List<int> temp20 = new List<int>();
            List<int> temp21 = new List<int>();
            List<int> temp22 = new List<int>();

            int b = 0;
            int total2 = 0;

            for (int i = 0; i < AllValueStored.Count; i++)
            {

                clearing(listOLists, IntsGoingInLists, temp, temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, temp13, temp14, temp15, temp16, temp17, temp18, temp19, temp20, temp21, temp22);

                total2 = 0;
                b = 0;
                alldone = false;

                string line = AllValueStored[i];
                string[] indiv = line.Split(' ');

                for (int j = 0; j < indiv.Length; j++)
                {
                    IntsGoingInLists.Add(int.Parse(indiv[j]));
                    temp.Add(int.Parse(indiv[j]));
                }

                listOLists.Add(IntsGoingInLists);

                while (alldone == false)
                {
                    switch (b)
                    {
                        case 1:
                            alldone = test(temp1, temp, listOLists);
                            break;
                        case 2:
                            alldone = test(temp2, temp1, listOLists);
                            break;
                        case 3:
                            alldone = test(temp3, temp2, listOLists);
                            break;
                        case 4:
                            alldone = test(temp4, temp3, listOLists);
                            break;
                        case 5:
                            alldone = test(temp5, temp4, listOLists);
                            break;
                        case 6:
                            alldone = test(temp6, temp5, listOLists);
                            break;
                        case 7:
                            alldone = test(temp7, temp6, listOLists);
                            break;
                        case 8:
                            alldone = test(temp8, temp7, listOLists);
                            break;
                        case 9:
                            alldone = test(temp9, temp8, listOLists);
                            break;
                        case 10:
                            alldone = test(temp10, temp9, listOLists);
                            break;
                        case 11:
                            alldone = test(temp11, temp10, listOLists);
                            break;
                        case 12:
                            alldone = test(temp12, temp11, listOLists);
                            break;
                        case 13:
                            alldone = test(temp13, temp12, listOLists);
                            break;
                        case 14:
                            alldone = test(temp14, temp13, listOLists);
                            break;
                        case 15:
                            alldone = test(temp15, temp14, listOLists);
                            break;
                        case 16:
                            alldone = test(temp16, temp15, listOLists);
                            break;
                        case 17:
                            alldone = test(temp17, temp16, listOLists);
                            break;
                        case 18:
                            alldone = test(temp18, temp17, listOLists);
                            break;
                        case 19:
                            alldone = test(temp19, temp18, listOLists);
                            break;
                        case 20:
                            alldone = test(temp20, temp19, listOLists);
                            break;
                        case 21:
                            alldone = test(temp21, temp20, listOLists);
                            break;
                        case 22:
                            alldone = test(temp22, temp21, listOLists);
                            break;

                    }
                    b++;
                }

                //need to find new value
                b--;

                while (true)
                {

                    switch (b)
                    {
                        case 0:
                            total2 = temp[0] - total2;
                            b--;
                            break;
                        case 1:
                            total2 = temp1[0] - total2;
                            b--;
                            break;
                        case 2:
                            total2 = temp2[0] - total2;
                            b--;
                            break;
                        case 3:
                            total2 = temp3[0] - total2;
                            b--;
                            break;
                        case 4:
                            total2 = temp4[0] - total2;
                            b--;
                            break;
                        case 5:
                            total2 = temp5[0] - total2;
                            b--;
                            break;
                        case 6:
                            total2 = temp6[0] - total2;
                            b--;
                            break;
                        case 7:
                            total2 = temp7[0] - total2;
                            b--;
                            break;
                        case 8:
                            total2 = temp8[0] - total2;
                            b--;
                            break;
                        case 9:
                            total2 = temp9[0] - total2;
                            b--;
                            break;
                        case 10:
                            total2 = temp10[0] - total2;
                            b--;
                            break;
                        case 11:
                            total2 = temp11[0] - total2;
                            b--;
                            break;
                        case 12:
                            total2 = temp12[0] - total2;
                            b--;
                            break;
                        case 13:
                            total2 = temp13[0] - total2;
                            b--;
                            break;
                        case 14:
                            total2 = temp14[0] - total2;
                            b--;
                            break;
                        case 15:
                            total2 = temp15[0] - total2;
                            b--;
                            break;
                        case 16:
                            total2 = temp16[0] - total2;
                            b--;
                            break;
                        case 17:
                            total2 = temp17[0] - total2;
                            b--;
                            break;
                        case 18:
                            total2 = temp18[0] - total2;
                            b--;
                            break;
                        case 19:
                            total2 = temp19[0] - total2;
                            b--;
                            break;
                        case 20:
                            total2 = temp20[0] - total2;
                            b--;
                            break;
                        case 21:
                            total2 = temp21[0] - total2;
                            b--;
                            break;
                        case 22:
                            total2 = temp22[0] - total2;
                            b--;
                            break;

                    }

                    if (b < 0)
                    {
                        total.Add(total2);
                        break;
                    }
                }
            }

            total2 = 0;

            for (int i = 0; i < total.Count; i++)
            {
                total2 += total[i];
            }


            Console.WriteLine(total2);
            Console.ReadKey();
        }

        static bool test(List<int> range, List<int> ph, List<List<int>> listOLists)
        {
            int a = 0;

            for (int k = 0; k < ph.Count - 1; k++)
            {
                range.Add(ph[k + 1] - ph[k]);
            }

            for (int i = 0; i < range.Count; i++)
            {
                if (range[i] != 0)
                {
                    break;
                }
                else
                {
                    a++;
                }
            }

            return a == range.Count;
        }

        static void clearing(List<List<int>> listOLists, List<int> IntsGoingInLists, List<int> temp, List<int> temp1, List<int> temp2, List<int> temp3, List<int> temp4, List<int> temp5, List<int> temp6, List<int> temp7, List<int> temp8, List<int> temp9, List<int> temp10, List<int> temp11, List<int> temp12, List<int> temp13, List<int> temp14, List<int> temp15, List<int> temp16, List<int> temp17, List<int> temp18, List<int> temp19, List<int> temp20, List<int> temp21, List<int> temp22)
        {
            listOLists.Clear();
            IntsGoingInLists.Clear();
            temp.Clear();
            temp1.Clear();
            temp2.Clear();
            temp3.Clear();
            temp4.Clear();
            temp5.Clear();
            temp6.Clear();
            temp7.Clear();
            temp8.Clear();
            temp9.Clear();
            temp10.Clear();
            temp11.Clear();
            temp12.Clear();
            temp13.Clear();
            temp14.Clear();
            temp15.Clear();
            temp16.Clear();
            temp17.Clear();
            temp18.Clear();
            temp19.Clear();
            temp20.Clear();
            temp21.Clear();
            temp22.Clear();
        }
    }
}
