using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface IShopItemGenerator
    {
        public IShopItem[] RandomGenerateShopItems(ShopTypes shopType, int minItems, int maxItems);
    }
}
