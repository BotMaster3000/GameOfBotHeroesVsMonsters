using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.Misc;

namespace GameOfBotLib.Models.Creatures
{
    public class Monster : IMonster
    {
        public int ID { get; }
        public CreatureTypes CreatureType { get; }
        public int Health { get; set; }
        public int MaxHealth { get; }
        public IInventory Inventory { get; } = new Inventory();
        public int Experience { get; }
        public int Level { get; } = 1;

        public Monster(CreatureTypes creatureType, int health, int maxHealth, int id)
        {
            CreatureType = creatureType;
            Health = health;
            MaxHealth = maxHealth;
            ID = id;
        }
    }
}
