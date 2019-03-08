using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Skeleton : Monster, IPackable
    {

        public Skeleton(int health, string name) : base(health, name)
        {
            Strength = numberGenerator.Next(5, 7);
        }

        public override void Attack(IAttackable targetCharacter/*, dynamic binding */)
        {
            if (targetCharacter.Strength >= 2 * Strength)
                Damage = 2;
            else
                Damage = 5;

            targetCharacter.Health -= Damage;
        }

        public override string ToString()
        {
            return $"Skeleton";
        }
    }
}
