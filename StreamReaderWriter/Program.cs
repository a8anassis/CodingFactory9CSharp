namespace StreamWriterApp;

internal class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\tmp\file.txt";
        string outputPath = @"C:\tmp\file-out.txt";

        try
        {
            using StreamReader reader = new(inputPath);
            using StreamWriter writer = new(outputPath);

            //CopyTextBuffer(reader, writer);

            CopyBinaryFile(@"C:\tmp\logo.png", @"C:\tmp\logoout.png");

        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine($"File not found");
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine("Access denied.");
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine($"I/O Error: {ex.Message}");
        }
    }

    static void CopyTextBuffer(TextReader input, TextWriter output)
    {
        char[] buffer = new char[4096];
        int charsRead;

        while ((charsRead = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, charsRead);
        }
    }

    // Copies text from an input stream to an output stream
    static void CopyText(TextReader input, TextWriter output)
    {
        int ch;

        while ((ch = input.Read()) != -1)
        {
            output.Write((char)ch);
        }
    }


    static void CopyBinaryFile(string sourcePath, string destinationPath)
    {
        const int bufferSize = 4096;
        byte[] buffer = new byte[bufferSize];

        using FileStream sourceStream =
            new(sourcePath, FileMode.Open, FileAccess.Read);

        using FileStream destinationStream =
            new(destinationPath, FileMode.Create, FileAccess.Write);

        int bytesRead;

        while ((bytesRead = sourceStream.Read(
            buffer, 0, buffer.Length)) > 0)
        {
            destinationStream.Write(buffer, 0, bytesRead);
        }
    }



}