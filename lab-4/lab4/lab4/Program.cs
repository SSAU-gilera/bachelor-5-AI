using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        public static void Write(string s, bool x)
        {
            string writePath = @"C:\Users\Lera\Desktop\University\Study\Интеллект\lab4\1.txt";
            string text = "";
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(s[5 * i + j] + ",");
                        text = s[5 * i + j] + ",";
                        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                        {
                            sw.Write(text);
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.Write("\n");
                    }
                    Console.WriteLine();
                }
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.Write("\r\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (x) Console.WriteLine("Верно!\n");
            Console.WriteLine("");
        }

        public static void WritePerc(Perceptron p)
        {
            Console.WriteLine("\nВеса:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                    if (p.ves[5 * i + j] > 0)
                        Console.Write(" " + p.ves[5 * i + j] + " ");
                    else
                        Console.Write(p.ves[5 * i + j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("\nСмещение = " + p.porog);
            Console.WriteLine("\nСкорость обучения = " + p.izm + "\n");
        }

        public static string Train(Perceptron p, int t, string[] good, string[] bad)
        {
            int wrong = 0;
            int wrongfalse = 0;
            Console.WriteLine("Массивы для тренировки");
            //Write("Массивы для тренировки", true);
            int right = 0;
            int f = 0;
            bool x;
            for (int i = 0; i < t; i++)
            {
                if (i % 2 == 0)
                {
                    f = p.rnd.Next(52);
                    x = p.Activate(bad[f]);

                    //Write(bad[f], x);
                    if (p.Activate(bad[f]))
                    {
                        p.Decrese(bad[f]);
                        wrong++;
                    }
                    else
                    {
                        right++;
                    }
                }
                else
                {
                    f = p.rnd.Next(8);
                    x = p.Activate(good[f]);

                    //Write(good[f], x);
                    if (!p.Activate(good[f]))
                    {
                        p.Increse(good[f]);
                        wrongfalse++;
                    }
                    else
                    {
                        right++;
                    }
                }
            }
            string res = "Правильных = " + (right * 100 / t) + "%\n" + "Не распознал: " + wrongfalse +
                "\n" + "Ложных срабатываний: " + wrong;
            return res;
        }

        static void Main(string[] args)
        {
            string[] good = { "110110010011011", "110111010111011", "111011101011101",
                              "101110101110111", "111011001011101", "111010001011101",
                              "101110100110111", "101110100010111" };
            string[] bad = {  "111111111111110", "111111111111101", "111111111111011", "111111111110111", "111111111101111", "111111111011111",
                              "111111110111111", "111111101111111", "111111011111111", "111110111111111", "111101111111111", "111011111111111",
                              "110111111111111", "101111111111111", "011111111111111", "011111111111110", "101111111111101", "110111111111011",
                              "111011111110111", "111101111101111", "111110111011111", "111111010111111", "111111101110111", "111111011011111",
                              "111110111101111", "1111011111011111", "111011110111111","110111111101111", "101111111101111", "011111101111111",
                              "111101110111110", "111011111011101", "110111111111011", "111110101110111", "011101111101111", "111011111011101",
                              "011101110111111", "110101101111101", "011101011111011", "110110110111110", "111101101011111", "111000111111111",
                              "110111000111111", "101101111111000", "011101111101011", "000111111110010", "100111111110100", "110101111110011",
                              "111111000110111", "000001111101111", "001110111011111", "111111010110011"};

            Console.Write("Введите количество эпох = ");
            int epoch = Convert.ToInt32(Console.ReadLine());
            string trainingRes;
            Perceptron p = new Perceptron(15);
            trainingRes = Train(p, epoch, good, bad);
            Console.WriteLine("Массивы для проверки");
            //Write("Массивы для проверки", true);
            for (int j = 0; j < 10; j++)
            {
                string input = "";
                if (j % 10 != 0)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        input += p.rnd.Next(0, 2);
                    }
                }
                else
                {
                    if (j % 20 == 0)
                    {

                        input = bad[p.rnd.Next(bad.Length)];
                    }
                    else
                    {

                        input = good[p.rnd.Next(good.Length)];
                    }
                }
                Write(input, p.Activate(input));
            }
            Console.WriteLine("\n" + trainingRes + "\n");
            WritePerc(p);
            Console.ReadKey();
        }
    }

    class Perceptron
    {
        int res;
        public int[] ves;
        public int izm;
        public int porog;
        public Random rnd = new Random();

        public Perceptron(int f)
        {
            ves = new int[++f];
            for (int i = 0; i < f; i++)
                ves[i] = rnd.Next(6);
            res = 0;
            izm = 1;
            porog = 10;
        }

        override public string ToString()
        {
            string f = "";
            for (int i = 0; i < ves.Length; i++)
            {
                f += ves[i].ToString();
            }
            return f;
        }

        public void Increse(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (s[i] != '0')
                    ves[i] += izm;
        }

        public void Decrese(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (s[i] == '0')
                    ves[i] -= izm;
        }

        public bool Activate(string arr)
        {
            double res = 0;
            for (int i = 0; i < arr.Length; i++)
                res += ves[i] * arr[i];
            if (res >= porog)
                return true;
            else
                return false;
        }
    }
}
