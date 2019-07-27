using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IShopItem
    {
        int Price { get; }
        int StockQuantity { get; }
        IItem Item { get; }
    }
}
