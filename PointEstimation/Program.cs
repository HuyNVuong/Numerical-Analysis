using System;

namespace hw1
{
    class Program
    {
        private static int IterationCounter;

        static void Main(string[] args)
        {
            double f(double x) => 3 * Math.Pow(x, 3) - 2 * Math.Pow(x, 2) + 5 * x - 2 * Math.Exp(x) + 1;
            // We hard code the derivative of the function for now
            double df(double x) => 9 * Math.Pow(x, 2) - 4 * x + 5 - 2 * Math.Exp(x);
            IterationCounter = 0;
            var bisectionPoint = BisectionMethod(f, (-1, 1), tolerance: 0.0001);
            Console.WriteLine(bisectionPoint);
            var newtonsPoint = NewtonsMethod(f, df, 1, epsilon: 0.0001, maxIterations: 50);
            Console.WriteLine(newtonsPoint);
            var secantPoint = SecantMethod(f, 1, 0.99, epsilon: 0.0001, maxIterations: 50);
            Console.WriteLine(secantPoint);

            double g(double x) => Math.Pow(x, 3) - 17 * Math.Pow(x, 2) + 6 * x + 5.5;
            bisectionPoint = BisectionMethod(g, (0, 16), tolerance: Math.Pow(10, -25));
            Console.WriteLine(bisectionPoint);
        }

        static double BisectionMethod(Func<double, double> f, (double, double) interval, double tolerance = 0.1)
        {
            var a = interval.Item1;
            var b = interval.Item2;
            var p = (a + b) / 2;
            Console.WriteLine($"[Iteration {IterationCounter}]: f({p}) = {f(p)}");

            if (Math.Abs(f(p)) < tolerance)
            {
                Console.WriteLine($"Root found using Bisection method after {IterationCounter} iterations"); 
                return p; 
            } 

            IterationCounter++;

            if (f(a) * f(p) < 0) 
                return BisectionMethod(f, (a, p), tolerance);

            return BisectionMethod(f, (p, b), tolerance);
        }

        static double NewtonsMethod(Func<double, double> f, Func<double, double> df, double p0, double epsilon = 0.1, int maxIterations = 10)
        {
            var i = 0;
            while (i < maxIterations)
            {    
                var p = p0 - f(p0) / df(p0);
                Console.WriteLine($"[Iteration {i}]: p_0 = {p0}, p = {p}");
                if (Math.Abs(p - p0) < epsilon)
                {
                    Console.WriteLine($"Root found using Newton's Method after {i} iterations");
                    return p;
                }
                p0 = p;
                i++;    
            }

            Console.WriteLine($"Failed to find the root after {maxIterations} iterations");
            return -1;
        }

        static double SecantMethod(Func<double, double> f, double p0, double p1, double epsilon = 0.1, int maxIterations = 50)
        {
            var i = 0;
            while (i < maxIterations)
            {    
                var p = p1 - f(p1) * (p1 - p0) / (f(p1) - f(p0));
                Console.WriteLine($"[Iteration {i}]: p_0 = {p0}, p = {p}");
                if (Math.Abs(p - p1) < epsilon)
                {
                    Console.WriteLine($"Root found using Secant Method after {i} iterations");
                    return p;
                }
                p0 = p1;
                p1 = p;
                i++;    
            }

            Console.WriteLine($"Failed to find the root after {maxIterations} iterations");
            return -1;
        }             
    }
}
