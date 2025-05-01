using System;
using DungeonExplorer;
namespace DungeonExplorer
{
        public abstract class Creature : IDamageable
        {
            public string Name { get; protected set; } // name of the creature
            public int Health { get; protected set; } // health of the creature
            public Creature(string name, int health)
            {
                Name = name;
                Health = health;
            }
            public abstract void Attack(Creature target); // this is the abstract method for attacking

            public void TakeDamage(int damage) // this will decrease the health of the enemy
            {
                Health -= damage;
                if (Health < 0) Health = 0; // if health is less than the number 0 then it will set the new number to 0
                Console.WriteLine($"{Name} has taken {damage} damage. Their Current Health is at {Health}");
            }
            public void Heal(int amount)
            {
                Health += amount; // this will increase the health of the player
                Console.WriteLine($"{Name} has healed {amount} health. Your Current Health is currently now at {Health}");
            }
        }
        public class Monster : Creature
        {
            public Monster(string name, int health) : base(name, health)
            {
            }

            public override void Attack(Creature target)
            {
                Console.WriteLine($"{Name} attacks {target.Name}");
                target.TakeDamage(5);
            }
        }

        public class Vampire : Monster
        {
            public Vampire() : base("Vampire", 30) { }
            public override void Attack(Creature target)
            {
                Console.WriteLine($"{Name} attacks {target.Name} with their fangs!!!");
                target.TakeDamage(20);
            }
        }
        public class Werewolf : Monster
        {
            public Werewolf() : base("Werewolf", 45) { }
            public override void Attack(Creature target)
            {
                Console.WriteLine($"{Name} sli {target.Name} with their claws!!");
                target.TakeDamage(15);
            }
        }
    }



