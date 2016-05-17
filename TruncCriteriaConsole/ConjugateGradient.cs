using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruncCriteriaConsole;


namespace TruncCriteriaConsole
{
    

    class ConjugateGradient
    {
        public static void gradient(double[] X, ref double[] res, int N,FunctionDelegate f)
        {
            double h = 0.001;
            double result;
            double f1;
            double f2;
            for (int i = 0; i < N; i++)
            {
                X[i] = X[i] + h;
                f1 = f(X);
                X[i] = X[i] - 2 * h;
                f2 = f(X);
                result = 0.5 * (f1 - f2) / h;
                res[i] = result;
                X[i] = X[i] + h;
            }
        }

        //Polak-Ribiere method
        public static double polak(double[] fk, double[] fkPrev, int N)
        {
            double[] tmp = new double[N];
            for (int i = 0; i < N; i++)
            {
                tmp[i] = fk[i] - fkPrev[i];
            }
            double result = Math.Sqrt(CommonMethods.skalar(fk, tmp,N)) / Math.Sqrt(CommonMethods.skalar(fk, fk,N));
            return result;
        }

        //Flatcher-Rievse method
       public  static double fletcher(double[] gradNow, double[] gradPrev,int N)
        {
            double result = Math.Sqrt(CommonMethods.skalar(gradNow, gradNow, N)) / Math.Sqrt(CommonMethods.skalar(gradPrev, gradPrev,  N));
            return result;
        }

        public static void direction(double[] gradNow, double[] dirPrev, double bk, ref double[] dirNew, int N)
        {
            for (int i = 0; i < N; i++)
                dirNew[i] = -gradNow[i] + bk * dirPrev[i];
        }

       public  static void ConjugateGradientMethod(double[] X0, ref double[] res, double th, double tau, int N, double eps, FunctionDelegate f)
        {
            Function.N = N;
            double[] gradFNow = new double[N];
            double[] result = new double[N];
            double[] xNow = new double[N];
            double[] xPrev = new double[N];
            double t = 0;
            double[] grDirection = new double[N];
            double[] grDirectionPrev = new double[N];
            double[] gradFPrev = new double[N];
            double grBk;
            double count = 0;
            int k = 0;
            for (int i = 0; i < N; i++)
                xNow[i] = X0[i];

            do
            {
                gradient(xNow, ref gradFNow, N, f);
                //******************************
                if (k == N || k == 0)
                {
                    for (int i = 0; i < N; i++)
                    {
                        grDirection[i] = -gradFNow[i];
                    }
                    k = 0;
                }
                else
                {
                    for (int i = 0; i < N; i++)
                        grDirectionPrev[i] = grDirection[i];
                    gradient(xPrev, ref gradFPrev, N, f);
                    grBk = fletcher(gradFNow, gradFPrev,N);
                    direction(gradFNow, grDirectionPrev, grBk, ref grDirection, N);
                }
                //****************************************


                interval segment = OnedimensionalOptmization.Swan(0, tau, xNow, grDirection);

                double ser = (segment.b + segment.a) / 2;
                t = OnedimensionalOptmization.GoldenSearch(segment.a, ser, segment.b, th, xNow, grDirection );
                for (int i = 0; i < N; i++)
                    xPrev[i] = xNow[i];
                for (int i = 0; i < N; i++)
                {
                    xNow[i] = xPrev[i] + t * grDirection[i];
                    Console.Write("xNow {0} ", xNow[i]);
                }
                Console.WriteLine();
                Console.WriteLine("F = {0} ", Math.Round(f(xNow), 6, MidpointRounding.AwayFromZero));
                k++;
                count++;

                //проверка на возрастание
                /*if(f(xNow) > f(xPrev)){
					Console.WriteLine("Функция возрастает");
					break;
				}*/
            } while (Math.Abs(f(xNow) - f(xPrev)) / f(xNow) > eps);
            Console.WriteLine(count);
            for (int i = 0; i < N; i++)
                res[i] = xNow[i];
        }
    }
}
