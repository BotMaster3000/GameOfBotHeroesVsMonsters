using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Shops
{
    public class ShopInventory : IShopInventory
    {
        public IShopItem[] ShopItems { get; }

        public ShopInventory(IShopItem[] shopItems)
        {
            ShopItems = shopItems;
        }
    }
}
