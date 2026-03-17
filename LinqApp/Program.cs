using CollectionsSort;
using System.Reflection.Metadata.Ecma335;

namespace LinqApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            var allNumbers = from num in numbers select num;    // returns IEnumerable<int>, δεν εκτελείται

            foreach ( var num in allNumbers )      // εκτελείται
            {
                Console.WriteLine(num);
            }

            // Filtering
            var evenNumbers = from num in numbers
                              where num % 2 == 0
                              select num;

            foreach( var num in evenNumbers )
            {
                Console.WriteLine(num);
            }


            // terminal operations
            List<int> evenNumbers2 = (from num in numbers
                                     where num % 2 == 0
                                     select num).ToList();

            var oddNumbers = (from num in numbers
                              where num % 2 != 0
                              select num).ToArray();

        }


        // Filtering with Where
        public static int[] FilterEvenToArray(int[] arr)
        {
            //return (from num in arr
            //        where num % 2 == 0
            //        select num).ToArray();

            return [ ..from num in arr
                    where num % 2 == 0
                    select num ];
        }

        public static List<int> FilterEvenToList(int[] arr)
        {
            //return (from num in arr
            //        where num % 2 == 0
            //        select num).ToList();

            return [ ..from num in arr
                    where num % 2 == 0
                    select num ];
        }


        // Mapping with Select
        public static int[] MapOddToDouble(int[] arr)
        {
            //return (from num in arr
            //        where num % 2 != 0
            //        select num * 2).ToArray();

            return [.. from num in arr
                    where num % 2 != 0
                    select num * 2];
        }

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
        public static int[] GetPage(int[] arr, int page, int pageSize)
        {
            return (from num in arr select num).Skip((page - 1) * pageSize).Take(pageSize).ToArray();
        }

        public static Student[] GetStudentPage(Student[] students, int page, int pageSize)
        {
            return (from s in students select s)
                .OrderBy(s => s.Lastname)
                .ThenBy(s => s.Firstname)
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToArray();
        }

        // Reduce
        public static int SumAll(int[] arr)
        {
            // return (from num in arr select num).Sum();   // query syntax
            //return arr.Sum();                               // Fluent
            //return arr.Count();
            // return arr.Max();
            return arr.Min();
        }

        public static double AverageAll(int[] arr)
        {
            return arr.Average();
        }

        // Sort
        public static int[] SortDesceding(int[] arr)
        {
            return [.. from num in arr orderby num descending select num];
        }

        public static int[] SortAscending(int[] arr)
        {
            return [.. from num in arr orderby num ascending select num];
        }

        public static int[] ReverseArray(int[] arr)
        {
            return [.. (from num in arr select num).Reverse()];
        }

        public static int[] DistictArray(int[] arr)
        {
            return [.. (from num in arr select num).Distinct()];
        }

        public static bool AllGT(int[] arr, int num)
        {
            return arr.All(n => n > num);
        }

        public static bool AnyGT(int[] arr, int num)
        {
            return arr.Any(n => n > num);
        }

        // Filtering
        public static int[] FilterFluent(int[] arr) => [.. arr.Where(n => n > 0)];    //arr.Where(n => n > 0).ToArray();
        public static int[] FilterEvenFluent(int[] arr) => arr.Where(n => n % 2 == 0).ToArray();

        // Map - Select
        public static int[] MapToDoubleFluent(int[] arr) => arr.Where(n => n % 2 == 0).Select(n => n * 2).ToArray();

        // Reducing
        public static int SumFluent(int[] arr) => arr.Sum();
        public static int MinFluent(int[] arr) => arr.Min();

        public static int MaxFluent(int[] arr) => arr.Max();

        public static int CountFluent(int[] arr) => arr.Count();

        public static double AverageFluent(int[] arr) => arr.Average();

        // Sorting

        public static int[] SortDescFluent(int[] arr) => arr.OrderByDescending(n => n).ToArray();
        public static int[] SortAscFluent(int[] arr) => arr.OrderBy(n => n).ToArray();

        // Aggregates
        public static bool AllGTFluent(int[] arr, int num) => arr.All(n => n > num);
        

        public static bool AnyGTFluent(int[] arr, int num) =>  arr.Any(n => n > num);
        

        public static int FindFirstOrDefault(int[] arr) => arr.FirstOrDefault(n => n > 5);



    }
}
