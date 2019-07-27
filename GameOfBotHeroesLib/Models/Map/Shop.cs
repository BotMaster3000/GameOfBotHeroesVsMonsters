using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Map
{
    public class Shop : IShop
    {
        public ShopTypes ShopType { get; }
    }
}
