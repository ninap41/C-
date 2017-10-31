
namespace ConsoleApplication{
public class Human
{ //get set
    public string name;

    public int health { get; set; }
    public int strength { get; set; }
    public int intelligence { get; set; }
    public int dexterity { get; set; }


    public Human(string name, int val) {
        name = name
        strength = strength;
        intelligence = intelligence;
        dexterity = dexterity;
        health = health;
    }
    public Human(string name, int strength, int intelligence, int dexterity, int health) {
        name = name
        strength = strength;
        intelligence = intelligence;
        dexterity = dexterity;
        health = health;
    }
    public void attack(object obj)
    {
        Human enemy = obj as Human;
        if(enemy == null)
        {
            console.WriteLine("Failed Attack");

        }
        else
        {
            enemy.health -= strength * 5;
        }
    }
}
}
