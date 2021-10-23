using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parabola
{
    class basicLine 
    {
        private double a, b, c;
        public basicLine(double A, double B, double C)
        {
            this.a = A;
            this.b = B; 
            this.c = C;
        }

        public double getA()
        {
            return this.a;
        }

        public double getB()
        {
            return this.b;
        }
        public double getC()
        {
            return this.c;
        }

        public void setA(double a)
        {
            this.a = a;
        }

        public double[][] Parabl(int xMin, int xMax) // возвращает массив точек в указаном диапазоне для данной прямой или параболы
        {
            double[][] cor = new double[2][];
            double[] xMass = new double[(xMax - xMin) * 10 + 1];
            double[] yMass = new double[(xMax - xMin) * 10 + 1];
            double x = xMin;
            
            for (int i = 0; i < xMass.Length; i++)
            {
                xMass[i] = x;
                yMass[i] = this.a * Math.Pow(x, 2) + x * this.b + this.c;
                x = x + 0.1;
            }
            cor[0] = xMass;
            cor[1] = yMass;
            return cor;
        }
        public double yFromX(double x) // для данной функции возвращает Y по Х
        { 
        return (this.a * Math.Pow(x, 2) + x*this.b + this.c);
        }
        
        public basicLine cos(double x ) // возвращает коэффициенты касательной для данной параболы
        {
            double y = this.a * Math.Pow(x, 2) + x * this.b + this.c;
            double k = x * this.a * 2 + this.b;
            double b = y - (k * x);

            basicLine bL = new basicLine(0, k, b);
            return bL;
        }
        public basicLine prelom(double k, double x, double y) // возвращает коэффициенты преломленного луча
        {
            // берет коэф. перпендикуляра
            double alpha = Math.Atan(k);
            double gamma = 90 - Math.Abs(2*alpha);           
            double newK = Math.Tan(gamma);
            double newB = y - (newK * x);
            basicLine bl = new basicLine(0, newK, newB);
            return bl;
        }
        public basicLine perpendic(double k, double x, double y) // возвращает коэффициенты перпендикуляра
        {         
            // (x,y) - точка пересечения
            double newK = (-1)/k;
            double newB = y - (newK * x);
            basicLine bl = new basicLine(0, newK, newB);
            return bl;

        }
        public double xTop()
        {
            return -(this.b / 2 * this.a);
        }
        public static basicLine findUrav (double x1, double y1, double x2, double y2)
        {
            double k = (y1-y2)/(x1-x2);
            double b = y1 - k * x1;
            return new basicLine(0, k, b);
        }
        public static Point nextPoint(basicLine bl, double x)
        {
            double x1;
            if (bl.b > 0)
            {
                x1 = x + 0.1;
            }
            else
            {
                x1 = x - 0.1;
            }
            double y1 = bl.b * x + bl.c;
            return new Point(x1, y1);
        }
    }
}
