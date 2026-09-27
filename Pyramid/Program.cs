namespace Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the height of the pyramid: ");
            int height = int.Parse(Console.ReadLine()!);

            for (int row = 1; row <= height; row++)
            {
                // leading spaces to center the row
                for (int space = 1; space <= height - row; space++)
                {
                    Console.Write(" ");
                }

                // stars for the current row
                for (int star = 1; star <= (2 * row - 1); star++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
