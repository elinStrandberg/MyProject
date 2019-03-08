using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class WhiteWalker : Monster, IPackable
    {
        public WhiteWalker(int health, string name) : base(health, name)
        {
            Damage = 50;
        }

        public override string ToString()
        {
            return $"White Walker";
        }
    }
}
