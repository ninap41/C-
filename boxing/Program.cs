using System;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<object> a_string = new List<object>();

            a_string.Add(7);
            a_string.Add(28);
            a_string.Add(-1);
            a_string.Add("true");
            a_string.Add("chair");
            // Console.WriteLine(a_string[0]);
            // Console.WriteLine(a_string[1]);
            // Console.WriteLine(a_string[2]);
            // Console.WriteLine(a_string[3]);
            int sum = 0;
            foreach(object thing in a_string){
                Console.WriteLine(thing);
                if(thing is int){
                    System.Console.WriteLine("we made it here");
                    int num = (int)thing;
                    sum  = sum + num;
                }
            }
            Console.WriteLine(sum);
        
        }
    }
}
