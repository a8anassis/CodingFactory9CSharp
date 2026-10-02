using CollectionsSort;
using System.Reflection.Metadata.Ecma335;

namespace LinqApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            // Query syntax: "from ... select" is the simplest LINQ query, it selects every element.
            // LINQ uses deferred execution: the query is only defined here, not executed.
            var allNumbers = from num in numbers select num;    // returns IEnumerable<int>, δεν εκτελείται

            // The query actually runs when we enumerate it (foreach).
            foreach ( var num in allNumbers )      // εκτελείται
            {
                Console.WriteLine(num);
            }

            // Filtering
            // "where" keeps only the elements that satisfy the condition (here: even numbers).
            var evenNumbers = from num in numbers
                              where num % 2 == 0
                              select num;

            foreach( var num in evenNumbers )
            {
                Console.WriteLine(num);
            }


            // terminal operations
            // ToList() / ToArray() force immediate execution and materialize the results into a collection.
            List<int> evenNumbers2 = (from num in numbers
                                     where num % 2 == 0
                                     select num).ToList();

            var oddNumbers = (from num in numbers
                              where num % 2 != 0
                              select num).ToArray();

        }


        // Filtering with Where
        // Returns only the even numbers of the array, as an array.
        public static int[] FilterEvenToArray(int[] arr)
        {
            //return (from num in arr
            //        where num % 2 == 0
            //        select num).ToArray();

            // Collection expression with spread (..) materializes the query into an array
            return [ ..from num in arr
                    where num % 2 == 0
                    select num ];
        }

        // Same filter as above, but the result is a List<int>.
        public static List<int> FilterEvenToList(int[] arr)
        {
            //return (from num in arr
            //        where num % 2 == 0
            //        select num).ToList();

            // Spread (..) into a List<int> because of the return type
            return [ ..from num in arr
                    where num % 2 == 0
                    select num ];
        }


        // Mapping with Select
        // Filters the odd numbers, then maps (projects) each one to its double (num * 2).
        public static int[] MapOddToDouble(int[] arr)
        {
            //return (from num in arr
            //        where num % 2 != 0
            //        select num * 2).ToArray();

            return [.. from num in arr
                    where num % 2 != 0
                    select num * 2];
        }

        // Same as MapOddToDouble, but returns a List<int>.
        public static List<int> MapOddToDoubleToList(int[] arr)
        {
            //return (from num in arr
            //        where num % 2 != 0
            //        select num * 2).ToList();

            return [.. from num in arr
                    where num % 2 != 0
                    select num * 2];
        }


        // Pagination
        // Skip jumps over the elements of the previous pages, Take keeps only one page of elements.
        // Pages are 1-based, e.g. page 2 with pageSize 3 skips 3 elements and takes the next 3.
        public static int[] GetPage(int[] arr, int page, int pageSize)
        {
            return (from num in arr select num).Skip((page - 1) * pageSize).Take(pageSize).ToArray();
        }

        // Pagination on objects: sort first (a stable order is required for consistent pages),
        // then skip and take. Fluent (method) syntax is used after the initial query.
        public static Student[] GetStudentPage(Student[] students, int page, int pageSize)
        {
            return (from s in students select s)
                .OrderBy(s => s.Lastname)       // primary sort key
                .ThenBy(s => s.Firstname)       // tie-breaker when lastnames are equal
                .Skip((page -1) * pageSize)     // skip previous pages
                .Take(pageSize)                 // keep the current page
                .ToArray();
        }

        // Reduce
        // Reducing (aggregate) operators collapse a sequence into a single value.
        public static int SumAll(int[] arr)
        {
            // return (from num in arr select num).Sum();   // query syntax
            return arr.Sum();                               // Fluent
            //return arr.Count();
            // return arr.Max();
            //return arr.Min();   // smallest element (throws InvalidOperationException on an empty array)
        }

        // Average() returns the arithmetic mean as a double.
        public static double AverageAll(int[] arr)
        {
            return arr.Average();
        }

        // Sort
        // "orderby ... descending" sorts from the largest to the smallest.
        public static int[] SortDesceding(int[] arr)
        {
            return [.. from num in arr orderby num descending select num];
        }

        // "orderby ... ascending" sorts from the smallest to the largest (ascending is the default).
        public static int[] SortAscending(int[] arr)
        {
            return [.. from num in arr orderby num ascending select num];
        }

        // Reverse() inverts the order of the elements (it does not sort).
        public static int[] ReverseArray(int[] arr)
        {
            return [.. (from num in arr select num).Reverse()];
        }

        // Distinct() removes duplicate elements.
        public static int[] DistictArray(int[] arr)
        {
            return [.. (from num in arr select num).Distinct()];
        }

        // All() returns true only if every element satisfies the predicate (true for an empty array).
        public static bool AllGT(int[] arr, int num)
        {
            return arr.All(n => n > num);
        }

        // Any() returns true if at least one element satisfies the predicate (false for an empty array).
        public static bool AnyGT(int[] arr, int num)
        {
            return arr.Any(n => n > num);
        }

        // Filtering
        // Fluent (method) syntax: Where takes a lambda predicate, equivalent to the "where" clause.
        public static int[] FilterFluent(int[] arr) => [.. arr.Where(n => n > 0)];    //arr.Where(n => n > 0).ToArray();
        public static int[] FilterEvenFluent(int[] arr) => arr.Where(n => n % 2 == 0).ToArray();

        // Map - Select
        // Where filters the even numbers, Select transforms each of them to its double.
        public static int[] MapToDoubleFluent(int[] arr) => arr.Where(n => n % 2 == 0).Select(n => n * 2).ToArray();

        // Reducing
        // Sum of all elements.
        public static int SumFluent(int[] arr) => arr.Sum();
        // Smallest element.
        public static int MinFluent(int[] arr) => arr.Min();

        // Largest element.
        public static int MaxFluent(int[] arr) => arr.Max();

        // Number of elements.
        public static int CountFluent(int[] arr) => arr.Count();

        // Arithmetic mean of the elements.
        public static double AverageFluent(int[] arr) => arr.Average();

        // Sorting

        // OrderByDescending takes a key selector lambda and sorts from largest to smallest.
        public static int[] SortDescFluent(int[] arr) => arr.OrderByDescending(n => n).ToArray();
        // OrderBy takes a key selector lambda and sorts from smallest to largest.
        public static int[] SortAscFluent(int[] arr) => arr.OrderBy(n => n).ToArray();

        // Aggregates
        // True if all elements are greater than num.
        public static bool AllGTFluent(int[] arr, int num) => arr.All(n => n > num);


        // True if at least one element is greater than num.
        public static bool AnyGTFluent(int[] arr, int num) =>  arr.Any(n => n > num);


        // Returns the first element greater than 5, or default(int) (0) if none matches.
        public static int FindFirstOrDefault(int[] arr) => arr.FirstOrDefault(n => n > 5);



    }
}
