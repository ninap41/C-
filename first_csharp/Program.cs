using System;   

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

            int rings = 5;
            if (rings >= 5){
                Console.WriteLine("You are welcome to join the party");
                

            }
            else if (rings > 2){
            Console.WriteLine("Decent...but {0} rings aren't enough", rings);
            }
            else {
                Console.WriteLine("Go win some more rings");
             }

            // bool crazy = true;
            // if (!crazy){
            // Console.WriteLine("Let's party!");
            // }

            Random num = new Random();
            for(int val=0; val<10; val++)
            {
                Console.WriteLine(num.Next(5,10));
            }
            // Vs
            for(int val = 0; val < 2; val++){
                Random rand  = new Random();
                //This will print the same generated value each time!!!
                Console.WriteLine(rand.Next(2,8));
            }



           
        }
    }
}



