using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface ICreature
    {
        int ID { get; }
        CreatureTypes CreatureType { get; }

        int Health { get; set; }
        int MaxHealth { get; }

        int Experience { get; }
        int Level { get; }
    }
}
