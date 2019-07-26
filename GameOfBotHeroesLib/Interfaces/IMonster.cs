using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IMonster : ICreature
    {
        IInventory Inventory { get; }
    }
}
