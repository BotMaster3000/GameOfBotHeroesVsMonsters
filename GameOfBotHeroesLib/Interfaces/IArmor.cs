using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface IArmor : IItem
    {
        int DefenseValue { get; }
        ArmorTypes ArmorType { get; }
    }
}
