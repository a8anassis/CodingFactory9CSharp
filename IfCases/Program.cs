namespace IfCases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = 20;
            string name = null;
            string nickname = "Ally";

            if (age > 18)
            {
                Console.WriteLine("Ενήλικας");
            }
            else
            {
                Console.WriteLine("Ανήλικος");
            }

            var status = age > 18 ? "Ενήλικας" : "Ανήλικος";
            Console.WriteLine(status);  // Ενήλικας

            var displayName = name ?? "Άγνωστος";
            Console.WriteLine(displayName);

            var length = name?.Length ?? 0;
            Console.WriteLine(length);

        }
    }
}
