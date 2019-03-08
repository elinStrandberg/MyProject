using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    abstract partial class Character: IPackable
    {
        protected Random numberGenerator = new Random();

        public Character(int health, string name)
        {
            Health = health;
            Name = name;
            Damage = 1;
        }

        public int Damage { get; set; }
        public int Health { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }

        private int strength;

        public int Strength
        {
            get { return strength; }
            set { strength = value; Damage = strength; }
        }

        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public virtual void Attack(IAttackable targetCharacter/*, Character attackingCharacter*/)
        {
            targetCharacter.Health -= Damage;
        }
    }
}
