using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Creatures
{
    public class Hero : IHero
    {
        public int ID { get; }

        public CreatureTypes CreatureType { get; }

        public string Title { get; }

        public string Name { get; }

        public int Health { get; set; }

        public IInventory Inventory { get; }
    }
}
