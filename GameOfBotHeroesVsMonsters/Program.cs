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
            const int MapWidth = 10;
            const int MapHeight = 10;
            Dictionary<TileValues, int> tileValuesAndOccuranceChance = new Dictionary<TileValues, int>
            {
                { TileValues.City, 20 },
                { TileValues.Forest, 250 },
                { TileValues.Fortress, 5 },
                { TileValues.Grassland, 500 },
                { TileValues.Village, 50 },
            };

            MapCreator creator = new MapCreator();
            IMap map = creator.GenerateFlatMap(MapWidth, MapHeight, tileValuesAndOccuranceChance);

            MapDrawer.DrawMap(map);

            Console.WriteLine("Hello World!");
        }
    }
}
