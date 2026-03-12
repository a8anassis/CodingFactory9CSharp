namespace PocoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student alice = new Student();
            Student bob = new();    // C# 9
            var julia = new Student(); // C# 10

            Teacher teacher = new(1, "Μάκης", "Καπέτης");   // Overloaded Constructor
            Teacher teacher2 = new() { Id = 2, Firstname = "Γιάννης", Lastname = "Παπαδόπουλος" }; // Object Initializer

            // Student student = new() { Id = 1, Firstname = "Alice", Lastname = "Smith" };
        }
    }
}
