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

            Dictionary<CreatureTypes, int> creatureTypeAndTotalAmountGenerated = new Dictionary<CreatureTypes, int>()
            {
                { CreatureTypes.Human , 100 },
                { CreatureTypes.Goblin , 200 },
                { CreatureTypes.Troll , 50 },
            };

            MapCreator creator = new MapCreator();
            IMap map = creator.GenerateFlatMap(MapWidth, MapHeight, tileValuesAndOccuranceChance);

            MapDrawer.DrawMap(map);

            creator.GenerateMapElements(map);
            creator.AddCreaturesToMap(map, creatureTypeAndTotalAmountGenerated);
            MapDrawer.DrawMapTileShopsAndNpcs(map);

            Console.WriteLine("Hello World!");
        }
    }
}
