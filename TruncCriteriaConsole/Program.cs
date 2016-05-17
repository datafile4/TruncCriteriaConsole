using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruncCriteriaConsole;

namespace TruncCriteriaConsole
{
    class Program
    {
        const double eps = 0.0001;
        static void Main(string[] args)
        {
            
            Console.Write("Enter N: ");
            int N = int.Parse(Console.ReadLine());
            double[] X0 = new double[N];
            double[] result = new double[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("Enter X{0} ", i);
                X0[i] = double.Parse(Console.ReadLine());
            }
            Console.Write("Enter t: ");
            double t = double.Parse(Console.ReadLine());
            Console.Write("Enter tau: ");
            double tau = double.Parse(Console.ReadLine());


            ConjugateGradient.ConjugateGradientMethod(X0, ref result, t, tau, N, eps);
            for(int i = 0; i<N; i++)
            {
                Console.Write("{0} ",result[i]);
            }
            Console.ReadKey();
        }

        public static double Sqr(double x)
        {
            return x * x;
        }
    }
}
