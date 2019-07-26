using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Items
{
    public class Weapon : IWeapon
    {
        public int Attack { get; }

        public ItemType ItemType { get; }
        public WeaponTypes WeaponType { get; }
    }
}
