using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Sword : Weapon, IPackable
    {
        public Sword(string name, int price, int weight) : base(name, price, weight)
        {
        }

        public override void ModifyPlayer(Character character)
        {
            character.Strength += 10;
        }
    }
}
