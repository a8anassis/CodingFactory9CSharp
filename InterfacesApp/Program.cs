namespace InterfacesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMoveable p1 = new Point() { X = 10 };

            p1.Move10();

            Console.WriteLine(p1);
        }
    }
}
