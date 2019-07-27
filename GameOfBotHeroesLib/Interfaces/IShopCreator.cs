using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface IShopCreator
    {
        IShop CreateShop(ShopTypes shopType, IShopItem[] shopItems);
        IShop GenerateRandomShop(ShopTypes shopType);
    }
}
