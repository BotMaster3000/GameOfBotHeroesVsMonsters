using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Models.Shops
{
    public class ShopItem : IShopItem
    {
        public IItem Item { get; }
        public int Price { get; }
        public int StockQuantity { get; }

        public ShopItem(IItem item, int price, int stockQuantity)
        {
            Item = item;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }
}
