using System;

namespace BBIT_Test_Exercises
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var array20x20 = new int[20, 20];
            var random = new Random();
            var smallest = 500;
            var smallestX = 0;
            var smallestY = 0;
            var largest = 500;
            var largestX = 0;
            var largestY = 0;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    var roll = random.Next(1, 999);
                    array20x20[i, j] = roll;

                    if (roll < smallest)
                    {
                        smallest = roll;
                        smallestX = j + 1;
                        smallestY = i + 1;
                    }

                    if (roll > largest)
                    {
                        largest = roll;
                        largestX = j + 1;
                        largestY = i + 1;
                    }

                    PrintFormattedNumber(roll);
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Smallest number is at X{smallestX}: Y{smallestY}");
            Console.WriteLine($"Largest number is at X{largestX}: Y{largestY}");

            var flatArray = FlattenArray(array20x20);
            Array.Sort(flatArray);

            PrintSortedArray(ReshapeArray(flatArray));
        }

        private static void PrintFormattedNumber(int num)
        {
            if (num <= 9)
                Console.Write($" {num}   ");
            else if (num <= 99)
                Console.Write($" {num}  ");
            else
                Console.Write($" {num} ");
        }

        private static int[] FlattenArray(int[,] array)
        {
            var flatArray = new int[array.GetLength(0) * array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    flatArray[i * array.GetLength(1) + j] = array[i, j];
                }
            }

            return flatArray;
        }

        private static int[,] ReshapeArray(int[] flatArray)
        {
            var reshapedArray = new int[20, 20];
            for (int i = 0; i < reshapedArray.GetLength(0); i++)
            {
                for (int j = 0; j < reshapedArray.GetLength(1); j++)
                {
                    reshapedArray[i, j] = flatArray[i * reshapedArray.GetLength(1) + j];
                }
            }

            return reshapedArray;
        }

        private static void PrintSortedArray(int[,] sortedArray)
        {
            var count = 0;
            foreach (var num in sortedArray)
            {
                count++;
                PrintFormattedNumber(num);
                if (count % 20 == 0)
                    Console.WriteLine();
            }
        }
    }
}