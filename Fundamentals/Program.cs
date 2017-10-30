using System;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // Print all the valeus between 1- 255
            for(int val= 1; val <= 255; val++){
                Console.WriteLine(val);
            }
            //Print values divisible by 3 and 5 but not both
            for(int val= 1; val <= 100; val++){
                if(val % 3 == 0 && val % 5 != 0)
                Console.WriteLine(val);
                if(val % 5 == 0 && val % 3 != 0)
                Console.WriteLine(val);
            }
            //Print without modulus
            for(int val= 1; val <= 100; val++){
                if(val % 3 == 0 && val % 5 != 0)
                Console.WriteLine(val);
            }


            //modify to print "Fizz" for multiples of 3. multiples of 5 "Buzz"
             for(int val= 1; val <= 100; val++){
                if(val % 3 == 0 && val % 5 != 0)
                Console.WriteLine("Fizz");
                if(val % 5 == 0 && val % 3 != 0)
                Console.WriteLine("Buzz");
            }



        }
    }
}
