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
            for (int xPos = 0; xPos < mapWidht; ++xPos)
            {
                for (int yPos = 0; yPos < mapHeight; ++yPos)
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
            foreach (KeyValuePair<TileValues, int> tileValueAndChance in tileValueAndAppearanceChance)
            {
                for (int i = 0; i < tileValueAndChance.Value; ++i)
                {
                    tileValues.Add(tileValueAndChance.Key);
                }
            }
            return tileValues;
        }

        public void GenerateMapElements(IMap map)
        {
            foreach (ITile tile in map.Tiles)
            {
                int buildingAmounts = rand.Next(1, 4);
                Dictionary<BuildingTypes, int> buildingTypesAndAppearanceChances = new Dictionary<BuildingTypes, int>()
                {
                    { BuildingTypes.Inn, 50 },
                    { BuildingTypes.Tavern, 50 },
                    { BuildingTypes.ArmorShop, 10 },
                    { BuildingTypes.WeaponShop, 10 },
                    { BuildingTypes.ItemShop, 20 },
                    { BuildingTypes.BitOfEverythingStore, 50 },
                };
                List<BuildingTypes> buildingPool;
                IBuilding[] buildings;
                switch (tile.TileValue)
                {
                    case TileValues.Village:
                        buildingAmounts = rand.Next(1, 4);

                        buildingPool = GetBuildingPool(buildingTypesAndAppearanceChances);
                        buildings = GetBuildings(buildingPool, buildingAmounts);
                        tile.SetBuildings(buildings);
                        break;
                    case TileValues.City:
                        buildingAmounts = rand.Next(3, 10);
                        buildingPool = GetBuildingPool(buildingTypesAndAppearanceChances);
                        buildings = GetBuildings(buildingPool, buildingAmounts);
                        tile.SetBuildings(buildings);
                        break;
                    case TileValues.Fortress:
                        buildingAmounts = rand.Next(8, 20);
                        buildingPool = GetBuildingPool(buildingTypesAndAppearanceChances);
                        buildings = GetBuildings(buildingPool, buildingAmounts);
                        tile.SetBuildings(buildings);
                        break;
                    case TileValues.Grassland:
                    case TileValues.Forest:
                    default:
                        break;
                }
            }
        }

        private List<BuildingTypes> GetBuildingPool(IDictionary<BuildingTypes, int> buildingTypesAndAppearanceChances)
        {
            List<BuildingTypes> buildingTypes = new List<BuildingTypes>();
            foreach (KeyValuePair<BuildingTypes, int> buildingTypeAndAppearanceChance in buildingTypesAndAppearanceChances)
            {
                for (int i = 0; i < buildingTypeAndAppearanceChance.Value; ++i)
                {
                    buildingTypes.Add(buildingTypeAndAppearanceChance.Key);
                }
            }
            return buildingTypes;
        }

        private IBuilding[] GetBuildings(List<BuildingTypes> buildingPool, int totalBuildingsToGenerate)
        {
            IBuilding[] buildings = new IBuilding[totalBuildingsToGenerate];
            BuildingCreator creator = new BuildingCreator();
            for (int i = 0; i < totalBuildingsToGenerate; ++i)
            {
                int buildingIndex = rand.Next(0, buildingPool.Count);
                BuildingTypes buildingToGenerate = buildingPool[buildingIndex];
                buildings[i] = creator.RandomGenerateBuilding(buildingToGenerate);
            }
            return buildings;
        }
    }
}
