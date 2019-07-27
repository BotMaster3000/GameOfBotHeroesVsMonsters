using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.Shops;

namespace GameOfBotLib.Logic
{
    public class ShopCreator : IShopCreator
    {
        public IShop CreateShop(ShopTypes shopType, IShopItem[] shopItems)
        {
            return new Shop(shopType, shopItems);
        }

        public IShop GenerateRandomShop(ShopTypes shopType)
        {
            ShopItemGenerator itemGenerator = new ShopItemGenerator();
            IShopItem[] shopItems = itemGenerator.RandomGenerateShopItems(shopType, 10, 50);

            return new Shop(shopType, shopItems);
        }
    }
}
