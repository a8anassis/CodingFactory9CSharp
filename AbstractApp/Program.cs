namespace AbstractApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AbstractAnimal cannot be instantiated: new AbstractAnimal() would not compile.
            AbstractAnimal cat = new Cat { Id = 1, Name = "Tom", Age = 3.5 };

            Console.WriteLine(cat);   // calls Cat.ToString()
            cat.Eat();                // calls Cat.Eat(), which also calls base.Eat()
        }
    }
}
