using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Monster : NonPlayerCharacter, IAttackable
    {
        public Monster(int health, string name) : base (health, name)
        {
            NumberOfMonsters++;
        }

        static public int NumberOfMonsters { get; set; }
    }
}
