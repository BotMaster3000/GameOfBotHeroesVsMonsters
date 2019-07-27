using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Models.Shops
{
    public class Shop : IShop
    {
        public ShopTypes ShopType { get; }
        public IShopInventory ShopInventory { get; }

        public Shop(ShopTypes shopType, IShopItem[] shopItems)
        {
            ShopType = shopType;
            ShopInventory = new ShopInventory(shopItems);
        }
    }
}
