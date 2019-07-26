using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Items
{
    public class Armor : IArmor
    {
        public int Defense { get; }

        public ItemType ItemType { get; }

        public ArmorTypes ArmorType { get; }
    }
}
