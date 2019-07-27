using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Logic;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Enums;
using GameOfBotLib.Models.Shops;
using GameOfBotLib.Models.Items;
using System.Linq;

namespace GameOfBotLibTests
{
    [TestClass]
    public class ShopCreatorTest
    {
        [TestMethod]
        public void CreateShopTest()
        {
            const ShopTypes ShopType = ShopTypes.BitOfEverythingShop;

            IShopItem[] shopItems = new IShopItem[]
            {
                new ShopItem(
                    new Armor(ArmorTypes.CopperArmor, 10),
                    10, 15),
                new ShopItem(
                    new Weapon(WeaponTypes.Axe, 15),
                    18, 10),
                new ShopItem(
                    new Weapon(WeaponTypes.Sword, 12),
                    6, 3),
            };

            ShopCreator creator = new ShopCreator();
            IShop shop = creator.CreateShop(ShopType, shopItems);

            Assert.AreEqual(ShopType, shop.ShopType);
            Assert.AreEqual(shopItems.Length, shop.ShopInventory.ShopItems.Length);

            foreach (IShopItem item in shop.ShopInventory.ShopItems)
            {
                IShopItem localShopItem = Array.Find(shopItems, x
                    => x.Item.ItemType == item.Item.ItemType
                    && x.Price == item.Price
                    && x.StockQuantity == item.StockQuantity);

                Assert.IsNotNull(localShopItem);
                Assert.IsTrue(item.Item is Armor || item.Item is Weapon);

                if (item.Item is Armor shopArmor && localShopItem.Item is Armor localArmor)
                {
                    Assert.AreEqual(localArmor.ArmorType, shopArmor.ArmorType);
                    Assert.AreEqual(localArmor.DefenseValue, shopArmor.DefenseValue);
                }
                else if (item.Item is Weapon shopWeapon && localShopItem.Item is Weapon localWeapon)
                {
                    Assert.AreEqual(localWeapon.WeaponType, shopWeapon.WeaponType);
                    Assert.AreEqual(localWeapon.AttackValue, shopWeapon.AttackValue);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    }
}
