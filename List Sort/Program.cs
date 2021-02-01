using System;
using System.Collections.Generic;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = new List<int>();
            
            numbers.Add(1);
            numbers.Add(12);
            numbers.Add(4);
            numbers.Add(3);
            numbers.Add(7);
            numbers.Add(0);
            sortList(numbers);
            sortList(numbers);
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
                
            }
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
    }
}
