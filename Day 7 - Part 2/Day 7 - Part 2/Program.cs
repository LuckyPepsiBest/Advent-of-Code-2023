using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Data.SqlTypes;

namespace Day_7___Part_1
{
    internal class Program
    { 

        static int m = 0;

        static void Main(string[] args)
        {
            int joke = 0;

            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
            }

            int temp = list.Count;

            string[] hand = new string[temp];
            int[] bid = new int[temp];

            string[] shand = new string[1000];

            for (int i = 0; i < list.Count; i++)
            {
                string[] line = list[i].Split(' ');
                hand[i] = line[0];
                bid[i] = int.Parse(line[1]);
            }

            List<string> high2 = new List<string>();
            List<string> one2 = new List<string>();
            List<string> two2 = new List<string>();
            List<string> three2 = new List<string>();
            List<string> full2 = new List<string>();
            List<string> four2 = new List<string>();
            List<string> five2 = new List<string>();

           


            int dupe = 0;
            string line2 = "";

            for (int i = 0; i < hand.Length; i++)
            {
                int A = 0;
                int K = 0;
                int Q = 0;
                int J = 0;
                int T = 0;
                int N = 0;
                int E = 0;
                int S = 0;
                int si = 0;
                int F = 0;
                int fo = 0;
                int th = 0;
                int tw = 0;
                line2 = hand[i];
                for (int j = 0; j < line2.Length; j++)
                {
                    switch (line2[j])
                    {
                        case 'A':
                            A++;
                            break;
                        case 'K':
                            K++;
                            break;
                        case 'Q':
                            Q++;
                            break;
                        case 'J':
                            J++;
                            break;
                        case 'T':
                            T++;
                            break;
                        case '9':
                            N++;
                            break;
                        case '8':
                            E++;
                            break;
                        case '7':
                            S++;
                            break;
                        case '6':
                            si++;
                            break;
                        case '5':
                            F++;
                            break;
                        case '4':
                            fo++;
                            break;
                        case '3':
                            th++;
                            break;
                        case '2':
                            tw++;
                            break;
                    }
                }

                List<int> temp5 = new List<int>();
                if (line2.Contains('J'))
                {
                    joke = joker(A, K, Q, J, T, N, E, S, si, F, fo, th, tw, temp5);
                }
                switch (joke)
                {
                    case 0:
                        A += J;
                        break;
                    case 1:
                        K += J;
                        break;
                    case 2:
                        Q += J;
                        break;
                    case 3:
                        T += J;
                        break;
                    case 4:
                        N += J;
                        break;
                    case 5:
                        E += J;
                        break;
                    case 6:
                        S += J;
                        break;
                    case 7:
                        si += J;
                        break;
                    case 8:
                        F += J;
                        break;
                    case 9:
                        fo += J;
                        break;
                    case 10:
                        th += J;
                        break;
                    case 11:
                        tw += J;
                        break;
                }

                J = 0;

                if ((A == 5) || (K == 5) || (Q == 5) || (J == 5) || (T == 5) || (N == 5) || (E == 5) || (S == 5) || (si == 5) || (F == 5) || (fo == 5) || (th == 5) || (tw == 5))
                {
                    five2.Add(hand[i]);
                }
                else if ((A == 4) || (K == 4) || (Q == 4) || (J == 4) || (T == 4) || (N == 4) || (E == 4) || (S == 4) || (si == 4) || (F == 4) || (fo == 4) || (th == 4) || (tw == 4))
                {
                    four2.Add(hand[i]);
                }
                else if (((A == 3) || (K == 3) || (Q == 3) || (J == 3) || (T == 3) || (N == 3) || (E == 3) || (S == 3) || (si == 3) || (F == 3) || (fo == 3) || (th == 3) || (tw == 3)) && ((A == 2) || (K == 2) || (Q == 2) || (J == 2) || (T == 2) || (N == 2) || (E == 2) || (S == 2) || (si == 2) || (F == 2) || (fo == 2) || (th == 2) || (tw == 2)))
                {
                    full2.Add(hand[i]);
                }
                else if ((A == 3) || (K == 3) || (Q == 3) || (J == 3) || (T == 3) || (N == 3) || (E == 3) || (S == 3) || (si == 3) || (F == 3) || (fo == 3) || (th == 3) || (tw == 3))
                {
                    three2.Add(hand[i]);
                }
                else if (pairCheck(A, K, Q, J, T, N, E, S, si, F, fo, th, tw))
                {
                    two2.Add(hand[i]);
                }
                else if ((A == 2) || (K == 2) || (Q == 2) || (J == 2) || (T == 2) || (N == 2) || (E == 2) || (S == 2) || (si == 2) || (F == 2) || (fo == 2) || (th == 2) || (tw == 2))
                {
                    one2.Add(hand[i]);
                }
                else
                {
                    high2.Add(hand[i]);
                }
            }

            //------------------------------------------------------------------------------------------------
            string[] high = new string[high2.Count];
            string[] one = new string[one2.Count];
            string[] two = new string[two2.Count];
            string[] three = new string[three2.Count];
            string[] full = new string[full2.Count];
            string[] four = new string[four2.Count];
            string[] five = new string[five2.Count];


            sort(high, high2);
            sort(one, one2);
            sort(two, two2);
            sort(three, three2);
            sort(full, full2);
            sort(four, four2);
            sort(five, five2);

            addMain(high, shand);
            addMain(one, shand);
            addMain(two, shand);
            addMain(three, shand);
            addMain(full, shand);
            addMain(four, shand);
            addMain(five, shand);

            int total = 0;

            for (int i = 0; i < shand.Length; i++)
            {
                for (int j = 0; j < hand.Length; j++)
                {
                    if (shand[i] == hand[j])
                    {
                        total += (i + 1) * bid[j];
                        break;
                    }
                }
            }

            Console.WriteLine(total);

            Console.ReadKey();
        }

        static bool pairCheck(int A, int K, int Q, int J, int T, int N, int E, int S, int si, int F, int fo, int th, int tw)
        {
            int[] vals = new int[13];
            vals[0] = A;
            vals[1] = K;
            vals[2] = Q;
            vals[3] = J;
            vals[4] = T;
            vals[5] = N;
            vals[6] = E;
            vals[7] = S;
            vals[8] = si;
            vals[9] = F;
            vals[10] = fo;
            vals[11] = th;
            vals[12] = tw;

            int pairs = 0;
            for (int i = 0; i < 13; i++)
            {
                if (vals[i] == 2)
                {
                    pairs++;
                }
            }


            return pairs == 2;
        }

        static void sort(string[] vals, List<string> vals2)
        {
            for (int i = 0; i < vals2.Count; i++)
            {
                vals[i] = vals2[i].Trim();
            }




            int t1 = 0;
            int t2 = 0;

            string line = "";
            string line2 = "";

            for (int k = 0; k < vals.Length; k++)
            {

                for (int i = 0; i < vals.Length; i++)
                {
                    if (i + 1 == vals.Length)
                    {
                        break;
                    }

                    line = vals[i];
                    line2 = vals[i + 1];
                    for (int j = 0; j < line.Length; j++)
                    {
                        switch (line[j])
                        {
                            case 'A':
                                t1 = 14;
                                break;
                            case 'K':
                                t1 = 13;
                                break;
                            case 'Q':
                                t1 = 12;
                                break;
                            case 'J':
                                t1 = 1;
                                break;
                            case 'T':
                                t1 = 10;
                                break;
                            default:
                                t1 = int.Parse(line[j].ToString());
                                break;
                        }
                        switch (line2[j])
                        {
                            case 'A':
                                t2 = 14;
                                break;
                            case 'K':
                                t2 = 13;
                                break;
                            case 'Q':
                                t2 = 12;
                                break;
                            case 'J':
                                t2 = 1;
                                break;
                            case 'T':
                                t2 = 10;
                                break;
                            default:
                                t2 = int.Parse(line2[j].ToString());
                                break;
                        }

                        if (t2 < t1)
                        {
                            vals[i] = line2;
                            vals[i + 1] = line;
                        }
                        else if (t2 > t1)
                        {
                            break;
                        }
                    }
                }
            }
        }

        static void addMain(string[] vals, string[] vals2)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                vals2[m] = vals[i];
                m++;
            }
        }

        static int joker(int A, int K, int Q, int J, int T, int N, int E, int S, int si, int F, int fo, int th, int tw, List<int> temp5)
        {
            temp5.Clear();
            temp5.Add(A);
            temp5.Add(K);
            temp5.Add(Q);
            temp5.Add(T);
            temp5.Add(N);
            temp5.Add(E);
            temp5.Add(S);
            temp5.Add(si);
            temp5.Add(F);
            temp5.Add(fo);
            temp5.Add(th);
            temp5.Add(tw);

            int highest = 0;
            int store = 0;

            for (int i = 0; i < temp5.Count; i++)
            {
                if (temp5[i] > highest)
                {
                    highest = temp5[i];
                    store = i;
                }
            }

            return store;

        }
    }
}



// 249119606 < x < 250577315