using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player : Character, IAttackable
    {
        public Player(int health, int x, int y, string name) : base(health, name)
        {
            Health = health;
            X = x;
            Y = y;
            Strength = 10;
            Damage = Strength;
        }

        public override void Attack(IAttackable targetCharacter)
        {
            targetCharacter.Health -= Damage;
        }


        public int X { get; set; }
        public int Y { get; set; }
        public Inventory Inventory { get; set; }
    }
}
