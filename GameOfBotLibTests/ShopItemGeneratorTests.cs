using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Logic;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using System.Threading.Tasks;

namespace GameOfBotLibTests
{
    [TestClass]
    public class ShopItemGeneratorTests
    {
        private const int MinItems = 50;
        private const int MaxItems = 100;

        private const int TotalRuns = 100;

        [TestMethod]
        public void RandomGenerateShopItemsTest_Tavern()
        {
            const ShopTypes Type = ShopTypes.Tavern;
            AssertShopItemsAreGenerated(Type);
        }

        [TestMethod]
        public void RandomGenerateShopItemsTest_Inn()
        {
            const ShopTypes Type = ShopTypes.Inn;
            AssertShopItemsAreGenerated(Type);
        }

        [TestMethod]
        public void RandomGenerateShopItemsTest_ArmorShop()
        {
            const ShopTypes Type = ShopTypes.ArmorShop;
            AssertShopItemsAreGenerated(Type);
        }

        [TestMethod]
        public void RandomGenerateShopItemsTest_WeaponShop()
        {
            const ShopTypes Type = ShopTypes.WeaponShop;
            AssertShopItemsAreGenerated(Type);
        }

        [TestMethod]
        public void RandomGenerateShopItemsTest_ItemShop()
        {
            const ShopTypes Type = ShopTypes.ItemShop;
            AssertShopItemsAreGenerated(Type);
        }

        [TestMethod]
        public void RandomGenerateShopItemsTest_BitOfEverythingShop()
        {
            const ShopTypes Type = ShopTypes.BitOfEverythingShopType;
            AssertShopItemsAreGenerated(Type);
        }

        private void AssertShopItemsAreGenerated(ShopTypes shopType)
        {
            ShopItemGenerator itemGenerator = new ShopItemGenerator();
            for (int i = 0; i < TotalRuns; ++i)
            {
                IShopItem[] shopItems = itemGenerator.RandomGenerateShopItems(shopType, MinItems, MaxItems);

                Assert.IsTrue(shopItems.Length >= 50
                    && shopItems.Length <= 100);
            }
        }
    }
}
