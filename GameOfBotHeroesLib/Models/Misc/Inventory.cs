using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Misc
{
    public class Inventory : IInventory
    {
        public int Gold { get; private set; }
        public IList<IItem> Items { get; } = new List<IItem>();

        public void AddGold(int amount)
        {
            Gold += amount;
        }
    }
}
