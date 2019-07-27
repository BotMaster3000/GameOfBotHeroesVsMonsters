using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.Items;
using System.Linq;
using GameOfBotLib.Models.Shops;

namespace GameOfBotLib.Logic
{
    public class ShopItemGenerator : IShopItemGenerator
    {
        private readonly Random rand = new Random();

        public IShopItem[] RandomGenerateShopItems(ShopTypes shopType, int minItems, int maxItems)
        {
            IItem[] itemPool = GenerateItemPool(shopType);

            int totalItemsGenerated = rand.Next(minItems, maxItems);

            IDictionary<IItem, int> itemsAndStockQuantity = GetItemAndStockOfItemPool(itemPool, totalItemsGenerated);

            IShopItem[] shopItems = new IShopItem[itemsAndStockQuantity.Count];
            int counter = 0;
            foreach (KeyValuePair<IItem, int> itemAndStockQuantity in itemsAndStockQuantity)
            {
                int itemPrice = GetItemPrice(itemAndStockQuantity.Key);
                shopItems[counter] = new ShopItem(itemAndStockQuantity.Key, itemPrice, itemAndStockQuantity.Value);
                ++counter;
            }

            return shopItems;
        }

        private IItem[] GenerateItemPool(ShopTypes shopType)
        {
            IDictionary<IItem, int> itemsAndOccuranceChances = GetItemsAndOccuranceChance(shopType);
            IItem[] itemPool = new IItem[itemsAndOccuranceChances.Sum(x => x.Value)];

            int indexCounter = 0;
            foreach (KeyValuePair<IItem, int> itemAndOccuranceChance in itemsAndOccuranceChances)
            {
                for (int i = 0; i < itemAndOccuranceChance.Value; ++i)
                {
                    itemPool[indexCounter] = itemAndOccuranceChance.Key;
                    ++indexCounter;
                }
            }

            return itemPool;
        }

        private IDictionary<IItem, int> GetItemAndStockOfItemPool(IItem[] itemPools, int totalItems)
        {
            IDictionary<IItem, int> itemAndStockAmount = new Dictionary<IItem, int>();
            for (int i = 0; i < totalItems; ++i)
            {
                IItem item = itemPools[rand.Next(0, itemPools.Length)];
                if (itemAndStockAmount.ContainsKey(item))
                {
                    ++itemAndStockAmount[item];
                }
                else
                {
                    itemAndStockAmount.Add(item, 1);
                }
            }
            return itemAndStockAmount;
        }

        private IDictionary<IItem, int> GetItemsAndOccuranceChance(ShopTypes shopType)
        {
            return shopType switch
            {
                ShopTypes.Tavern => new Dictionary<IItem, int>()
                {
                    { ConsumableItem.GetConsumableItem(ConsumableItemTypes.Beer), 1  }
                },
                ShopTypes.Inn => new Dictionary<IItem, int>()
                {
                    { ConsumableItem.GetConsumableItem(ConsumableItemTypes.Beer), 1  }
                },
                ShopTypes.ArmorShop => new Dictionary<IItem, int>()
                {
                    { Armor.GetArmor(ArmorTypes.CopperArmor), 10 },
                    { Armor.GetArmor(ArmorTypes.IronArmor), 3 },
                },
                ShopTypes.WeaponShop => new Dictionary<IItem, int>()
                {
                    { Weapon.GetWeapon(WeaponTypes.Axe), 10 },
                    { Weapon.GetWeapon(WeaponTypes.Spear), 15 },
                    { Weapon.GetWeapon(WeaponTypes.Sword), 13 },
                },
                ShopTypes.ItemShop => new Dictionary<IItem, int>()
                {
                    { ConsumableItem.GetConsumableItem(ConsumableItemTypes.HealingPotion), 1  }
                },
                ShopTypes.BitOfEverythingShopType => new Dictionary<IItem, int>()
                {
                    { ConsumableItem.GetConsumableItem(ConsumableItemTypes.HealingPotion), 50  },
                    { Armor.GetArmor(ArmorTypes.CopperArmor), 1  },
                    { Weapon.GetWeapon(WeaponTypes.Axe), 4  },
                },
                _ => null
            };
        }

        private static int GetItemPrice(IItem item)
        {
            if (item is IWeapon weapon)
            {
                return weapon.WeaponType switch
                {
                    WeaponTypes.Axe => 12,
                    WeaponTypes.Sword => 15,
                    WeaponTypes.Spear => 10,
                    _ => 0
                };
            }
            else if (item is IArmor armor)
            {
                return armor.ArmorType switch
                {
                    ArmorTypes.CopperArmor => 8,
                    ArmorTypes.IronArmor => 18,
                    _ => 0,
                };
            }
            else if (item is IConsumableItem consumable)
            {
                return consumable.ConsumableItemType switch
                {
                    ConsumableItemTypes.Beer => 2,
                    ConsumableItemTypes.HealingPotion => 20
                };
            }
            else
            {
                throw new Exception("ItemType could not be determined");
            }
        }
    }
}
