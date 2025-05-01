using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public interface IDamageable
    {
        int Health { get; }
        void TakeDamage(int damage);
    }

    public interface ICollectible
    {
        string Name { get; }
        void Use(Creature target);
    }

}
