using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IHero : IIntelligentCreature
    {
        IInventory Inventory { get; }
    }
}
