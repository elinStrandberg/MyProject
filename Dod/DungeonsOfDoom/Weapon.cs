using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Weapon : Item
    {
        public Weapon(string name, int price, int weight) : base(name, price, weight)
        {
        }

        public int Damage { get; set; }
        public int Durability { get; set; }
    }
}
