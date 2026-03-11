namespace NullableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? s = Console.ReadLine();     // possible null value

            // Σωστός χειρισμός της πιθανότητας null με έλεγχο
            if (s != null) Console.WriteLine(s.Length); // null check

            Console.WriteLine(s?.Length);       // null-conditional operator
            Console.WriteLine(s!.Length);       // null-forgiving operator (use with caution)
            Console.WriteLine(s ?? "default");  // null-coalescing operator
        }
    }
}
