namespace SingleLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new SLList<string>();
            Console.WriteLine($"Empty: {list.IsEmpty}, Count: {list.Count}");

            list.InsertFirst("Αθήνα");
            list.InsertFirst("Πάτρα");
            list.InsertLast("Θεσσαλονίκη");
            list.InsertLast("Ηράκλειο");
            Print("After inserts", list);

            Console.WriteLine($"RemoveFirst: {list.RemoveFirst()}");
            Console.WriteLine($"RemoveLast: {list.RemoveLast()}");
            Print("After removes", list);

            list.RemoveFirst();
            list.RemoveLast();
            Print("After emptying", list);

            try
            {
                list.RemoveFirst();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void Print<T>(string title, SLList<T> list)
        {
            Console.WriteLine($"{title} (Count: {list.Count}): [{string.Join(", ", list)}]");
        }
    }
}
