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
        
        static void Main(string[] args)
        {

            Console.Write("Enter eps for gradient method: ");
            double eps = double.Parse(Console.ReadLine());
            int N = 2;
            double[] X0 = new double[N];
            double[] result = new double[N];
            //double[] values = new double[N];
            //for(int i = 0; i <N; i++)
            //{
            //    Console.Write("Enter the desired value function {0} :",i );
            //    values[i] = double.Parse(Console.ReadLine());
            //}

            for (int i = 0; i < N; i++)
            {
                Console.Write("Enter X{0} ", i);
                X0[i] = double.Parse(Console.ReadLine());
            }
            Console.Write("Enter t: ");
            double t = double.Parse(Console.ReadLine());
            Console.Write("Enter tau: ");
            double tau = double.Parse(Console.ReadLine());


            Console.ReadKey();
        }

       
    }
}
