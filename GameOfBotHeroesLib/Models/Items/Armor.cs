using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Items
{
    public class Armor : IArmor
    {
        public ItemTypes ItemType { get; } = ItemTypes.Armor;
        public ArmorTypes ArmorType { get; }
        public int DefenseValue { get; }

        public Armor(ArmorTypes armorType, int defenseValue)
        {
            ArmorType = armorType;
            DefenseValue = defenseValue;
        }

        public static Armor GetArmor(ArmorTypes armorType)
        {
            return armorType switch
            {
                ArmorTypes.CopperArmor => new Armor(armorType, 10),
                ArmorTypes.IronArmor => new Armor(armorType, 15),
                _ => null
            };
        }
    }
}
