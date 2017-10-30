using System;
using System.Collections.Generic;



namespace multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // // Three Basic Arrays
            // // Create an array to hold integer values 0 through 9
            // // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            // // Create an array of length 10 that alternates between true and false values, starting with true
            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            for(int i = 0; i < arr.Length; i++){
            Console.WriteLine(arr[i]);
            }

            string[] people = new string[4] {"Tim", "Martin", "Nikki","Sara"};
            foreach(string person in people){
            Console.WriteLine("Hey this is {0}", person);
            }

            int[] true_false= {1,0,1,0,1,0};
            for(int i = 0; i <true_false.Length; i++){
                if(i == 0){
                    Console.WriteLine("True");
                    }
                else{
                    Console.WriteLine("False");
                }
            
            }

            

            //multiplication table in 2d array
            // int[] numbers = {1,2,3,4,5,6,7,8,9,10};
           
            for(int i = 1; i <=10; i++){
                Console.Write("[");
                for(int x = 1; x <=10; x++) {
                    Console.Write(i * x + "\t");
                }
                 Console.Write("]");
            }








        //     for (int i = 2; i <= 12; i++)
        // {
        //     for (int j = 1; j <= 10; j++)
        //     {
        //         Console.WriteLine("{0}*{1}={2}", i, j, i*j);
        //     }
        // }
        


            // List of Flavors 

            List<string> icecream = new List<string>();

            icecream.Add("Chocolate");
            icecream.Add("Strawberry");
            icecream.Add("Vanilla");
            icecream.Add("Sherbert");

            Console.WriteLine(icecream.Count);

            icecream.Insert(2,"Cookie Dough");
            icecream.Remove("Chocolate");
            foreach(string thing in icecream){
             Console.WriteLine(thing);   
            }
           
            // User Info Dictionary   


             Dictionary<string,string> profile = new Dictionary<string,string>();
                 Random rand = new Random();
                profile.Add("Name", "Nina");
                profile.Add("Language", "Javascript");
                profile.Add("Location", "US");
                profile.Add("City", null);
                profile.Add("Favorite Icecream flavor", "Chocolate Chip Cookie Dough");
                foreach (KeyValuePair<string,string> info in profile)
                {
            Console.WriteLine(info.Key + " - " + info.Value);
                }
            //      foreach(string entry in profile)
            // {
            //     profile[entry] = icecream[rand.Next(icecream.Count)];
            // }
                  

    
    //  Dictionary<string, string> userInfo = new Dictionary<string,string>();
    //         Random rand = new Random();
    //          profile.Add("Name", "Nina");
    //             profile.Add("Language", "Javascript");
    //             profile.Add("Location", "US");
    //             profile.Add("City", null);
    //             profile.Add("Favorite Icecream flavor", "Chocolate Chip Cookie Dough");

    //         foreach(string thing in profile)
    //         {
    //             userInfo[thing] = icecream[rand.Next(icecream.Count)];
    //         }
        
    //         Console.WriteLine("Users and their favor ice cream flavors:");
    //         foreach(KeyValuePair<string, string> info in userInfo)
    //         {
    //             Console.WriteLine(info.Key + " - " + info.Value);
    //         }


    

        //     //Looping through info Dictionary
        //     Console.WriteLine("Users and their favor ice cream flavors:");
        //     foreach(KeyValuePair<string, string> info in userInfo)
        //     {
        //         Console.WriteLine(info.Key + " - " + info.Value);
        //     }
        // }





        
        }
    }
}
