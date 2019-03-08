using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Chest : Item, IAttackable
    {
        public Chest(string name, int price, int weight) : base(name, price, weight)
        {
            Health = 20;
            Damage = 2;
            Strength = 0;
        }
        //public int Health { get; set; }
        public int Damage { get; set; }
        public int Strength { get; set; }

        public virtual void Attack(IAttackable target)
        {
            target.Health -= Damage;
        }

    }
}
