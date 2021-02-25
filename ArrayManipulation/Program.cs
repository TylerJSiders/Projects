using System;

namespace EX6A_ArrayManipulation
{
    class Program
    {

        public enum Direction {RIGHT, LEFT };
        static void Main(string[] args)
        {
            int[] ArrayA = { 0, 2, 4, 6, 8, 10 };
            int[] ArrayB = { 1, 3, 5, 7, 9 };
            int[] ArrayC = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };
            Console.Write("Array A is ");
            printArray(ArrayA);
            Console.Write("Array B is ");
            printArray(ArrayB);
            Console.Write("Array C is ");
            printArray(ArrayC);


            Console.WriteLine($"The Mean of Array A is {Mean(ArrayA)}.");
            Console.WriteLine($"The Mean of Array B is {Mean(ArrayB)}.");
            Console.WriteLine($"The Mean of Array C is {Mean(ArrayC)}.\n");


            Console.Write("The Reverse of Array A is: ");
            int[] ArrayAReverse = Reverse(ArrayA);
            printArray(ArrayAReverse);
            Console.Write("The Reverse of Array B is: ");
            int[] ArrayBReverse = Reverse(ArrayB);
            printArray(ArrayBReverse);
            Console.Write("The Reverse of Array C is: ");
            int[] ArrayCReverse = Reverse(ArrayC);
            printArray(ArrayCReverse);





            Console.WriteLine("Array C sorted is");
            Sort(ArrayC);
            printArray(ArrayC);
            Console.WriteLine("\n");
            Rotate(ArrayA, Direction.LEFT, 2);
            Rotate(ArrayB, Direction.RIGHT, 2);
            Rotate(ArrayC, Direction.LEFT, 4);
            Console.WriteLine("Array A Rotated Left by 2.");
            printArray(ArrayA);
            Console.WriteLine("Array B Rotated Right by 2.");
            printArray(ArrayB);
            Console.WriteLine("Array C Rotated Left by 4.");
            printArray(ArrayC);



            Console.ReadKey();
        }

        public static void printArray(int[] Array)
        {
            foreach (int number in Array)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("\n");
        }


        public static double Mean(int[] array)
        {
            double sum = 0;
            double count = 0;
            foreach (int number in array)
            {
                count += 1;
                sum += number;
            }
            double average = sum / count;
            return average;
        }

        public static int[] Reverse(int[] array)
        {
            int count = 0;
            int[] Reversed = new int[array.Length];
            for (int i = array.Length - 1; i > 0; i--)
            {
                Reversed[count] = array[i];
                count++;
            }
            return Reversed;
        }

        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }

        public static void Rotate(int[] Array, Direction direction, int numberOfSpaces)
        {
            if (direction == Direction.RIGHT)
            {
                for (int i = 0; i < numberOfSpaces; i++)
                {
                    RotateRight(Array);
                }
            }
            else if (direction == Direction.LEFT)
            {
                for (int i = 0; i < numberOfSpaces; i++)
                {
                    RotateLeft(Array);
                }
            }
        }

        public static void RotateRight(int[] Array)
        {
            int temp = Array[Array.Length-1];
            for (int i = Array.Length - 1; i > 0; i--)
            {
                Array[i] = Array[i - 1];
            }

            Array[0] = temp;

        }





        //Copy Pasted Code and used it to help my Logic for the rotate right function
        //What I learned from this was how to "Wrap Around" an array in a for loop.
        static void RotateLeft(int[] Array)
        {
            int temp = Array[0];
            for (int i = 0; i < Array.Length - 1; i++)
               Array[i] = Array[i + 1];

            Array[Array.Length - 1] = temp;
        }
    }
}
