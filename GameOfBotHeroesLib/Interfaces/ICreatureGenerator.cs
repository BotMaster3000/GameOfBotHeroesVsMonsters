using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface ICreatureGenerator
    {
        ICreature GenerateCreature(CreatureTypes creatureType);
        ICreature[] GenerateCreatures(CreatureTypes creatureType, int amount);
    }
}
