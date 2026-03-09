namespace NumberRead
{
    /// <summary>
    /// Safe reading of float and double values from the console
    /// using TryParse to handle invalid input gracefully.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            float floatNum = 0F;
            double doubleNum = 0D;

            Console.WriteLine("Εισάγετε δύο δεκαδικούς:");

            if (!float.TryParse(Console.ReadLine(), out floatNum))
            {
                Console.WriteLine("Μη έγκυρη είσοδος για float.");
                return;
            }

            if (!double.TryParse(Console.ReadLine(), out doubleNum))
            {
                Console.WriteLine("Μη έγκυρη είσοδος για double.");
                return;
            }

            Console.WriteLine($"float = {floatNum,-10:N2}\t double = {doubleNum, -10:N2}");
        }
    }
}
