using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        public static void Input(out int x0, out int y0)
        {
            Console.Clear();
            Console.Write("Введите температуру (от 0 до 40 градусов): \n>> ");
            x0 = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nВведите влажность (от 40 до 90%): \n>> ");
            y0 = Convert.ToInt32(Console.ReadLine());
        }
        public static void Task()
        {
            //Console.WriteLine(");
            while (true)
            {
                try
                {
                    
                    int x0, y0;
                    Input(out x0, out y0);
                    if (x0 < 0 || x0 > 40 || y0 < 40 || y0 > 90)
                    {
                        Console.WriteLine("Ошибка. Температура должна быть в диапазонe от 0 до 40. Влажность от 40 до 90");
                        Console.WriteLine("\nЧтобы ввести новые значения, нажмите любую клавишу.");
                        Console.ReadKey();
                        Input(out x0, out y0);
                    }
                    function fi = new function(x0, y0);
                    fi.Result();
                    Console.WriteLine("Чтобы ввести новые значения, нажмите любую клавишу.");
                    Console.ReadLine();
                    Console.WriteLine("");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Нужно вводить числа!");
                }
            }
        }
        static void Main(string[] args)
        {
            Task();
        }
    }
}
