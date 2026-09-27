namespace IfCases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = 20;
            string? name = null;

            if (age > 18)
            {
                Console.WriteLine("Ενήλικας");
            }
            else
            {
                Console.WriteLine("Ανήλικος");
            }

            // Using the ternary operator
            // var is syntactic sugar for declaring a variable without specifying its type explicitly.
            var status = age > 18 ? "Ενήλικας" : "Ανήλικος";
            Console.WriteLine(status);  // Ενήλικας

            // Using the null-coalescing operator
            var displayName = name ?? "Άγνωστος";
            Console.WriteLine(displayName);

            // Using the null-conditional operator
            var length = name?.Length ?? 0;
            Console.WriteLine(length);

        }
    }
}
