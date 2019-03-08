using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : IPackable
    {
        public Item(string name, int price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public string Name { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public int Health { get; set; }

        public virtual void ModifyPlayer(Character character)
        {
        }
    }
}
