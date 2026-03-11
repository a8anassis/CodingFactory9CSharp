namespace PalindromeStr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static bool IsPalindrome(string? str)
        {
            if (str == null) return false;

            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                if (str[i] != str[j]) return false;
            }

            return true;
        }
    }
}
