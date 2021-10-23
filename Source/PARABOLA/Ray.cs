using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parabola
{
    class Ray
    {
       static private List<Point> arr;
       static double xMax, yMax, xMin, yMin, counter;
        public static void borders(double xMx, double yMx, double xMm, double yMm) //задает границы отображения
        {
        xMax = xMx;
        yMax = yMx;
        xMin = xMm;
        yMin = yMm;
        }
        public static void reflect (double x, double y, double alpha, double a, double b, double c) // отражает лучи
        {
            double x1;
            double y1;
            double alpha1;
            counter++;
            Point p = findXY(x, y, alpha, a, b, c, counter);
            x1 = p.x;
            y1 = p.y;

            Func cosat = cos(a, b, c, x1);
            Func perp = perpendic(cosat.k, x1, y1);

            double beta = Math.Atan(perp.k);
            if (beta<0)
            {
                beta = beta + Math.PI;
            }

            alpha1 = findCorner(alpha, beta);
        
            arr.Add(new Point(x, y));

            if (x1 >= xMax || x1 <= xMin || y1 >= yMax || y1 <= yMin|| counter>20)   //checking
            {
                arr.Add(cheaking(x, y, alpha, x1, y1));

                //arr.Add(new Point(x1, y1));
            }
            else
            {
                reflect(x1, y1, alpha1, a, b, c);
            }
        }

        public static List<Point> mainReflect(double x, double y, double alpha, double a, double b, double c) // получает значения из метода Main и вызывает метод reflect
        {
            counter = 0;
            arr = new List<Point>();
            reflect(x, y, alpha, a, b, c);
            return arr;
        }
        static Func rayToFunction(double x, double y, double alpha) // преобразует луч в функцию
        {
            double k = Math.Tan(alpha);
            double b = y - x * k;
            Func bL = new Func(k, b);
            return bL;
        }

        static double findCorner(double alpha, double beta) 
        {
            double alpha1 = (Math.PI * 2 - (alpha + ( Math.PI / 2 ) - beta)) - (Math.PI / 2) + beta;
            if (alpha1 < 0) { alpha1 += Math.PI * 2; }
            return alpha1;
        }

        static Point findXY(double x, double y, double alpha, double a, double b, double c, double counter) // возвращает x, y отраженного луча
        {
            if (Math.Abs(alpha - ((Math.PI * 3)/ 2)) < 0.001)
            {
                return new Point(x, yFromX(x, a, b, c));
            }
            else if(Math.Abs(alpha - Math.PI / 2) < 0.001 )
            {
                return new Point(x, yMax);
            }

         Func bl = rayToFunction(x, y, alpha);
         double disc = discr(a, (b-bl.k), (c-bl.b));
         double x1 = (-(b - bl.k) + Math.Sqrt(disc)) / (2 * a);
         double x2 = (-(b - bl.k) - Math.Sqrt(disc)) / (2 * a);
         double y1 = bl.k * x1 + bl.b;
         double y2 = bl.k * x2 + bl.b;
         if (counter == 1)
         {
             if (alpha > Math.PI)
             {
                 if (y1 < y2)
                 {
                     return new Point(x1, y1);
                 }
                 else
                 {
                     return new Point(x2, y2);
                 }
             }
             else
             {
                 if (y1 > y2)
                 {
                     return new Point(x1, y1);
                 }
                 else
                 {
                     return new Point(x2, y2);
                 }
             }
         }
         if (Math.Abs(x1 - x) < 0.001 || Math.Abs(y1 - y) < 0.001)
         {
             return new Point(x2, y2);
         }
         else
         {
             return new Point(x1, y1); 
         }

        }

        static double discr(double a, double b, double c)
        { 
        return Math.Pow(b,2)-(4*a*c);
        }
        static public double yFromX(double x, double a, double b, double c) // для данной функции фозвращает Y по Х
        {
            return (a * Math.Pow(x, 2) + x * b + c);
        }
        static double xFromY(double y, double k, double b)
        {
            return (y - b) / k;
        }

        public static Func perpendic(double k, double x, double y) // возвращает коэффициенты перпендикуляра
        {
            // (x,y) - точка пересечения
            double newK = (-1) / k;
            double newB = y - (newK * x);
            Func bl = new Func(newK, newB);
            return bl;

        }
        public static Func cos(double a, double b, double c, double x) // возвращает коэффициенты касательной для данной параболы
        {
            double y = a * Math.Pow(x, 2) + x * b + c;
            double k1 = x * a * 2 + b;
            double b1 = x*y + y;
            Func bL = new Func(k1, b1);
            return bL;
        }
        static Point cheaking(double x, double y, double alpha, double x1, double y1)
        {
            Point pt = new Point();
            if (x1 <= xMin)
            {
                pt = che1(x, y, alpha);
            }
            if(x1 >= xMax)
            {
                pt = che2(x, y, alpha);
            }
            if(y1 >= yMax)
            {
                pt = che3(x, y, alpha);
            }
            if(y1 <= yMin)
            {
                pt = che4(x, y, alpha);
            }
            if(counter>20)
            {
                pt.x = x1;
                pt.y = y1;
            }
            return pt;
        }
        static Point che1(double x, double y, double alpha)
        {
            Func f = rayToFunction(x, y, alpha);
            double y1 = yFromX(xMin, 0, f.k, f.b);
            return new Point(xMin, y1);
        }
        static Point che2(double x, double y, double alpha)
        {
            Func f = rayToFunction(x, y, alpha);
            double y1 = yFromX(xMax, 0, f.k, f.b);
            return new Point(xMax, y1);
        }
        static Point che3(double x, double y, double alpha)
        {
            Func f = rayToFunction(x, y, alpha);
            double x1 = xFromY( yMax, f.k, f.b);
            return new Point(x1, yMax);
        }
        static Point che4(double x, double y, double alpha)
        {
            Func f = rayToFunction(x, y, alpha);
            double x1 = xFromY(yMin, f.k, f.b);
            return new Point(x1, yMin);
        }
    } 
    public struct Point 
    {
        public double x;
        public double y;
        public Point(double p1, double p2) { x = p1; y = p2;}
    }
    public struct Func
    { 
        public double k;
        public double b;
        public Func(double p1, double p2) { 
            k = p1; 
            b = p2;
     } 
    }
  


}
