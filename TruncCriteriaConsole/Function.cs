using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruncCriteriaConsole
{
    public delegate double FunctionDelegate(double[] X);

    class Function
    {
        public static int N { get; set; }
        public static double Sqr(double x)
        {
            return x * x;
        }

        //criteries
        List<FunctionDelegate> criteriaList = new List<FunctionDelegate> { f1,f2};
       
       public  static double f1(double[] X)
        {
            double result = Sqr(X[0]) + Sqr(X[1]);
            return result;
        }

        public static double f2(double[] X)
        {
            double result = Sqr(X[0] - 1) + Sqr(X[1])+X[1];
            return result;
        }

        //restrictions 
        List<FunctionDelegate> restrictionList = new List<FunctionDelegate> {g1,g2};

        public static double g1(double[] X)
        {
            return Math.Abs(X[0]);
        }

        public static double g2(double[] X)
        {
            return Math.Abs(X[1]);
        }

        public static double fOne(double[] Xk, double[] dk, double t,FunctionDelegate f)
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
