using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface IWeapon : IItem
    {
        int AttackValue { get; }
        WeaponTypes WeaponType { get; }
    }
}
