using System.Text;

namespace ExtractCapitals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        // Extract capital letters from a string
        public static string ExtractCapitals(string? input)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input?.Length; i++)
            {
                char c = input[i];
                if (char.IsUpper(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
