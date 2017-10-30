using System;   
using System.Collections.Generic;


namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Console.WriteLine("100");
            // Console.WriteLine(100);
            // Console.WriteLine("The {0} cow, jumped over the {1}, {2} times!" + "{0}", "brown", "Moon", 7);

            // int rings = 5;
            // if (rings >= 5){
            //     Console.WriteLine("You are welcome to join the party");
                

            // }
            // else if (rings > 2){
            // Console.WriteLine("Decent...but {0} rings aren't enough", rings);
            // }
            // else {
            //     Console.WriteLine("Go win some more rings");
            //  }

            // bool crazy = true;
            // if (!crazy){
            // Console.WriteLine("Let's party!");
            // }

            // Random num = new Random();
            // for(int val=0; val<10; val++)
            // {
            //     Console.WriteLine(num.Next(5,10));
            // }
            // Vs
            // for(int val = 0; val < 2; val++){
            //     Random rand  = new Random();
            //     //This will print the same generated value each time!!!
            //     Console.WriteLine(rand.Next(2,8));
            // }




            // ARRAYS

    //  int[] arr = {1, 2, 3, 4};
    //         Console.WriteLine("The first number of the arr is " + arr[0]); 
    //         arr[0] = 8;
    //         Console.WriteLine("The first number of the arr is now " + arr[0]);


            // string[] myCars = new string[4] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"};
            // the "4" in new string ("new" being the operator to make a new string) is the length of the new array
            // The 'Length' property tells us how many values are in the Array (4 in our example here). 
            // We can use this to determine where the loop ends: Length-1 is the index of the last value. 
            
            // for (int idx = 0; idx < myCars.Length; idx++) {
            //     Console.WriteLine("I own a {0}", myCars[idx]);
            // }

            //FOREACH AND ARRAYS
            // string[] myCars = new string[4] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"}; 
            // foreach (string car in myCars){
            //     // We no longer need the index, because variable 'car' already contains each indexed value
            //     Console.WriteLine("I own a {0}", car);
            // }


            //LISTS
            //Initializing an empty list of Motorcycle Manufacturers
//         List<string> bikes = new List<string>();
// //Use the Add function in a similar fashion to push
//         bikes.Add("Kawasaki");
//         bikes.Add("Triumph");
//         bikes.Add("BMW");
//         bikes.Add("Moto Guzzi");
//         bikes.Add("Harley Davidson");
//         bikes.Add("Suzuki");
// //Accessing a generic list value is the same as you would an array
//         Console.WriteLine(bikes[2]); //Prints "BMW"
//         Console.WriteLine("We currently know of {0} motorcycle manufacturers.", bikes.Count);


            // DICTIONARY

            Dictionary<string,string> profile = new Dictionary<string,string>();
//Almost all the methods that exists with Lists are the same with Dictionaries
                profile.Add("Name", "Speros");
                profile.Add("Language", "PHP");
                profile.Add("Location", "Greece");
                Console.WriteLine("Instructor Profile");
                Console.WriteLine("Name - " + profile["Name"]);
                Console.WriteLine("From - " + profile["Location"]);
                Console.WriteLine("Favorite Language - " + profile["Language"]);

                foreach (var entry in profile) {
                Console.WriteLine(entry.Key + " - " + entry.Value);
                }


           
        }
    }
}



