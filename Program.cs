using System;

namespace BisectionMethod
{
    class Program
    {
        static float equation(float x)
        {
            return (x * x * x - 4 * x - 9);
        }

        unsafe static void bisection(float* x, float a, float b, int* i)
        {
            *x = (a + b) / 2;
            ++(*i);
            Console.WriteLine(+ *i + "Iteration: X" + *i + "=" + *x +"");
        }
        unsafe static void Main(string[] args)
        {
            int i = 0, maxit;
            float x, a, b, t, xn;
            Console.WriteLine("Please enter the value of A:");
            a = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the value of B:");
            b = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the value of Tolerance:");
            t = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the value of Maximum iteration:");
            maxit = Convert.ToInt32(Console.ReadLine());

            bisection(&x, a, b, &i);
            
            do
            {
                if(equation (a) * equation(x) > 0)
                {
                    a = x;
                }
                else
                {
                    b = x;
                }

                bisection(&xn, a, b, &i);

                if ((xn - x) < t)
                {
                    Console.WriteLine("\n" + "The approximate root is " + xn + " for " + t + " Tolerance.");
                    return;
                }

                x = xn;
            }
            while (i<maxit);
            Console.WriteLine("Iteration coverage");
            return;
        }
    }
}
