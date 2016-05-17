using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruncCriteriaConsole;

namespace TruncCriteriaConsole
{
    struct interval
    {
        public double a;
        public double b;
    }
    static class OnedimensionalOptmization
    {

        public static interval Swan(double x0, double h, double[] Xk, double[] direction)
        {
            double a, b;
            double xl = x0 - h;
            double xr = x0 + h;
            double fl = Function.f(Xk, direction, xl);
            double fc = Function.f(Xk, direction, x0);
            double fr = Function.f(Xk, direction, xr);
            interval segment;
            segment.a = 0;
            segment.b = 0;

            if (fl >= fc && fc <= fr)
            {
                a = xl;
                b = xr;
                segment.a = a;
                segment.b = b;
                return segment;
            }

            if (fl <= fc && fc >= fr)
            {
                segment.a = 0;
                segment.b = 0;
                return segment;
            }

            if (fl >= fc && fc >= fr)
            {
                double pow = 2;
                a = x0;
                xl = xr;
                fl = fr;
                xr = x0 + pow * h;
                fr = Function.f(Xk, direction, xr);

                while (fl >= fr)
                {
                    pow *= 2;
                    if (pow > 2454542)
                    {
                        segment.a = 0;
                        segment.b = 0;
                        return segment;
                    }
                    a = xl;
                    xl = xr;
                    fl = fr;
                    xr = x0 + pow * h;
                    fr = Function.f(Xk, direction, xr);
                }
                b = xr;
                segment.a = a;
                segment.b = b;
                return segment;
            }
            if (fl <= fc && fc <= fr)
            {
                double pow = 2;
                b = x0;
                xr = xl;
                fr = fl;
                xl = x0 - pow * h;
                fl = Function.f(Xk, direction, xl);
                while (fl <= fr)
                {
                    pow *= 2;
                    if (pow > 2452458)
                    {
                        segment.a = 0;
                        segment.b = 0;
                        return segment;
                    }
                    b = xr;
                    xr = xl;
                    fr = fl;
                    xl = x0 - pow * h;
                    fl = Function.f(Xk, direction, xl);
                }
                a = xl;
                segment.a = a;
                segment.b = b;
                return segment;
            }
            return segment;
        }



      
        public static double GoldenSearch(double a, double b, double c, double tau, double[] xNow, double[] grDirection)
        {
            double x;
            double phi = (1 + Math.Sqrt(5)) / 2;
            double resphi = 2 - phi;
            if (b < c)
                x = b + resphi * (c - b);
            else
                x = b - resphi * (b - a);
            if (Math.Abs(c - a) < tau * (Math.Abs(b) + Math.Abs(x)))
                return (c + a) / 2;
            if (Function.f(xNow, grDirection, x) < Function.f(xNow, grDirection, b))
                return (b < c) ? GoldenSearch(b, x, c, tau, xNow, grDirection) : GoldenSearch(a, x, b, tau, xNow, grDirection);
            else
                return (b < c) ? GoldenSearch(a, b, x, tau, xNow, grDirection) : GoldenSearch(x, b, c, tau, xNow, grDirection);
        }
    }
}
