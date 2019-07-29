using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IInventory
    {
        int Gold { get; }
        IList<IItem> Items { get; }

        void AddGold(int amount);
    }
}
