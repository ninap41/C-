using System;
using System.Collections.Generic;


namespace ConsoleApplication   //Change!?!?! from WizardNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Human myHuman1= new Human("Nina",20,5,3,100);
            // Wizard thewizard= new Wizard();
            Console.WriteLine("Hello World!");
            Console.WriteLine("Human: I am " + myHuman1.name +  " I'm durable and agile in battle, my dexterity is " + myHuman1.dexterity+ ".");
 

        }
    }
}
