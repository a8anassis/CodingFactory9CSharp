namespace CollectionsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>() { "Hello", "World" }; // Collection Initializer
            List<string> list2 = [ "Hello", "Coding" ];           // C#12 - Collection initialization syntax

            var hashSet = new HashSet<string>() { "Hello", "World" };
            HashSet<string> hashSet2 = ["Hello", "Coding"];

            var dict = new Dictionary<int, string>()
            {
                { 1, "one" },
                { 2, "two" }
            };

            var dict2 = new Dictionary<int, string>()       // Index Initializer
            {

                [1] = "one",
                [2] = "two" 
            };

            Stack<string> stack1 = new Stack<string>(new[] { "Hello", "World" });
            Stack<string> stack2 = new Stack<string>(["Hello", "World"]);

            Queue<string> queue1 = new Queue<string>(new[] { "Hello", "World" });
            Queue<string> queue2 = new Queue<string>(["Hello", "World"]);
        }

        // Lists
        public static void DoList(List<string> list)
        {
            list.Add("Hello");          // Inserts Hello at the end of the list
            list.Insert(1, "World");    // Inserts at index 1, shifting right all other elements
            list.AddRange(["Coding", "Factory"]);
            list.Remove("Hello");
            list.RemoveAt(0);

            list[1] = "AUEB";           // Update
            string token = list[1];     // Read

            Console.WriteLine(list.Count);
            list.ForEach(x => Console.WriteLine(x));
        }

        public static void DoLinkedList(LinkedList<string> linkedList)
        {
            linkedList.AddLast("Hello");
            linkedList.AddFirst("World");
            linkedList.AddAfter(linkedList.First!, "Coding");
            linkedList.AddBefore(linkedList.Last!, "Hello");

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }

        // Dictionaries
        public static void DoDictionary(Dictionary<string, int> dictionary)
        {
            dictionary.Add("one", 1);
            dictionary["Two"] = 2;          // Insert or Update
            int num = dictionary["one"];    // Read - Unsafe KeyNotFoundException

            if (!dictionary.TryGetValue("two", out num))
            {
                Console.WriteLine("Error");
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}, {kvp.Value}");
            }
        }

        // Stacks
        public static void DoStack(Stack<string> stack)
        {
            stack.Push("Hello");
            stack.Push("World");

            string topElement = stack.Pop();
            Console.WriteLine(topElement);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        // Queues
        public static void DoQueue(Queue<string> queue)
        {
            queue.Enqueue("Hello");
            queue.Enqueue("World");

            string frontElement = queue.Dequeue();

            foreach (var item in frontElement)
            {
                Console.WriteLine(item);
            }
        }


        // Sets
        public static void DoHashSet(HashSet<string> hashSet)
        {
            var hashSet2 = new HashSet<string>() { "Hello", "Coding", "Factory"};   // Initializer 

            hashSet.Add("Hello");
            hashSet.Add("World");
            hashSet.Add("Hello");   // Duplicate, will not added

            hashSet.Union(hashSet2);            // adds all unique elements from hashSet2 to hashSet
            hashSet.IntersectWith(hashSet2);    // Present in both sets

            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }
        }



    }


   
}
