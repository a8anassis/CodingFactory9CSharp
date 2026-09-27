using System.Globalization;

namespace PrintingApp
{
    /// <summary>
    /// Basic C# program that demonstrates how to print output to the console.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 100;
            double doubleNum = 100_900.5;

            Console.WriteLine("Hello, World!");
            Console.WriteLine("Num = {0}", num);    // placeholder
            Console.WriteLine($"Num = {num}");      // interpolation

            CultureInfo.CurrentCulture = new CultureInfo("el-GR");

            Console.WriteLine("Double Num = {0,-10:N2}", doubleNum);    // placeholder
            Console.WriteLine($"Double Num = {doubleNum,-10:N2}");      // interpolation
        }
    }
}
