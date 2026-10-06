namespace StreamWriterApp;

internal class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\tmp\new.txt";

        using StreamWriter sw = new(filePath, append: true);

        sw.WriteLine("Hello Coding Factory");
    }
}

