namespace ArrayApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Arrays are reference types in C#.
            // They are used to store multiple values of the same type in a single variable.
            int[] arr = new int[5]; // array of 5 integers, initialized to 0
            arr[0] = 1;

            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };

            int[] arr3 = { 1, 2, 3, 4, 5 };

            int[] numbers = [ 1, 2, 3, 4, 5];

            for (int i = 0; i < arr2.Length; i++)
            {
                Console.WriteLine(arr2[i]);
            }

            foreach (int num in arr3)
            {
                Console.WriteLine(num);
            }

            // 2D array
            int[,] matrix = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
             };

             for (int i = 0; i < matrix.GetLength(0); i++)
             {
                 for (int j = 0; j < matrix.GetLength(1); j++)
                 {
                     Console.Write(matrix[i, j] + " ");
                 }
                 Console.WriteLine();
            }

            int[][] jaggedArray = new int[3][];
            int[][] jagged = [[1,2], [3,4], [5,6]];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }


            // Array methods
            int[] arr4 = { 5, 2, 8, 1, 3 };
            Array.Sort(arr4); // Sorts the array in ascending order
            Array.Reverse(arr4); // Reverses the order of the elements in the array
            int index = Array.IndexOf(arr4, 3); // Finds the index of the first occurrence of 3 in the array

            int[] copy = new int[arr4.Length];
            Array.Copy(arr4, copy, arr4.Length); // Copies the elements of arr4 to copy

        }

        public static int GetMinPosition(int[] arr)
        {
            int minPos = 0;
            int minValue = arr[minPos];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                    minPos = i;
                }
            }

            return minPos;
        }

        public static bool IsSymmetric(int[] arr)
        {
            for (int i = 0, j = arr.Length - 1; i < j; i++, j--)
            {
                if (arr[i] != arr[j])
                {
                    return false;
                }
            }

            return true;
        }

        public static (long bestSum, int bestRow, int bestCol) FindBestSum(int[,] matrix)
        {
            long bestSum = long.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    long sum = matrix[i, j] + matrix[i, j + 1] 
                        + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = i;
                        bestCol = j;
                    }
                }
            }
            return (bestSum, bestRow, bestCol);
        }



    }
}
