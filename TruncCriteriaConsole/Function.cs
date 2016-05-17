using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruncCriteriaConsole
{
    class Function
    {
        public static int N { get; set; }
        public static double Sqr(double x)
        {
            return x * x;
        }

       public  static double f(double[] X)
        {
            double result = 100 * Sqr(Sqr(X[0]) - X[1]) + Sqr(1 - X[0]);
            return result;
        }

        public static double f(double[] Xk, double[] dk, double t)
        {
            double[] X = new double[N];
            for (int i = 0; i < N; i++)
            {
                X[i] = Xk[i] + t * dk[i];
            }
            double result = f(X);
            return result;
        }
    }
}
