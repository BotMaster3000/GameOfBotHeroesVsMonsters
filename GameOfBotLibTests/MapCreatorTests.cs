using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GameOfBotLib.Logic;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using System.Linq;

namespace GameOfBotLibTests
{
    [TestClass]
    public class MapCreatorTests
    {
        [TestMethod]
        public void MapCreatorGenerateFlatMapTest()
        {
            const int MapWidth = 100;
            const int MapHeight = 100;

            Dictionary<TileValues, int> tileValueAndAppearanceChance = new Dictionary<TileValues, int>()
            {
                { TileValues.City, 10 },
                { TileValues.Forest, 10 },
            };

            MapCreator creator = new MapCreator();
            IMap map = creator.GenerateFlatMap(MapWidth, MapHeight, tileValueAndAppearanceChance);

            Assert.AreEqual(MapWidth, map.Width);
            Assert.AreEqual(MapHeight, map.Height);

            int cityTilesCount = CountMapTilesOfGivenTileValue(map, TileValues.City);
            int forestTileCount = CountMapTilesOfGivenTileValue(map, TileValues.Forest);

            Assert.IsTrue(cityTilesCount * 1.0 / map.Tiles.Length >= 0.4); // Should be at least 40% for equal chances of generation
            Assert.IsTrue(forestTileCount * 1.0 / map.Tiles.Length >= 0.4);

            for (int xPos = 0; xPos < MapWidth; ++xPos)
            {
                for (int yPos = 0; yPos < MapHeight; ++yPos)
                {
                    int tempXPos = xPos; // Needed because of lambda-creation and tight loops
                    int tempYPos = yPos;

                    System.Threading.Tasks.Task.Factory.StartNew(() =>
                    {
                        Assert.AreEqual(1,
                        map.Tiles.Count(x
                        => x.XPos == tempXPos
                        && x.YPos == tempYPos)); // Should contain every XPos and YPos exactly 1 time
                    });
                }
            }
        }

        private int CountMapTilesOfGivenTileValue(IMap map, TileValues tileValue)
        {
            return map.Tiles.Count(x => x.TileValue == tileValue);
        }

        [TestMethod]
        public void GenerateMapElementsTest()
        {
            const int MapWidth = 10;
            const int MapHeight = 10;

            Dictionary<TileValues, int> tileValueAndAppearanceChance = new Dictionary<TileValues, int>()
            {
                { TileValues.Grassland, 10},
                { TileValues.Forest, 10 },
                { TileValues.Village, 10},
                { TileValues.City, 10 },
                { TileValues.Fortress, 10},
            };

            MapCreator creator = new MapCreator();
            IMap map = creator.GenerateFlatMap(MapWidth, MapHeight, tileValueAndAppearanceChance);

            creator.GenerateMapElements(map);

            Assert.AreEqual(MapWidth, map.Width);
            Assert.AreEqual(MapHeight, map.Height);

            foreach (ITile tile in map.Tiles)
            {
                switch (tile.TileValue)
                {
                    case TileValues.City:
                    case TileValues.Village:
                    case TileValues.Fortress:
                        Assert.IsTrue(tile.Buildings.Length > 0);
                        foreach (IBuilding building in tile.Buildings)
                        {
                            switch (building.BuildingType)
                            {
                                case BuildingTypes.ArmorShop:
                                case BuildingTypes.WeaponShop:
                                case BuildingTypes.Tavern:
                                case BuildingTypes.Inn:
                                case BuildingTypes.BitOfEverythingStore:
                                case BuildingTypes.ItemShop:
                                    Assert.IsNotNull(building.Shop);
                                    Assert.IsNotNull(building.Shop.ShopInventory);
                                    Assert.IsNotNull(building.Shop.ShopInventory.ShopItems);
                                    Assert.IsTrue(building.Shop.ShopInventory.ShopItems.Length > 0);
                                    break;
                            }
                        }
                        break;
                    case TileValues.Grassland:
                    case TileValues.Forest:
                        Assert.IsTrue(tile.Buildings == null || tile.Buildings.Length > 0);
                        break;
                }
            }
        }

        [TestMethod]
        public void AddCreaturesToMapTest()
        {
            const int MapWidth = 10;
            const int MapHeight = 10;

            IDictionary<TileValues, int> tileValueAndAppearanceChance = new Dictionary<TileValues, int>()
            {
                { TileValues.Grassland, 10},
                { TileValues.Forest, 10 },
                { TileValues.Village, 10},
                { TileValues.City, 10 },
                { TileValues.Fortress, 10},
            };

            IDictionary<CreatureTypes, int> creatureTypeAndTotalAmountGenerated = new Dictionary<CreatureTypes, int>()
            {
                { CreatureTypes.Human, 100 },
                { CreatureTypes.Goblin, 200 },
                { CreatureTypes.Troll, 50 },
            };

            IMapCreator creator = new MapCreator();
            IMap map = creator.GenerateFlatMap(MapWidth, MapHeight, tileValueAndAppearanceChance);
            creator.GenerateMapElements(map);
            creator.AddCreaturesToMap(map, creatureTypeAndTotalAmountGenerated);

            ITile[] creatureTiles = map.Tiles
                .Where(x
                    => x.CreatureList.Count > 0)
                .ToArray();

            foreach (KeyValuePair<CreatureTypes, int> creatureTypeAndGenerated in creatureTypeAndTotalAmountGenerated)
            {
                IList<IList<ICreature>> creaturesListLists = creatureTiles.Select(x => x.CreatureList).ToList();
                int creatureCount = 0;
                foreach(IList<ICreature> creatureList in creaturesListLists)
                {
                    foreach(ICreature creature in creatureList)
                    {
                        if(creature.CreatureType == creatureTypeAndGenerated.Key)
                        {
                            ++creatureCount;
                        }
                    }
                }

                Assert.AreEqual(creatureTypeAndGenerated.Value, creatureCount);
            }

            foreach (ITile tile in creatureTiles)
            {
                switch (tile.TileValue)
                {
                    case TileValues.Village:
                    case TileValues.City:
                    case TileValues.Fortress:
                        int totalAccepptedCreatures = tile.CreatureList.Count(x // Count total Human-Creatures
                            => x.CreatureType == CreatureTypes.Human);
                        Assert.AreEqual(totalAccepptedCreatures, tile.CreatureList.Count);
                        break;
                    case TileValues.Forest:
                    case TileValues.Grassland:
                        int totalNotAcceptedCreatures = tile.CreatureList.Count(x // Count total Not-Human-Creatures
                            => x.CreatureType != CreatureTypes.Human);
                        Assert.AreEqual(totalNotAcceptedCreatures, tile.CreatureList.Count);
                        break;
                    default:
                        throw new System.Exception("Unchecked Tile-Value");
                }
            }
        }
    }
}
