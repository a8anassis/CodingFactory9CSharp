namespace StringsApp
{
    /// <summary>
    /// Strings are immutable and are interned by the .NET runtime, 
    /// meaning that identical string literals are stored only once in memory.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string? str1 = "hello";
            string? str2 = "hello";
            string? str3 = new string("hello");

            Console.WriteLine(str1[0]); // 'h' - indexing

            // String equality
            Console.WriteLine(str1 == str2);        // True (value equality)
            Console.WriteLine(str1.Equals(str2));   // True (value equality)

            // Reference equality
            Console.WriteLine(object.ReferenceEquals(str1, str2));  // True (interned string)
            Console.WriteLine(object.ReferenceEquals(str1,str3));   // False (different objects)

            // Compare strings
            Console.WriteLine(string.Compare(str1, str3));  // 0 (equal)
            Console.WriteLine(str1.CompareTo(str2));        // 0 (equal)
            int resultEqulsIgnoreCase = string.Compare(str1, str3, StringComparison.OrdinalIgnoreCase); // 0 (equal, ignoring case)

            // concat
            string? result = str1 + " " + str2; // Concatenation
            string? result2 = string.Concat(str1, " ", str2); // Concatenation using method

            // toUpper, toLower
            string? upper = str1.ToUpper(); // "HELLO"
            string? lower = str1.ToLower(); // "hello"

            Console.WriteLine(str1.ToUpper() == str2.ToUpper());    // Normalized comparison (case-insensitive)

            // Substring
            string? sub = str1.Substring(0, 2); // "he"   startIndex, length
            string part = str1.Substring(2);    // "llo"   startIndex to end of string

            // indexOf, lastIndexOf
            int index = str1.IndexOf('l');              // 2
            int lastIndex = str1.LastIndexOf("he");     // 0

            // Trim
            string? padded = "  hello  ";
            string? trimmed = padded.Trim(); // "hello"

        }
    }
}
