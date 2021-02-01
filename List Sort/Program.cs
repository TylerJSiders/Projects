using System;
using System.Collections.Generic;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            bool acceptingNumbers = true;
            List<int> numbers = new List<int>();
            Console.WriteLine("Please insert a random list of numbers. Type \"Done\" when finished.");

            while (acceptingNumbers)
            {
                acceptingNumbers = NumberInput(acceptingNumbers, numbers);
            }

            sortList(numbers);
            printList(numbers);
        }

        private static bool NumberInput(bool acceptingNumbers, List<int> numbers)
        {
            Console.Write("Please enter a number: ");
            string input = Console.ReadLine();
            int numInput;
            if (Int32.TryParse(input, out numInput))
            {
                numbers.Add(numInput);
            }
            else
            {
                if (input == "Done" || input == "DONE" || input == "done")
                {
                    acceptingNumbers = false;
                }
                else
                    Console.WriteLine("Your input has to be a number, or \"Done\".");
            }

            return acceptingNumbers;
        }

        static public List<int> sortList(List<int> numberList)
        {
            int number = numberList[0] ;
            for (int i = 0; i < numberList.Count; i++)
            {
               if (number > numberList[i])
               {
                    int intermediate = numberList[i];
                    numberList[i] = number;
                    numberList[i - 1] = intermediate;

                    //These two statements restart the loop from the beginning 
                    i = 0;
                    number = numberList[0];
               }
               else
               {
                    number = numberList[i];
               }
            }
            return numberList;
        }

        static public void printList(List<int> numberList)
        {
            foreach (int number in numberList)
            {
                Console.WriteLine(number);
            }
        }
    }
}
//if (Int32.TryParse(input, out numInput))
//{
//    numbers.Add(numInput);
//}
//else
//{
//    if (input == "Done" || input == "DONE" || input == "done")
//    {
//        acceptingNumbers = false;
//    }
//    else
//        Console.WriteLine("Your input has to be a number, or \"Done\".");
//}