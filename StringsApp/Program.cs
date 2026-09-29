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

            // String Interning: identical string literals are stored only once in memory.
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

            // Improvements:
            // 1) Use range syntax (C# 8+) which is shorter and clearer
            string? subRange = str1[..2];   // "he"
            string? partRange = str1[2..];  // "llo"

            // 2) Null-guarded versions if str1 may be null
            string? subRangeSafe = str1 is null ? null : str1[..2];
            string? partRangeSafe = str1 is null ? null : str1[2..];

            // indexOf, lastIndexOf
            int index = (str1 is null) ? -1 : str1.IndexOf('l');              // 2
            if (index != -1)
            {
                Console.WriteLine($"First occurrence of 'l' is at index: {index}");
            }
            else
            {
                Console.WriteLine("'l' not found in the string.");
            }
            int lastIndex = (str1 is null) ? -1 : str1.LastIndexOf("he");     // 0

            // Trim
            string? padded = "  hello  ";
            string? trimmed = (padded is null) ? null : padded.Trim(); // "hello"
            Console.WriteLine(trimmed);
        }
    }
}
