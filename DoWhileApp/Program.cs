namespace DoWhileApp
{
    /// <summary>
    /// Counts the number of digits of an int.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            int numberOfDigits = 0;
            int tmp = 0;

            Console.WriteLine("Εισάγετε ένα ακέραιο");
            if (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Μη έγκυρη είσοδος. Παρακαλώ εισάγετε έναν ακέραιο.");
                return;
            }

            tmp = num;
            do
            {
                tmp /= 10;
                numberOfDigits++;
            } while (tmp != 0);

            Console.WriteLine($"Digits count: {numberOfDigits}");
        }
    }
}
