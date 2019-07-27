using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Items
{
    public class Armor : IArmor
    {
        public ItemType ItemType { get; } = ItemType.Armor;
        public ArmorTypes ArmorType { get; }
        public int DefenseValue { get; }

        public Armor(ArmorTypes armorType, int defenseValue)
        {
            ArmorType = armorType;
            DefenseValue = defenseValue;
        }
    }
}
