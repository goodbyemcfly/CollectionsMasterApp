using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization;

namespace CollectionsMasterConsoleUI
{
    class Program
    { 
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50 - DONE
            var numbers = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50 - DONE
            Populater(numbers);

            //TODO: Print the first number of the array - DONE
            Console.WriteLine("First Number:");
            Console.WriteLine(numbers[0]);

            //TODO: Print the last number of the array - DONE
            Console.WriteLine("Last Number:");
            int lastNumber = numbers[numbers.Length - 1];
            Console.WriteLine(lastNumber);

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists - DONE
            //NumberPrinter(); 
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            //TODO: Reverse the contents of the array and then print the array out to the console. - DONE
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");

            // Method Option #1 
            /* Array.Reverse(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]); 
            } */
            ReverseArray(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers - DONE
            Console.WriteLine("No multiples of three allowed:");
            
            ThreeKiller(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            //TODO: Sort the array in order now - DONE
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List - DONE
            var myList = new List<int>();

            //TODO: Print the capacity of the list to the console - DONE
            Console.WriteLine("Original capacity:\n" + myList.Count);

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this - DONE            
            Populater(myList);

            //TODO: Print the new capacity - DONE
            Console.WriteLine("Updated capacity:\n" + myList.Count);

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");

            int result;
            bool successfullyParsed = int.TryParse(Console.ReadLine(), out result);
            
            if (successfullyParsed)
            {
                int userInput = result;
                NumberChecker(myList, userInput);
            }
            else
            {
                Console.WriteLine("Sorry, you did not enter a valid input.");
            }

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists - DONE
            NumberPrinter(myList);
          
            //TODO: Create a method that will remove all odd numbers from the list then print results - DONE
            Console.WriteLine("Evens Only!!");
            OddKiller(myList);
            NumberPrinter(myList);

            //TODO: Sort the list then print results - DONE
            Console.WriteLine("Sorted Evens!!");
            myList.Sort();
            NumberPrinter(myList);

            //TODO: Convert the list to an array and store that into a variable - DONE
            var convertedList = myList.ToArray();

            //TODO: Clear the list - DONE
            myList.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            for (int i = numberList.Count - 1; i >= 0; i--)
            {
                if (numberList[i] % 2 != 0)
                {
                    numberList.Remove(numberList[i]);
                }
            }
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            bool containsUserInput = numberList.Contains(searchNumber);
            if (containsUserInput == true)
            {
                Console.WriteLine($"{searchNumber} IS inside the list!");
            } 
            else
            {
                Console.WriteLine($"{searchNumber} is NOT inside the list!");
            }
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(0, 50));
            }
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(0, 50);
            }
        }        

        private static void ReverseArray(int[] array)
        {
            for (int start = 0, end = array.Length - 1; start < array.Length / 2; start++, end--)
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
