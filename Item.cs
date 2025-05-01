using System;

namespace DungeonExplorer
{
    public abstract class Item
    {
        public string Name { get; protected set; } // this is the name of the item 

        public Item(string name)
        {
            Name = name;
        }
        public abstract void Use(Creature target);
    }
    public class Weapon : Item
    {
        public int Damage { get; private set; } // this is the damage done by the weapon

        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }
        public override void Use(Creature target)
        {
            Console.WriteLine($"{Name} has been used to attack {target.Name}");
            target.TakeDamage(Damage);
        }
    }
    public class Potion : Item
    {
        public int HealAmount { get; private set; } // this is the amount of health that will be healed by the potion
        public Potion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }
        public override void Use(Creature target)
        {
            Console.WriteLine($"{Name} was used to heal {target.Name}");
            target.Heal(HealAmount); // this increases teh health of the target.
        }
    }
}