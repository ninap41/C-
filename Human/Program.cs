using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Create a base Human class with five attributes: name, strength, intelligence, dexterity, 
            //  health.  Give a default value of 3 for strength, intelligence, and dexterity. Health 
            //  should have a default of 100.  When an object is constructed from this class it should 
            //  have the ability to pass a name  Let's create an additional constructor that accepts 5 
            //  parameters, so we can set custom values for every field.  Now add a new method called 
            //  attack, which when invoked, should attack another Human object that is passed as a 
            //  parameter. The damage done should be 5 * strength (5 points of damage to the attacked, 
            //  for each 1 point of strength of the attacker).  (Optional) Change the last function to
            //   accept any object and just make sure it is of type Human before applying damage. Hint you 
            //   may need to refer back to the Boxing/Unboxing tab!

            Human myHuman1= new Human("Nina",20,5,3,100);
            Human myHuman2= new Human("Evil NPC",20,5,3,100);  
             //PASS THROUGH THINGS new box object. new invokes it to build an object.
        Console.WriteLine("Human: I am " + myHuman1.name +  " I'm durable and agile in battle, my dexterity is " + myHuman1.dexterity+ ".");
        Console.WriteLine("Enemy: I am an " + myHuman2.name + " I'm strong in battle, my health is " + myHuman2.health+ ".");
        myHuman1.Attack(myHuman2);
        Console.WriteLine("Enemy: Oh No I was Attacked! My health is now " + myHuman2.health+ ".");


        }
    }
}
