namespace CollectionsSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students =
                [
                    new Student() { Firstname = "Alice", Lastname = "A.", Age = 22 },
                    new Student() { Firstname = "Bob", Lastname = "B.", Age = 20 }
                ];

            students.Sort();            // Χρησιμοποιεί την compareTo
            students.Sort((s1, s2) => string.Compare(s1.Lastname, s2.Lastname, StringComparison.Ordinal));    // IComparer
        }
    }
}
