namespace ConsoleApplication{


   public class Human {
            public string name;
            public int strength= 3;
            public int intelligence= 20;
            public int dexterity= 14;
            public int health= 100;
            public double distance;

            public double attack;

            // A constructor is called the moment an object is created
            //  using the new keyword and just requires adding a function with the same name as 
    //         //  the Class.
        public Human(string n) {
            name = n;  //variable defined within function
        }
        public Human(string n, int str, int intel, int dext, int hp){
            name = n;
            strength= str;
            intelligence=intel;
            dexterity = dext;
            health = hp;
        }
        public void Attack(object target){
            Human enemy = target as Human;
            enemy.health -= 5 * strength;
        }

        }

}