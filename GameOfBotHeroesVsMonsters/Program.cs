using System;
using System.Collections.Generic;
using GameOfBotLib.Logic;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotHeroesVsMonsters
{
    class Program
    {
        private static void Main()
        {
            const int MapWidth = 20;
            const int MapHeight = 20;
            Dictionary<TileValues, int> tileValuesAndOccuranceChance = new Dictionary<TileValues, int>
            {
                { TileValues.Fortress, 5 },
                { TileValues.City, 20 },
                { TileValues.Village, 100 },
                { TileValues.Forest, 1000 },
                { TileValues.Grassland, 2500 },
            };

            MapCreator creator = new MapCreator();
            IMap map = creator.GenerateFlatMap(MapWidth, MapHeight, tileValuesAndOccuranceChance);
            creator.GenerateMapElements(map);

            MapDrawer.DrawMap(map);

            MapDrawer.DrawMapTileShops(map);

            Console.WriteLine("Hello World!");
        }
    }
}
