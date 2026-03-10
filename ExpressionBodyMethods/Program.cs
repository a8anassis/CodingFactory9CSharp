namespace ExpressionBodyMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        // Expression-bodied method - concise syntax for methods
        // that consist of a single expression.
        public static int Add(int a, int b) => a + b;

        public static int Factorial(int n) => (n == 0) ? 1 : n * Factorial(n - 1);

        public static bool IsEven(int n) => n % 2 == 0;
    }
}
