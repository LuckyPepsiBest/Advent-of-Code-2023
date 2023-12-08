using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_5___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> values = new List<string>();
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                while (!sr.EndOfStream)
                {
                    values.Add(sr.ReadLine());
                }
            }

            int se = 0;
            int s = 0;
            int f = 0;
            int w = 0;
            int l = 0;
            int t = 0;
            int h = 0;

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].Contains("seed-to-soil"))
                {
                    for (int j = 1; j < values.Count; j++)
                    {
                        if (values[i + j] == "")
                        {
                            break;
                        }
                        se++;
                    }
                }
                else if (values[i].Contains("soil-to-fertilizer"))
                {
                    for (int j = 1; j < values.Count; j++)
                    {
                        if (values[i + j] == "")
                        {
                            break;
                        }
                        s++;
                    }
                }
                else if (values[i].Contains("fertilizer-to-water"))
                {
                    for (int j = 1; j < values.Count; j++)
                    {
                        if (values[i + j] == "")
                        {
                            break;
                        }
                        f++;
                    }
                }
                else if (values[i].Contains("water-to-light"))
                {
                    for (int j = 1; j < values.Count; j++)
                    {
                        if (values[i + j] == "")
                        {
                            break;
                        }
                        w++;
                    }
                }
                else if (values[i].Contains("light-to-temperature"))
                {
                    for (int j = 1; j < values.Count; j++)
                    {
                        if (values[i + j] == "")
                        {
                            break;
                        }
                        l++;
                    }
                }
                else if (values[i].Contains("temperature-to-humidity"))
                {
                    for (int j = 1; j < values.Count; j++)
                    {
                        if (values[i + j] == "")
                        {
                            break;
                        }
                        t++;
                    }
                }
                else if (values[i].Contains("humidity-to-location"))
                {
                    for (int j = 1; j < values.Count; j++)
                    {
                        h++;
                        if (j + i + 1 == values.Count)
                        {
                            break;
                        }
                    }
                }
            }

            //Console.WriteLine(se + "     " + s + "     " + f + "     " + w + "     " + l + "     " + t + "     " + h);

            long[,] seed = new long[se, 3];
            long[,] soil = new long[s, 3];
            long[,] fert = new long[f, 3];
            long[,] water = new long[w, 3];
            long[,] light = new long[l, 3];
            long[,] temp = new long[t, 3];
            long[,] humid = new long[h, 3];


            for (int i = 2; i < values.Count; i++)
            {
                if ("seed-to-soil map:" == values[i]) // Populate array with seed to soil values
                {
                    for (int j = 0; j < se; j++)
                    {
                        string[] range = values[i + 1].Split(' ');
                        long first = long.Parse(range[0].Trim());
                        long second = long.Parse(range[1].Trim());
                        long length2 = long.Parse(range[2].Trim());

                        seed[j, 0] = first;
                        seed[j, 1] = second;
                        seed[j, 2] = length2;
                        i++;
                    }

                }

                // -------------------------------------------------------------------------------------

                if ("soil-to-fertilizer map:" == values[i]) // Populate array with soil to fert values
                {
                    for (int j = 0; j < s; j++)
                    {
                        string[] range = values[i + 1].Split(' ');
                        long first = long.Parse(range[0].Trim());
                        long second = long.Parse(range[1].Trim());
                        long length2 = long.Parse(range[2].Trim());

                        soil[j, 0] = first;
                        soil[j, 1] = second;
                        soil[j, 2] = length2;
                        i++;
                    }

                }

                // -------------------------------------------------------------------------------------

                if ("fertilizer-to-water map:" == values[i]) // Populate array with fertilizer to water values
                {
                    for (int j = 0; j < f; j++)
                    {
                        string[] range = values[i + 1].Split(' ');
                        long first = long.Parse(range[0].Trim());
                        long second = long.Parse(range[1].Trim());
                        long length2 = long.Parse(range[2].Trim());

                        fert[j, 0] = first;
                        fert[j, 1] = second;
                        fert[j, 2] = length2;
                        i++;
                    }

                }

                // -------------------------------------------------------------------------------------

                if ("water-to-light map:" == values[i]) // Populate array with water to light values
                {
                    for (int j = 0; j < w; j++)
                    {
                        string[] range = values[i + 1].Split(' ');
                        long first = long.Parse(range[0].Trim());
                        long second = long.Parse(range[1].Trim());
                        long length2 = long.Parse(range[2].Trim());

                        water[j, 0] = first;
                        water[j, 1] = second;
                        water[j, 2] = length2;
                        i++;
                    }

                }

                // -------------------------------------------------------------------------------------

                if ("light-to-temperature map:" == values[i]) // Populate array with light to temp values
                {
                    for (int j = 0; j < l; j++)
                    {
                        string[] range = values[i + 1].Split(' ');
                        long first = long.Parse(range[0].Trim());
                        long second = long.Parse(range[1].Trim());
                        long length2 = long.Parse(range[2].Trim());

                        light[j, 0] = first;
                        light[j, 1] = second;
                        light[j, 2] = length2;
                        i++;
                    }

                }

                // -------------------------------------------------------------------------------------

                if ("temperature-to-humidity map:" == values[i]) // Populate array with temp to humid values
                {
                    for (int j = 0; j < t; j++)
                    {
                        string[] range = values[i + 1].Split(' ');
                        long first = long.Parse(range[0].Trim());
                        long second = long.Parse(range[1].Trim());
                        long length2 = long.Parse(range[2].Trim());

                        temp[j, 0] = first;
                        temp[j, 1] = second;
                        temp[j, 2] = length2;
                        i++;
                    }

                }

                // -------------------------------------------------------------------------------------

                if ("humidity-to-location map:" == values[i]) // Populate array with humid to location values
                {
                    for (int j = 0; j < h; j++)
                    {
                        string[] range = values[i + 1].Split(' ');
                        long first = long.Parse(range[0].Trim());
                        long second = long.Parse(range[1].Trim());
                        long length2 = long.Parse(range[2].Trim());

                        humid[j, 0] = first;
                        humid[j, 1] = second;
                        humid[j, 2] = length2;
                        i++;
                    }

                }
            }

            sort(seed, se);
            sort(soil, s);
            sort(fert, f);
            sort(water, w);
            sort(light, l);
            sort(temp, t);
            sort(humid, h);


            List<long> seednum = new List<long>();
            List<long> location = new List<long>();
            List<long> allseednum = new List<long>();

            List<long> soilnum = new List<long>();
            List<long> fertnum = new List<long>();
            List<long> waternum = new List<long>();
            List<long> lightnum = new List<long>();
            List<long> tempnum = new List<long>();
            List<long> humidnum = new List<long>();


            string line = values[0];


            int ph = line.IndexOf(":");
            ph += 2;
            line = line.Substring(ph);
            string[] seedval = line.Split(' ');

            for (int i = 0; i < seedval.Length; i++)
            {
                seednum.Add(long.Parse(seedval[i].Trim()));
            }

            long next = 0;

            //range split


            for (int i = 0; i < seednum.Count; i += 2)
            {

                next = seednum[i];
                for (int j = 0; j < se; j++)
                {



                    if (seed[j, 1] > next)
                    {
                        if (seednum[i + 1] > seed[j, 2])
                        {
                            long temp5 = seednum[i] - seed[j, 1] + 1;

                            long temp3 = seednum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            seednum[i + 1] = temp3;
                            seednum.Add(temp4);
                            seednum.Add(temp5);
                        }
                    }

                    else if ((seed[j, 1] + seed[j, 2]) > next)
                    {
                        if (seednum[i + 1] > seed[j, 2])
                        {
                            long temp5 = seednum[i] - seed[j, 1] + 1;

                            long temp3 = seednum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            seednum[i + 1] = temp3;
                            seednum.Add(temp4);
                            seednum.Add(temp5);
                        }
                        long ph2 = next - seed[j, 1];
                        next = seed[j, 0] + ph2;


                        break;
                    }
                }
                soilnum.Add(next);
                soilnum.Add(seednum[i + 1]);
            }
            for (int i = 0; i < soilnum.Count; i += 2)
            {
                next = soilnum[i];
                for (int j = 0; j < s; j++)
                {


                    if (soil[j, 1] > next)
                    {
                        if (soilnum[i + 1] > soil[j, 2])
                        {
                            long temp5 = soilnum[i] - soil[j, 1] + 1;

                            long temp3 = soilnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            soilnum[i + 1] = temp3;
                            soilnum.Add(temp4);
                            soilnum.Add(temp5);
                        }
                    }
                    else if ((soil[j, 1] + soil[j, 2]) > next)
                    {
                        if (soilnum[i + 1] > soil[j, 2])
                        {
                            long temp5 = soilnum[i] - soil[j, 1] + 1;

                            long temp3 = soilnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            soilnum[i + 1] = temp3;
                            soilnum.Add(temp4);
                            soilnum.Add(temp5);
                        }
                        long ph2 = next - soil[j, 1];
                        next = soil[j, 0] + ph2;


                        break;
                    }
                }
                fertnum.Add(next);
                fertnum.Add(soilnum[i + 1]);
            }
            for (int i = 0; i < fertnum.Count; i += 2)
            {
                next = fertnum[i];
                for (int j = 0; j < f; j++)
                {

                    if (fert[j, 1] > next)
                    {
                        if (fertnum[i + 1] > fert[j, 2])
                        {
                            long temp5 = fertnum[i] - fert[j, 1] + 1;

                            long temp3 = fertnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            fertnum[i + 1] = temp3;
                            fertnum.Add(temp4);
                            fertnum.Add(temp5);
                        }
                    }
                    else if ((fert[j, 1] + fert[j, 2]) > next)
                    {
                        if (fertnum[i + 1] > fert[j, 2])
                        {
                            long temp5 = fertnum[i] - fert[j, 1] + 1;

                            long temp3 = fertnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            fertnum[i + 1] = temp3;
                            fertnum.Add(temp4);
                            fertnum.Add(temp5);
                        }

                        long ph2 = next - fert[j, 1];
                        next = fert[j, 0] + ph2;


                        break;
                    }
                }
                waternum.Add(next);
                waternum.Add(fertnum[i + 1]);
            }
            for (int i = 0; i < waternum.Count; i += 2)
            {
                next = waternum[i];
                for (int j = 0; j < w; j++)
                {


                    if (water[j, 1] > next)
                    {
                        if (waternum[i + 1] > water[j, 2])
                        {
                            long temp5 = waternum[i] - water[j, 1] + 1;

                            long temp3 = waternum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            waternum[i + 1] = temp3;
                            waternum.Add(temp4);
                            waternum.Add(temp5);
                        }
                    }
                    else if ((water[j, 1] + water[j, 2]) > next)
                    {
                        if (waternum[i + 1] > water[j, 2])
                        {
                            long temp5 = waternum[i] - water[j, 1] + 1;

                            long temp3 = waternum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            waternum[i + 1] = temp3;
                            waternum.Add(temp4);
                            waternum.Add(temp5);
                        }
                        long ph2 = next - water[j, 1];
                        next = water[j, 0] + ph2;


                        break;
                    }
                }
                lightnum.Add(next);
                lightnum.Add(waternum[i + 1]);
            }
            for (int i = 0; i < lightnum.Count; i += 2)
            {
                next = lightnum[i];
                for (int j = 0; j < l; j++)
                {


                    if (light[j, 1] > next)
                    {
                        if (lightnum[i + 1] > light[j, 2])
                        {
                            long temp5 = lightnum[i] - light[j, 1] + 1;

                            long temp3 = lightnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            lightnum[i + 1] = temp3;

                            lightnum.Add(temp4);
                            lightnum.Add(temp5);
                        }
                    }
                    else if ((light[j, 1] + light[j, 2]) > next)
                    {
                        if (lightnum[i + 1] > light[j, 2])
                        {
                            long temp5 = lightnum[i] - light[j, 1] + 1;

                            long temp3 = lightnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            lightnum[i + 1] = temp3;

                            lightnum.Add(temp4);
                            lightnum.Add(temp5);
                        }
                        long ph2 = next - light[j, 1];
                        next = light[j, 0] + ph2;


                        break;
                    }
                }
                tempnum.Add(next);
                tempnum.Add(lightnum[i + 1]);
            }
            for (int i = 0; i < tempnum.Count; i += 2)
            {
                next = tempnum[i];
                for (int j = 0; j < t; j++)
                {

                    if (temp[j, 1] > next)
                    {
                        if (tempnum[i + 1] > temp[j, 2])
                        {
                            long temp5 = tempnum[i] - temp[j, 1] + 1;

                            long temp3 = tempnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            tempnum[i + 1] = temp3;
                            tempnum.Add(temp4);
                            tempnum.Add(temp5);
                        }
                    }
                    else if ((temp[j, 1] + temp[j, 2]) > next)
                    {
                        if (tempnum[i + 1] > temp[j, 2])
                        {
                            long temp5 = tempnum[i] - temp[j, 1] + 1;

                            long temp3 = tempnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            tempnum[i + 1] = temp3;
                            tempnum.Add(temp4);
                            tempnum.Add(temp5);
                        }
                        long ph2 = next - temp[j, 1];
                        next = temp[j, 0] + ph2;


                        break;
                    }
                }
                humidnum.Add(next);
                humidnum.Add(tempnum[i + 1]);
            }
            for (int i = 0; i < humidnum.Count; i += 2)
            {
                next = humidnum[i];
                for (int j = 0; j < h; j++)
                {


                    if (humid[j, 1] > next)
                    {
                        if (humidnum[i + 1] > humid[j, 2])
                        {
                            long temp5 = humidnum[i] - humid[j, 1] + 1;

                            long temp3 = humidnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            humidnum[i + 1] = temp3;
                            humidnum.Add(temp4);
                            humidnum.Add(temp5);
                        }
                    }
                    else if ((humid[j, 1] + humid[j, 2]) > next)
                    {
                        if (humidnum[i + 1] > humid[j, 2])
                        {
                            long temp5 = humidnum[i] - humid[j, 1] + 1;

                            long temp3 = humidnum[i + 1] - temp5;
                            long temp4 = next + temp3;
                            humidnum[i + 1] = temp3;
                            humidnum.Add(temp4);
                            humidnum.Add(temp5);
                        }
                        long ph2 = next - humid[j, 1];
                        next = humid[j, 0] + ph2;


                        break;
                    }
                }
                location.Add(next);
                //location.Add(humidnum[i + 1]);
            }


            //location.Add(0);
            long smallest = location[0];
            for (int i = 0; i < location.Count; i++)
            {
                if (location[i] < smallest)
                {
                    smallest = location[i];
                }
            }

            Console.WriteLine(smallest);
            Console.ReadLine();
        }


        static void sort(long[,] sort, long x)
        {
            long ph = 0;
            long ph2 = 0;
            long ph3 = 0;
            long p1 = 0;
            long p2 = 0;
            long p3 = 0;
            long t1 = 0;
            long t2 = 0;

            for (int j = 0; j < x; j++)
            {

                for (int i = 0; i < x; i++)
                {
                    if (i + 1 == x)
                    {
                        break;
                    }
                    p1 = sort[i, 0];
                    p2 = sort[i, 1];
                    p3 = sort[i, 2];
                    ph = sort[i + 1, 0];
                    ph2 = sort[i + 1, 1];
                    ph3 = sort[i + 1, 2];

                    t1 = sort[i + 1, 1];
                    t2 = sort[i, 1];


                    if (t1 < t2)
                    {
                        sort[i, 0] = ph;
                        sort[i, 1] = ph2;
                        sort[i, 2] = ph3;
                        sort[i + 1, 0] = p1;
                        sort[i + 1, 1] = p2;
                        sort[i + 1, 2] = p3;
                    }
                }
            }
        }
    }
}
//seed, soil, fert, water, light, temp, humid


// <60944003



