using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.Map;

namespace GameOfBotLib.Logic
{
    public class MapCreator : IMapCreator
    {
        private readonly Random rand = new Random();

        public IMap GenerateFlatMap(int mapWidth, int mapHeight, IDictionary<TileValues, int> tilevalueAndAppearanceChance)
        {
            List<TileValues> tileValuesPool = CreateTileValuePool(tilevalueAndAppearanceChance);
            ITile[] tiles = InitializeTileArrays(mapWidth, mapHeight, tileValuesPool);

            return new Map(mapWidth, mapHeight, tiles);
        }

        private ITile[] InitializeTileArrays(int mapWidht, int mapHeight, List<TileValues> tileValuesPool)
        {
            ITile[] tiles = new ITile[mapWidht * mapHeight];
            int counter = 0;
            for(int xPos = 0; xPos < mapWidht; ++xPos)
            {
                for(int yPos = 0; yPos < mapHeight; ++yPos)
                {
                    TileValues selectedTileValue = tileValuesPool[rand.Next(0, tileValuesPool.Count)];
                    tiles[counter] = new Tile(xPos, yPos, selectedTileValue);
                    ++counter;
                }
            }
            return tiles;
        }

        private List<TileValues> CreateTileValuePool(IDictionary<TileValues, int> tileValueAndAppearanceChance)
        {
            List<TileValues> tileValues = new List<TileValues>();
            foreach(KeyValuePair<TileValues, int> tileValueAndChance in tileValueAndAppearanceChance)
            {
                for(int i = 0; i < tileValueAndChance.Value; ++i)
                {
                    tileValues.Add(tileValueAndChance.Key);
                }
            }
            return tileValues;
        }

        public void GenerateMapElements(IMap map)
        {
            throw new NotImplementedException();
        }
    }
}
