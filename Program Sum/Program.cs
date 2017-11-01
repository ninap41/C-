using System;
using System.Collections.Generic;

namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
        
            FundamentalsI();
            CollectionsPractice();
            BoxingUnboxing();

            //Basic13
            /
            Print1to255();
            PrintOdd1to255();
            PrintSum();
            IterateArray();
            FindMax();
            GetAverage(new List<int>(new int[] { 2, 10, 3 }));
            OddArray();
            GreaterThanY(new List<int>(new int[] { 1, 3, 5, 7 }), 3);
            SquareValues(new List<int>(new int[] { 1, 5, 10, -2 }));
            EliminateNegatives(new List<int>(new int[] { 1, 5, 10, -2 }));
            MinMaxAvg(new List<int>(new int[] { 1, 5, 10, -2 }));
            ShiftArray(new List<int>(new int[] { 1, 5, 10, -2 }));
            NumToString(new List<object>(new object[] { -1, -3, 2 }));
            RandomArray();

            Console.WriteLine("The ratio of heads to tosses is {0}", TossMultipleCoins(50));

            var x = Names(new List<string>(new string[] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"}));
            
        }

        static void FundamentalsI()
        {
            Console.WriteLine("print all values from 1-255:");

            for (int i = 1; i <= 255; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("print all values from 1-100 that are divisible by 3 or 5, but not both");

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    if (!(i % 3 == 0 && i % 5 == 0))
                    {
                        Console.Write(i + " ");
                    }
                }
            }

            Console.WriteLine(); 
            Console.WriteLine();
            Console.WriteLine("print [Fizz] for multiples of 3, [Buzz] for multiples of 5, and [FizzBuzz] for numbers that are multiples of both 3 and 5:");

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.Write("[Fizz] ");
                }
                if (i % 5 == 0)
                {
                    Console.Write("[Buzz] ");
                }
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Console.Write("[FizzBuzz] ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("If you used modulus in the last step, try doing the same without using it. Vice-versa for those who didn't!:");

            for (int i = 1; i <= 100; i++)
            {
                var q3 = i / 3;
                var p3 = q3 * 3;
                var m3 = i - p3;

                var q5 = i / 5;
                var p5 = q5 * 5;
                var m5 = i - p5;


                if (m3 == 0)
                {
                    Console.Write("[Fizz] ");
                }
                if (m5 == 0)
                {
                    Console.Write("[Buzz] ");
                }
                if (m3 == 0 || m5 == 0)
                {
                    Console.Write("[FizzBuzz] ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Generate 10 random values and output the respective word, in relation to step three, for the generated values");

            Random rand = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var next = rand.Next(1, 100);

                if (next % 3 == 0)
                {
                    Console.Write("[Fizz] ");
                }
                if (next % 3 == 0)
                {
                    Console.Write("[Buzz] ");
                }
                if (next % 3 == 0 || next % 5 == 0)
                {
                    Console.Write("[FizzBuzz] ");
                }
            }
        }
        static void CollectionsPractice()
        {
            // Three Basic Arrays

            // Create an array to hold integer values 0 through 9
            List<int> numbers = new List<int>();
            for (int i = 0; i <= 9; i++)
            {
                numbers.Add(i);
            }

            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            List<string> names = new List<string>();
            names.Add("Tim");
            names.Add("Martin");
            names.Add("Nikki");
            names.Add("Sara");

            // Create an array of length 10 that alternates between true and false values, starting with true
            List<bool> booleans = new List<bool>();
            bool theBool = true;
            for (int i = 0; i < 10; i++)
            {
                booleans.Add(theBool);
                theBool = !theBool;
            }

            // Multiplication Table
            // With the values 1-10, use code to generate a multiplication table
            int[,] multiplactionTable = new int[10, 10];
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    multiplactionTable[i - 1, j - 1] = i * j;
                }
            }

            // List of Flavors
            Console.WriteLine("Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)");

            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Pistachio");
            flavors.Add("Rocky Road");

            Console.WriteLine("Output the length of this list after building it");
            Console.WriteLine("You have {0} flavors to choose from.", flavors.Count);

            Console.WriteLine("Output the third flavor in the list, then remove this value.");
            Console.WriteLine("The third flavor is {0}.", flavors[2]);
            flavors.RemoveAt(2);

            Console.WriteLine("Output the new length of the list (Note it should just be one less~)");
            Console.WriteLine("You now have {0} flavors to choose from.", flavors.Count);

            // User Info Dictionary
            Console.WriteLine("Create a Dictionary that will store both string keys as well as string values");
            Dictionary<string, string> userInfo = new Dictionary<string, string>();

            Console.WriteLine("For each name in the array of names you made previously, add it as a new key in this dictionary with value null");
            for (int i = 0; i <= names.Count - 1; i++)
            {
                userInfo.Add(names[i], null);
                Console.WriteLine("Added the name {0}.", names[i]);
            }

            Console.WriteLine("For each name key, select a random flavor from the flavor list above and store it as the value");
            Random rand = new Random();
            var keys = new List<string>(userInfo.Keys);
            foreach (string key in keys)
            {
                userInfo[key] = flavors[rand.Next(0, 3)];
                Console.WriteLine("Setting {0}'skin flavor to {1}", key, userInfo[key]);
            }

            Console.WriteLine("Loop through the Dictionary and print out each user's name and their associated ice cream flavor.");

            foreach (var user in userInfo)
            {
                Console.WriteLine("The user is {0}, and their associated flavor is {1}", user.Key, user.Value);
            }
        }
        static void BoxingUnboxing()
        {
            Console.WriteLine("Create an empty List of type object");
            List<object> objList = new List<object>();

            Console.WriteLine("Add the following values to the list: 7, 28, -1, true, 'chair'");
            objList.Add(7);
            objList.Add(28);
            objList.Add(-1);
            objList.Add(true);
            objList.Add("chair");

            Console.WriteLine("Loop through the list and print all values (Hint: Type Inference might help here!)");
            int sum = 0;
            foreach (var obj in objList)
            {
                Console.WriteLine(obj);

                if (obj is int)
                {
                    sum += (int)obj;
                }
            }
            Console.WriteLine("Add all values that are Int type together and output the sum");
            Console.WriteLine("The sum of the ints is: {0}", sum);
        }
        static void Print1to255()
        {
            Console.WriteLine("Print 1-255");
            for (int i = 0; i <= 255; i++)
            {
                Console.Write("{0} ", i);
            }
        }
        static void PrintOdd1to255()
        {
            Console.WriteLine("Print odd numbers between 1-255");
            for (int i = 1; i <= 255; i += 2)
            {
                Console.Write("{0} ", i);
            }
        }
        static void PrintSum()
        {
            Console.WriteLine("Print Sum");
            int sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                Console.WriteLine("New number: {0} Sum: {1}", i, sum);
                sum += i;
            }
        }
        static void IterateArray()
        {
            Console.WriteLine("Iterating through an Array");
            List<int> mylist = new List<int>(new int[] { 1, 3, 5, 7, 9, 13 });
            for (int i = 0; i < mylist.Count; i++)
            {
                Console.Write("{0} ", mylist[i]);
            }
        }
        static void FindMax()
        {
            Console.WriteLine("Find Max");
            List<int> maxList = new List<int>(new int[] { 1, 3, 5, 7, 9, -13, 100, -25, 0, 99 });
            int max = maxList[0];
            int total = maxList[0];
            for (int i = 1; i < maxList.Count; i++)
            {
                if (maxList[i] > max) { max = maxList[i]; }
                total += maxList[i];
            }
            Console.WriteLine("The max of the array is {0}", max);
            Console.WriteLine("Get Average");
            Console.WriteLine("The average of the array is {0}", total / maxList.Count);
        }
        static void GetAverage(List<int> array)
        {
            int sum = array[0];
            for (int i = 1; i < array.Count; i++)
            {
                sum += array[i];
            }
            Console.WriteLine("The Average of the array is {0}", sum / array.Count);
        }
        static void OddArray()
        {
            Console.WriteLine("Array with Odd Numbers");
            List<int> oddList = new List<int>();
            for (int i = 1; i <= 255; i += 2)
            {
                oddList.Add(i);
            }
            Console.Write(oddList);
        }
        static void GreaterThanY(List<int> array, int y)
        {
            Console.WriteLine("Greater than Y");
            int count = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] > y) { count++; }
            }
            Console.WriteLine("There are {0} items greater than {1} in the array", count, y);
        }
        static void SquareValues(List<int> array)
        {
            Console.WriteLine("Square the Values");
            Console.WriteLine("The array before squaring is {0}", array);
            for (int i = 0; i < array.Count; i++)
            {
                array[i] = array[i] * array[i];
            }
            Console.WriteLine("The array after squaring is {0}", array);
        }
        static void EliminateNegatives(List<int> array)
        {
            Console.WriteLine("Eliminate Negative Numbers");
            Console.WriteLine("The array before eliminating negatives is {0}", array);
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < 0) { array[i] = 0; }
            }
            Console.WriteLine("The array after eliminating negatives is {0}", array);
        }

        static void MinMaxAvg(List<int> minMaxAvg)
        {
            Console.WriteLine("Min, Max, and Average");
            int min = minMaxAvg[0];
            int max2 = minMaxAvg[0];
            int sum2 = minMaxAvg[0];
            int average = 0;
            for (int i = 1; i < minMaxAvg.Count; i++)
            {
                if (minMaxAvg[i] < min) { min = minMaxAvg[i]; }
                if (minMaxAvg[i] > max2) { max2 = minMaxAvg[i]; }
                sum2 += minMaxAvg[i];
            }
            average = sum2 / minMaxAvg.Count;
            Console.WriteLine("The min is {0}, the max is {1}, and the average is {2}", min, max2, average);
        }
        static void ShiftArray(List<int> shiftArray)
        {
            Console.WriteLine("Shifting the values in an array");
            for (int i = 0; i < shiftArray.Count - 1; i++)
            {
                shiftArray[i] = shiftArray[i + 1];
            }
            shiftArray[shiftArray.Count - 1] = 0;
            Console.WriteLine("The shifted array is {0}.", shiftArray);
        }

        static void NumToString(List<object> numToString)
        {
            Console.WriteLine("Number to String");
            for (int i = 0; i < numToString.Count; i++)
            {
                if ((int)numToString[i] < 0) { numToString[i] = "Dojo"; }
            }
            Console.WriteLine("The array after removing negatives is: {0}", numToString);
        }

        // Random Array
        // Create a function called RandomArray() that returns an integer array
        // Place 10 random integer values between 5-25 into the array
        // Print the min and max values of the array
        // Print the sum of all the values
        static List<int> RandomArray()
        {
            List<int> array = new List<int>();
            Random rand = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                int newVal = rand.Next(5, 25);
                array.Add(newVal);
                Console.WriteLine("Adding {0} to the array", newVal);
            }
            int min = array[0];
            int max = array[0];
            int sum = array[0];
            for (int i = 1; i < array.Count; i++)
            {
                sum += array[i];
                if (array[i] < min) {min = array[i];}
                if (array[i] > max) {max = array[i];}
            }

            Console.WriteLine("The min is {0}", min);
            Console.WriteLine("The max is {0}", max);
            Console.WriteLine("The sum is {0}", sum);
        
            return array;
        }

        // Coin Flip
        // Create a function called TossCoin() that returns a string
        // Have the function print "Tossing a Coin!"
        // Randomize a coin toss with a result signaling either side of the coin 
        // Have the function print either "Heads" or "Tails"
        // Finally, return the result
        
        static string TossCoin(Random rand){
            
            //Console.Write("Tossing a Coin! ");

            int toss = rand.Next(0, 2);
            //Console.Write("Current flip is {0} ", toss);
            string result = ""; 

            if(toss == 0){result = "Heads";}
            else {result = "Tails";}

            Console.Write("{0}! ", result);
            //Console.WriteLine();
            return result;
        }

        // Create another function called TossMultipleCoins(int num) that returns a Double
        // Have the function call the tossCoin function multiple times based on num value
        // Have the function return a Double that reflects the ratio of head toss to total toss
        static double TossMultipleCoins(int num){
            Random rand = new Random();
            List<string> results = new List<string>();
            int headCount = 0;
            for(int i = 0; i <= num; i++){
                if(TossCoin(rand) == "Heads"){ headCount++;}
            }
            Console.WriteLine();
            Console.WriteLine("Head Count is {0}", headCount);
            return (double) headCount/num;
        }

        // Names
        // Build a function Names that returns an array of strings
        // Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        // Shuffle the array and print the values in the new order
        // Return an array that only includes names longer than 5 characters
        public static List<string> Names(List<string> names)  
        {  
            Random rng = new Random(DateTime.Now.Millisecond);             
            int n = names.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                string value = names[k];  
                names[k] = names[n];  
                names[n] = value;  
            }  

            List<string> newArray = new List<string>();
            for(int i = 0; i < names.Count; i++){
                Console.WriteLine(names[i]);
                if(names[i].Length > 5){
                    newArray.Add(names[i]);
                }
            }
            return newArray;
        }
    }
}
