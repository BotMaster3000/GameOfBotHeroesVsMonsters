using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Items
{
    public class Weapon : IWeapon
    {
        public ItemType ItemType { get; } = ItemType.Weapon;
        public WeaponTypes WeaponType { get; }
        public int AttackValue { get; }

        public Weapon(WeaponTypes weaponType, int attackValue)
        {
            WeaponType = weaponType;
            AttackValue = attackValue;
        }
    }
}
