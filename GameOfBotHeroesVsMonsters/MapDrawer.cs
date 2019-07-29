using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Enums;

namespace GameOfBotHeroesVsMonsters
{
    public static class MapDrawer
    {
        public static void DrawMap(IMap map)
        {
            ConsoleColor previousConsoleColor = Console.ForegroundColor;
            ConsoleColor previousBackgroundColor = Console.BackgroundColor;
            foreach (ITile tile in map.Tiles)
            {
                Console.CursorLeft = tile.XPos;
                Console.CursorTop = tile.YPos;
                Console.ForegroundColor = GetConsoleColorForTileValue(tile.TileValue);
                Console.BackgroundColor = GetConsoleBackgroundColorForTileValue(tile.TileValue);
                Console.Write('X');
            }
            Console.ForegroundColor = previousConsoleColor;
            Console.BackgroundColor = previousBackgroundColor;
        }

        private static ConsoleColor GetConsoleColorForTileValue(TileValues tileValue)
        {
            return tileValue switch
            {
                TileValues.Forest => ConsoleColor.DarkGreen,
                TileValues.Grassland => ConsoleColor.White,
                TileValues.Fortress => ConsoleColor.Black,
                TileValues.City => ConsoleColor.DarkBlue,
                TileValues.Village => ConsoleColor.DarkRed,
                _ => ConsoleColor.White,
            };
        }

        private static ConsoleColor GetConsoleBackgroundColorForTileValue(TileValues tileValue)
        {
            switch (tileValue)
            {
                case TileValues.Fortress:
                case TileValues.City:
                case TileValues.Village:
                    return ConsoleColor.DarkGray;
                default:
                    return ConsoleColor.Black;
            }
        }

        public static void DrawMapTileShopsAndNpcs(IMap map)
        {
            foreach (ITile tile in map.Tiles)
            {
                if (tile.Buildings?.Length > 0 || tile.CreatureList.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(tile.TileValue);
                    Console.WriteLine($"XPos: {tile.XPos} YPos {tile.YPos}");

                    if(tile.Buildings?.Length > 0)
                    {
                        foreach (IBuilding building in tile.Buildings)
                        {
                            Console.WriteLine(building.BuildingType);
                            Console.WriteLine(building.Shop.ShopType);
                            foreach (IShopItem shopItem in building.Shop.ShopInventory.ShopItems)
                            {
                                if (shopItem.Item is IArmor armor)
                                {
                                    Console.WriteLine($"ArmorType: {armor.ArmorType} Price: {shopItem.Price} Stock: {shopItem.StockQuantity}");
                                }
                                else if (shopItem.Item is IWeapon weapon)
                                {
                                    Console.WriteLine($"WeaponType: {weapon.WeaponType} Price: {shopItem.Price} Stock: {shopItem.StockQuantity}");
                                }
                                else if (shopItem.Item is IConsumableItem consumable)
                                {
                                    Console.WriteLine($"ConsumableType: {consumable.ConsumableItemType} Price: {shopItem.Price} Stock: {shopItem.StockQuantity}");
                                }
                                else
                                {
                                    Console.WriteLine($"ItemType: {shopItem.Item.ItemType} Price: {shopItem.Price} Stock: {shopItem.StockQuantity}");
                                }
                            }
                        }
                    }


                    foreach(ICreature creature in tile.CreatureList)
                    {
                        Console.WriteLine($"{creature.ID} {creature.CreatureType}");
                        Console.WriteLine($"Level: {creature.Level} XP: {creature.Experience} HP: {creature.Health} MaxHP: {creature.MaxHealth}");

                        if(creature is IHero hero)
                        {
                            Console.WriteLine($"Gold: {hero.Inventory.Gold}");
                            foreach(IItem item in hero.Inventory.Items)
                            {
                                Console.WriteLine(item.ItemType);
                            }
                        }
                        else if(creature is IMonster monster)
                        {
                            Console.WriteLine($"Gold: {monster.Inventory.Gold}");
                            foreach (IItem item in monster.Inventory.Items)
                            {
                                Console.WriteLine(item.ItemType);
                            }
                        }
                    }
                }
            }
        }
    }
}
