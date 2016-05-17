using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruncCriteriaConsole
{

    class CommonMethods
    {
       public  static double skalar(double[] X, double[] Y, int N)
        {
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += X[i] * Y[i];
            }
            return sum;
        }

        public  static double norm(double[] X, int N)
        {
            double sum = 0;
            for (int i = 0; i < N; i++)
                sum += X[i] * X[i];
            double result = Math.Sqrt(sum);
            return result;
        }
    }
}
