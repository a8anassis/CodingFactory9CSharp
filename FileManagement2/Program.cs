using System.Text;

namespace FileManagement2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\tmp\file.txt";
            DLList<char> dll = new();

            try
            {
                // For ANSI Greek files use: Encoding.GetEncoding(1253)
                // (requires CodePagesEncodingProvider registration in .NET Core+)
                using StreamReader reader = new(filePath, Encoding.UTF8);

                int ordinal;
                while ((ordinal = reader.Read()) != -1)
                {
                    char ch = (char)ordinal;
                    if (ch is '\r' or '\n') continue;

                    dll.UpSert(ch);
                }

                //dll.SortByCount();
                dll.SortByValueAsc();
                dll.Traverse();
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine($"File not found: {filePath}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.Error.WriteLine($"Access denied: {filePath}");
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}