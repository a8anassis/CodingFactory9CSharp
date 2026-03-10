using System.Numerics;

namespace MethodsApp
{
    internal class Program
    {
        private static Dictionary<int, int> fiboMemo = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        /// <summary>
        /// Calculates the factorial of a non-negative integer value.
        /// </summary>
        /// <param name="n">The non-negative integer for which to compute the factorial</param>
        /// <returns>A <see cref="BigInteger"/> representing the factorial of the specified integer. Returns 1 if <paramref
        /// name="n"/> is 0.</returns>
        public static BigInteger Factorial(int n)
        {
            BigInteger facto = 1;

            for (int i = 1; i <= n; i++)
            {
                facto *= i;
            }

            return facto;
        }

        public static BigInteger FactorialRecursive(int n)
        {
            //if (n == 0)
            //{
            //    return 1;
            //}
            //return n * FactorialRecursive(n - 1);
            return (n == 0) ? 1 : n * FactorialRecursive(n - 1);
        }


        public static bool IsPrime(int n) 
        { 
            if (n < 2) return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
        
            return true;
        }

        public static bool IsPrimeBetter(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0) return false;
            }

            return true;
        }

        public static int Fibonacci(int n)
        {
            if (n < 0) throw new ArgumentException("Input must be a non-negative integer.");
            if (n == 0) return 0;
            if (n == 1) return 1;

            int a = 0;
            int b = 1;
            int c = 1;

            for (int i = 1; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }


        public static int ArrayFibo(int n)
        {
            int[] arr = new int[n + 1];

            arr[0] = 0;
            arr[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

            return arr[n];
        }

        public static int FibonacciRecursive(int n)
        {
            if (n == 0) return 0;
            if (n <= 2) return 1;   
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }


        public static int FiboMemoization(int n)
        {
            if (n == 0) return 0;
            if (n <= 2) return 1;

            if (fiboMemo.TryGetValue(n, out int value)) 
            {
                return value;
            } 

            int result = FiboMemoization(n - 1) + FiboMemoization(n - 2);
            fiboMemo[n] = result;

            return result;
        }


    }
}
