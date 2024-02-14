using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class function
    {
        int x0, y0;
        public function(int x0, int y0)
        {
            this.x0 = x0;
            this.y0 = y0;
        }
        //температура
        public double Cold()//холодно
        {
            if (x0 >= 0 & x0 <= 10) return (-0.1) * x0 + 1;
            if (x0 > 10) return 0;
            else return 0;
        }
        public double Warm()//тепло
        {
            if (x0 < 10 || x0 > 25) return 0;
            if (x0 >= 15 && x0 <= 20) return 1;
            if (x0 > 10 && x0 < 15) return 0.2 * x0 - 2;
            if (x0 > 20 && x0 <= 25) return (-0.2) * x0 + 5;
            return 0;
        }
        public double Hot()//жарко
        {
            if (x0 < 25) return 0;
            if (x0 > 25 && x0 <= 40) return 0.2 * x0 - 5;
            if (x0 > 30) return 1;
            return 0;
        }

        //влажность
        public double Low()//низкая влажность
        {
            if (y0 >= 40 && y0 <= 50) return (-0.1) * y0 + 5;
            if (y0 > 50) return 0;
            return 0;
        }
        public double Middle()//средняя/оптимальная влажность
        {
            if (y0 < 50 || y0 > 70) return 0;
            if (y0 <= 65 && y0 >= 55) return 1;
            if (y0 > 50 && y0 < 55) return 0.2 * y0 - 10;
            if (y0 > 65 && y0 <= 70) return (-0.2) * y0 + 14;
            return 0;
        }
        public double High()//высокая влажность
        {
            if (y0 < 70) return 0;
            if (y0 >= 80 & y0 <= 90) return 1;
            if (y0 > 70 & y0 < 80) return (0.1) * y0 - 7;

            return 0;
        }

        private int Weather_Comfort()
        {
            if (!(Hot() == 0) && !(Low() == 0)) return 1;
            if (!(Cold() == 0) && !(Middle() == 0)) return 1;
            if (!(Warm() == 0) && !(High() == 0)) return 1;
            else return 0;
        }
        private int Weather_Good()
        {
            if (!(Warm() == 0) && !(Middle() == 0)) return 1;
            if (!(Warm() == 0) && !(Low() == 0)) return 1;
            if (!(Hot() == 0) && !(Middle() == 0)) return 1;
            else return 0;
        }

        private int Weather_Bad()
        {
            if (!(Cold() == 0) && !(High() == 0)) return 1;
            if (!(Cold() == 0) && !(Low() == 0)) return 1;
            if (!(Hot() == 0) && !(High() == 0)) return 1;
            else return 0;
        }

        public void Result()
        {
            if (Weather_Bad() == 1) Console.WriteLine("Погода плохая");
            if (Weather_Good() == 1) Console.WriteLine("Погода комфортная");
            if (Weather_Comfort() == 1) Console.WriteLine("Погода хорошая");


        }
    }
}
