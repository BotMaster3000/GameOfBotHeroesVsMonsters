using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Items
{
    public class Weapon : IWeapon
    {
        public ItemTypes ItemType { get; } = ItemTypes.Weapon;
        public WeaponTypes WeaponType { get; }
        public int AttackValue { get; }

        public Weapon(WeaponTypes weaponType, int attackValue)
        {
            WeaponType = weaponType;
            AttackValue = attackValue;
        }

        public static Weapon GetWeapon(WeaponTypes weaponType)
        {
            return weaponType switch
            {
                WeaponTypes.Sword => new Weapon(weaponType, 10),
                WeaponTypes.Axe => new Weapon(weaponType, 8),
                WeaponTypes.Spear => new Weapon(weaponType, 5),
                _ => null
            };
        }
    }
}
